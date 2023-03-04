using Address_book.Interfaces;
using Address_book.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Address_book.Controllers
{
    public class AddressBookController : Controller
    {
        private readonly IAddressBookService _addressBookService;
        public AddressBookController(IAddressBookService addressBookService)
        {
            _addressBookService= addressBookService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                id = await _addressBookService.GetFirstContactId();
            }

            if(id != null)
            {
                return RedirectToAction("Details", new { id });
            }
            return View();
        }

        public async Task<IActionResult> Details(int id) 
        {
            try
            {
                Contact? contact = await _addressBookService.GetContact(id);

                if(contact == null)
                {
                    throw new Exception("Contact Not found");
                }

                string[] s = contact.Address.Split("\\n");

                var obj = new {contact, s};
                return View(obj);
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return PartialView("Error");
            }

        }

        [HttpGet]
        public IActionResult AddContact()
        {
            ViewData["button"] = "Add";
            return PartialView("ContactForm");
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                ViewData["button"] = "Add";
                return PartialView("ContactForm",contact);
            }
            try
            {
                _addressBookService.AddContact(contact);
                return RedirectToAction("Index",new {id=contact.Id});
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return PartialView("Error");
            }
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                int? Id = await _addressBookService.GetPreviousContactId(id);

                _addressBookService.DeleteContact(id);

                return RedirectToAction("Index",new {id = Id});
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return PartialView("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditContact(int id)
        {
            try
            {
                Contact? contact = await _addressBookService.GetContact(id);

                if (contact == null)
                {
                    throw new Exception("Contact Not found");
                }
                ViewData["button"] = "Edit";
                return PartialView("ContactForm",contact);
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return PartialView("Error");
            }

        }

        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["button"] = "Edit";
                    return PartialView("ContactForm", contact);
                }

                _addressBookService.EditContact(contact);
                return RedirectToAction("Details","addressbook", new {id= contact.Id });

            }
            catch(Exception ex)
            {
                ViewData["button"] = ex.Message;
                return PartialView("Error");
            }
        }




    }
}
