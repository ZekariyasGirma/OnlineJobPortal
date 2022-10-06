using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public interface ICredentialService
    {
        List<Credential> GetAll();
        void Add(Credential credential,long JSID);
        Credential GetById(long id);
        void Update (long id, Credential credential);
        void Delete(long id);
        public List<SelectListItem> ListOfEduLvl();
    }
}
