using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;
        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var data = _context.Jobs.Find(id);
            _context.Jobs.Remove(data);
            _context.SaveChanges();
        }

        public List<Job> GetAll()
        {
            var result = _context.Jobs.
                Include(ci => ci.City).
                Include(co => co.Company).
                Include(ed => ed.EducationLevel).
                ToList();
            return result;
        }

        public Job GetById(long id)
        {
            var data = _context.Jobs.Find(id);
            return data;
        }

        public void Update(long id, Job job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }
    }
}
