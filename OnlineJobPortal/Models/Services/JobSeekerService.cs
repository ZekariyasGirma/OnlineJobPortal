using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineJobPortal.Models.Services
{
    public class JobSeekerService : IJobSeekerService
    {
        private readonly ApplicationDbContext _context;

        public JobSeekerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(JobSeeker jobSeeker)
        {
            _context.JobSeekers.Add(jobSeeker);
            _context.SaveChanges();
        }
        public bool AccountExists(string username, string password)
        {
            var res = _context.JobSeekers.Any(x => x.Username == username && x.Password == password);
            return res;
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
        public JobSeeker GetByUserAndPass(string username, string password)
        {
            JobSeeker res = _context.JobSeekers.FirstOrDefault(x => x.Username == username && x.Password == password);
            return res;
        }
        public void Delete(long id)
        {
            var data = GetById(id);
            var cred = _context.Credentials.Find(data.CredentialId);
            _context.Credentials.Remove(cred);
            _context.JobSeekers.Remove(data);
            _context.SaveChanges();
        }

        public List<JobSeeker> GetAll()
        {
            var result = _context.JobSeekers.
                Include(c=>c.City).Include(cr=>cr.Credential).
                ToList();
            return result;
        }

        public JobSeeker GetById(long id)
        {
            var data = _context.JobSeekers.
                Include(c => c.City).Include(cr=> cr.Credential).Include(ed=>ed.Credential.EducationLevel).FirstOrDefault(x=>x.Id==id);
            return data;
        }

        public void Update(long id, JobSeeker jobSeeker)
        {
            _context.JobSeekers.Update(jobSeeker);
            _context.SaveChanges();
        }
    }
}
