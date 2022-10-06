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
    }
}
