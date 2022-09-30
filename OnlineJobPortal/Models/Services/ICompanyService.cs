using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineJobPortal.Models.Services
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        void Add(Company company);
        Company GetById(long id);
        void Update(long id, Company company);
        void Delete(long id);
    }
}
