using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineJobPortal.Models.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Company> GetAllCompany()
        {
            var result = _context.Companies.Include(c => c.City).ToList();
            return result;
        }
        public List<JobSeeker> GetAllJobSeeker()
        {
            var result = _context.JobSeekers.
                Include(c => c.City).Include(cr => cr.Credential).
                ToList();
            return result;
        }
        public bool AccountExists(string username, string password)
        {
            var res = _context.Admins.Any(x => x.Username == username && x.Password == password);
            return res;
        }
        public Admin GetByUserAndPass(string username, string password)
        {
            Admin res = _context.Admins.FirstOrDefault(x => x.Username == username && x.Password == password);
            return res;
        }
    }
}
