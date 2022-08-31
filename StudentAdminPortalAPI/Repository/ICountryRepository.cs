using StudentAdminPortalAPI.Model;
using StudentAdminPortalAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountryAsync();
        Task<Country> GetCountryById(int id);    
        Task<bool> Exists(int id);        
        Task<Country> InsertCountry(Country c);
        
    }
}
