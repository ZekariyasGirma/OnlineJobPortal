using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models.Services
{
    public interface ICredentialService
    {
        List<Credential> GetAll();
        void Add(Credential credential);
        Credential GetById(long id);
        Credential Update(long id, Credential credential);
        void Delete(long id);
    }
}
