using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void Delete(long id)
        {
            var data = _context.JobSeekers.Find(id);
            _context.JobSeekers.Remove(data);
            _context.SaveChanges();
        }

        public List<JobSeeker> GetAll()
        {
            var result = _context.JobSeekers.
                Include(c=>c.City).
                ToList();
            return result;
        }

        public JobSeeker GetById(long id)
        {
            var data = _context.JobSeekers.Find(id);
            return data;
        }

        public void Update(long id, JobSeeker jobSeeker)
        {
            _context.JobSeekers.Update(jobSeeker);
            _context.SaveChanges();
        }
    }
}
