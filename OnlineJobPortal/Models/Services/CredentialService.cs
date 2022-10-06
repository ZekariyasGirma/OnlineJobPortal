using Microsoft.AspNetCore.Mvc.Rendering;
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

        public void Add(Credential credential,long JSID)
        {
            _context.Credentials.Add(credential);
            _context.SaveChanges();
            var Js = _context.JobSeekers.Find(JSID);
            Js.CredentialId = credential.Id;
            _context.JobSeekers.Update(Js);
            _context.SaveChanges();
        }
        public List<SelectListItem> ListOfEduLvl()
        {

            var clist = _context.EducationLevels.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.EducationLevelName
            }).ToList();
            clist.Insert(0, new SelectListItem()
            {
                Text = "----Select Edu Lvl----",
                Value = string.Empty
            });
            return clist;

        }
        public void Delete(long id)
        {
            var data = GetById(id);
            _context.Credentials.Remove(data);
            _context.SaveChanges();
        }

        public List<Credential> GetAll()
        {
            var result = _context.Credentials.
                Include(el=>el.EducationLevel).
                ToList();
            return result;
        }

        public Credential GetById(long id)
        {
            var data = _context.Credentials.
                Include(el => el.EducationLevel).FirstOrDefault(x=>x.Id==id);
            return data;
        }

        public void Update(long id, Credential credential)
        {
            _context.Credentials.Update(credential);
            _context.SaveChanges();
        }
    }
}
