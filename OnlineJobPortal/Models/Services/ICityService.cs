using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public interface ICityService
    {
        List<City> GetAll();
        void Add(City city);
        City GetById(long id);
        City Update(long id, City city);
        void Delete(long id);
    }
}
