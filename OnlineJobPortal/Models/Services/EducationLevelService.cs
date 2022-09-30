using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public class EducationLevelService : IEductaionLevelService
    {
        private readonly ApplicationDbContext _context;
        public EducationLevelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(EducationLevel educationLevel)
        {
            _context.EducationLevels.Add(educationLevel);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var data = _context.EducationLevels.Find(id);
            _context.EducationLevels.Remove(data);
            _context.SaveChanges();
        }

        public List<EducationLevel> GetAll()
        {
            var result = _context.EducationLevels.ToList();
            return result;
        }

        public EducationLevel GetById(long id)
        {
            var data = _context.EducationLevels.Find(id);
            return data;
        }

        public void Update(long id, EducationLevel company)
        {
            _context.EducationLevels.Update(company);
            _context.SaveChanges();
        }
    }
}
