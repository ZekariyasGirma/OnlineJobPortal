using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineJobPortal.Models.Services
{
    public interface IAdminService
    {
        List<Company> GetAllCompany();
        List<JobSeeker> GetAllJobSeeker();
        bool AccountExists(string username, string password);
        Admin GetByUserAndPass(string username, string password);
    }
}
