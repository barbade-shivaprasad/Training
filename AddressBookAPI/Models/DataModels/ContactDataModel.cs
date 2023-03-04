using System;

namespace AddressBookAPI.Models.DataModels
{
    public class ContactDataModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string? Landline { get; set; }

        public string? website { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
