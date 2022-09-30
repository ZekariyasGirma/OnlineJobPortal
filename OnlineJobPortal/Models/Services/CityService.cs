using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _context;
        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var data = _context.Cities.Find(id);
            _context.Cities.Remove(data);
            _context.SaveChanges();
        }

        public List<City> GetAll()
        {
            var result = _context.Cities.ToList();
            return result;
        }

        public City GetById(long id)
        {
            var data = _context.Cities.Find(id);
            return data;
        }

        public void Update(long id, City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }
    }
}
