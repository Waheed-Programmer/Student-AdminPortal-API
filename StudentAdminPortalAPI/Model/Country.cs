using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortalAPI.Model
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
