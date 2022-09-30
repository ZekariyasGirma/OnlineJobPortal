using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public class CredentialService : ICredentialService
    {
        private readonly ApplicationDbContext _context;
        public CredentialService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Credential credential)
        {
            _context.Credentials.Add(credential);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var data = _context.Credentials.Find(id);
            _context.Credentials.Remove(data);
            _context.SaveChanges();
        }

        public List<Credential> GetAll()
        {
            var result = _context.Credentials.
                Include(js => js.JobSeeker).
                Include(el=>el.EducationLevel).
                ToList();
            return result;
        }

        public Credential GetById(long id)
        {
            var data = _context.Credentials.Find(id);
            return data;
        }

        public void Update(long id, Credential credential)
        {
            _context.Credentials.Update(credential);
            _context.SaveChanges();
        }
    }
}
