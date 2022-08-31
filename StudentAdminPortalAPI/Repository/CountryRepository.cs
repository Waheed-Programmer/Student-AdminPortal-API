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
            return await _applicationDbContext.Countries.AnyAsync(x => x.CountryId == id);
        }

        public async Task<List<Country>> GetAllCountryAsync()
        {
            return await _applicationDbContext.Countries
               .ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _applicationDbContext.Countries.Where(x => x.CountryId == id).
                FirstOrDefaultAsync();
        }

        public async Task<Country> InsertCountry(Country c)
        {
            var checkCountry = await _applicationDbContext.Countries.FirstOrDefaultAsync(x => x.CountryId == c.CountryId);
            if (checkCountry != null && checkCountry.CountryId > 0)
            {
                checkCountry.CountryName = c.CountryName;
                checkCountry.CountryId = c.CountryId;
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                _applicationDbContext.Countries.Add(c);
                await _applicationDbContext.SaveChangesAsync();
            }
            return checkCountry;
        }
    }
}

