using System.Collections.Generic;

namespace OnlineJobPortal.Models.Services
{
    public interface IEductaionLevelService
    {
        List<EducationLevel> GetAll();
        void Add(EducationLevel educationLevel);
        EducationLevel GetById(long id);
        void Update(long id, EducationLevel company);
        void Delete(long id);
    }
}
