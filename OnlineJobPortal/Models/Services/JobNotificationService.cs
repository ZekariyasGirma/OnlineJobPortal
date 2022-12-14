using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public class JobNotificationService : IJobNotificationService
    {
        private readonly ApplicationDbContext _context;
        public JobNotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AcceptCV(long id)
        {
            var data = GetById(id);
            data.ApprovalStatus = "Accepted";
            _context.JobNotifications.Update(data);
            _context.SaveChanges();
        }

        public void Add(JobNotification jobNotification)
        {
            _context.JobNotifications.Add(jobNotification);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var data = GetById(id);
            _context.JobNotifications.Remove(data);
            _context.SaveChanges();
        }

        public List<JobNotification> GetAll()
        {
            var result = _context.JobNotifications.
                Include(j => j.Job).
                Include(js => js.JobSeeker).
                Include(c => c.Company).
                ToList();
            return result;
        }

        public JobNotification GetById(long id)
        {
            var data = _context.JobNotifications.
                Include(j => j.Job).
                Include(js => js.JobSeeker).
                Include(c => c.Company).FirstOrDefault(x=>x.Id==id);
            return data;
        }

        public void RejectCV(long id)
        {
            var data = GetById(id);
            data.ApprovalStatus = "Rejected";
            _context.JobNotifications.Update(data);
            _context.SaveChanges();
        }

        public void Update(long id, JobNotification jobNotification)
        {
            _context.JobNotifications.Update(jobNotification);
            _context.SaveChanges();
        }
    }
}
