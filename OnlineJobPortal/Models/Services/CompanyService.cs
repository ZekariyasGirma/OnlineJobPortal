using Microsoft.AspNetCore.Mvc.Rendering;
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

        public bool AccountExists(string username, string password)
        {
            var res = _context.Companies.Any(x => x.Username == username && x.Password == password);
            return res;
        }

        public void Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var data = GetById(id);
            _context.Companies.Remove(data);
            _context.SaveChanges();
        }

        public List<Company> GetAll()
        {
            var result = _context.Companies.Include(c => c.City).ToList();
            return result;
        }

        public Company GetById(long id)
        {
            var data = _context.Companies.Include(c => c.City).FirstOrDefault(x => x.Id == id);
            return data;
        }

        public Company GetByUserAndPass(string username, string password)
        {
            Company res = _context.Companies.FirstOrDefault(x => x.Username == username && x.Password == password);
            return res;
        }

        public List<Job> GetPostedJobs(long id)
        {
            var result = _context.Jobs.
                Include(ci => ci.City).
                Include(co => co.Company).
                Include(ed => ed.EducationLevel).Where(x => x.CompanyId == id ).
                ToList();
            return result;
        }
        public bool CheckForNoti(long id)
        {
            if (_context.JobNotifications.Any(x => x.CompanyId == id && x.C_ReadStatus == "NotSet"))
            {
                var result = _context.JobNotifications.
                 Include(j => j.Job).
                 Include(js => js.JobSeeker).
                 Include(c => c.Company).Where(c => c.CompanyId == id&& c.C_ReadStatus=="NotSet").
                 ToList();
                foreach (JobNotification itm in result)
                {
                    itm.C_ReadStatus = "Read";
                    _context.JobNotifications.Update(itm);
                    _context.SaveChanges();
                }
               return true;
            }
                
            else return false;
        }
        public List<JobNotification> JobNotis(long id)
        {
            var result = _context.JobNotifications.
                Include(j => j.Job).
                Include(js => js.JobSeeker).
                Include(c => c.Company).Where(c => c.CompanyId == id).
                ToList();
            return result;
        }
        public List<SelectListItem> ListOfCities()
        {

            var clist = _context.Cities.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CityName
            }).ToList();
            clist.Insert(0, new SelectListItem()
            {
                Text = "----Select City----",
                Value = string.Empty
            });
            return clist;

        }

        public void Update(long id, Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }
    }
}
