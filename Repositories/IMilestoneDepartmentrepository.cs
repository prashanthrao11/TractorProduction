using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IMilestoneDepartmentrepository
    {
        Task<List<MilestoneDepartment>> GetMilestoneDepartments();
        Task<MilestoneDepartment> GetMilestoneDepartmentById(int? milestonedepartmentID);
        
        Task<int> AddMilestoneDepartment(MilestoneDepartment milestonedepartment);
        Task<int> DeleteMilestoneDepartment(int? milestonedepartmentID);
        Task UpdateMilestoneDepartment(MilestoneDepartment milestonedepartment);
    }
}
