using System.Collections.Generic;

namespace OnlineJobPortal.Models.Services
{
    public interface IJobNotificationService
    {
        List<JobNotification> GetAll();
        void Add(JobNotification jobNotification);
        JobNotification GetById(long id);
        JobNotification Update(long id, JobNotification jobNotification);
        void Delete(long id);
    }
}
