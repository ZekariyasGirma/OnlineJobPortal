using System.Collections.Generic;

namespace OnlineJobPortal.Models.Services
{
    public interface IJobSeekerService
    {
        List<JobSeeker> GetAll();
        void Add(JobSeeker jobSeeker);
        JobSeeker GetById(long id);
        JobSeeker Update(long id, JobSeeker jobSeeker);
        void Delete(long id);
    }
}
