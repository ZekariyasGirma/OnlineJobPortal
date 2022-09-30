using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var data = _context.Companies.Find(id);
            _context.Companies.Remove(data);
            _context.SaveChanges();
        }

        public List<Company> GetAll()
        {
            var result =_context.Companies.Include(c=> c.City)
                .ToList();
            return result;
        }

        public Company GetById(long id)
        {
            var data = _context.Companies.Find(id);
            return data;
        }

        public void Update(long id, Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }
    }
}
