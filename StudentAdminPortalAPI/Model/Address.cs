using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortalAPI.Model
{
    public class Address
    {
        [Key]

        public int AddressId { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        
    }
}