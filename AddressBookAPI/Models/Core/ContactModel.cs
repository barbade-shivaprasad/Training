//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace AddressBookAPI.Models.CoreModels
{
    public class Contact
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is Required"), MinLength(5, ErrorMessage = "min length is 5 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required"), EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile is Required"), Phone(ErrorMessage = "Mobile is invalid")]
        public string Mobile { get; set; }

        public string? Landline { get; set; }

        [Url(ErrorMessage = "Invalid URL")]
        public string? website { get; set; }

        public Address? Address { get; set; }

    }
}
