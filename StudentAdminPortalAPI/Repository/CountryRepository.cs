using Microsoft.EntityFrameworkCore;
using StudentAdminPortalAPI.Data;
using StudentAdminPortalAPI.Model;
using StudentAdminPortalAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CountryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Exists(int id)
        {
            return await _applicationDbContext.Departments.AnyAsync(x => x.DepartmentId == id);
        }

        public async Task<List<Country>> GetAllCountryAsync()
        {
            return await _applicationDbContext.Departments
               .ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _applicationDbContext.Departments.Where(x => x.DepartmentId == id).
                FirstOrDefaultAsync();
        }

        public Task<Country> InsertCountry(Country c)
        {
            throw new System.NotImplementedException();
        }
    }
}

