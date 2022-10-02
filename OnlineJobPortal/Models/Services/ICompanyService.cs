using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace OnlineJobPortal.Models.Services
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        void Add(Company company);
        Company GetById(long id);
        void Update(long id, Company company);
        void Delete(long id);
        List<SelectListItem> ListOfCities();
        bool AccountExists(string username, string password);
        Company GetByUserAndPass(string username, string password);
    }
}
