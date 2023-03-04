using Address_book.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Build.Framework;
using Address_book.Interfaces;

namespace Address_book.ViewComponents
{
    public class ContactsViewComponent : ViewComponent
    {
        IAddressBookService _addressBookService;
        public ContactsViewComponent(IAddressBookService addressBookService)
        {
            _addressBookService = addressBookService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var contacts = await _addressBookService.GetContactList();

            return await Task.FromResult((IViewComponentResult)View(contacts));
        }
    }
}
