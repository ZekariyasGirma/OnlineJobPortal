using System.Collections.Generic;

namespace OnlineJobPortal.Models.Services
{
    public interface IJobService
    {
        List<Job> GetAll();
        void Add(Job job);
        Job GetById(long id);
        Job Update(long id, Job job);
        void Delete(long id);
    }
}
