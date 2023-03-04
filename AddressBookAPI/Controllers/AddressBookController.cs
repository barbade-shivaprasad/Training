using AddressBookAPI.Interfaces;
using AddressBookAPI.Models.CoreModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AddressBookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressBookController : ControllerBase
    {
        
        private readonly ILogger<AddressBookController> _logger;
        private readonly IAddressBookService _addressBookService;

        public AddressBookController(ILogger<AddressBookController> logger,IAddressBookService addressBookService)
        {
            _logger = logger;
            _addressBookService = addressBookService;
        }

        [HttpGet("/[controller]/getcontactlist")]
        public async Task<IActionResult> GetContacts()
        {
            var contact = await _addressBookService.GetContactList();
            return Ok(contact);
        }

        [HttpGet("/[controller]/getcontact/{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _addressBookService.GetContact(id);

            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost("/[controller]/addcontact")]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            int id = await _addressBookService.AddContact(contact);
            return Ok(id);
        }

        [HttpPut("/[controller]/editContact/{id}")]
        public async Task<IActionResult> EditContact(int id,Contact contact)
        {
            contact.Id = id;

            Console.WriteLine(JsonSerializer.Serialize(contact));

            if(await _addressBookService.EditContact(contact))
                return Ok("success");

            return BadRequest("Contact not found");
        }

        [HttpGet("/[controller]/getpreviousId/{id}")]
        public async Task<IActionResult> GetPreviousId(int id)
        {
            int? Id = await _addressBookService.GetPreviousContactId(id);

            if (Id == null)
            {
                return NotFound();
            }
            return Ok(Id);
        }

        [HttpDelete("/[controller]/deletecontact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {

            if(await _addressBookService.DeleteContact(id))
                return Ok("success");

            return BadRequest("Contact not found");
        }
    }
}