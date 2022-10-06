using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OnlineJobPortal.Models.Services
{
    public interface IJobService
    {
        List<Job> GetAll();
        void Add(Job job);
        Job GetById(long id);
        void Update(long id, Job job);
        void Delete(long id);
        List<SelectListItem> ListOfCompanies();
        List<SelectListItem> ListOfEduLvl();
        List<SelectListItem> ListOfCities();
    }
}
