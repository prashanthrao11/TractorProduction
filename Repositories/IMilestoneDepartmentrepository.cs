using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IMilestoneDepartmentrepository : IDisposable
    {
        Task<Response<List<MilestoneDepartment>>> GetMilestoneDepartments();
        Task<Response<MilestoneDepartment>> GetMilestoneDepartmentById(int? milestonedepartmentID);
        
        Task<Response<int>> AddMilestoneDepartment(MilestoneDepartment milestonedepartment);
        Task<Response<int>> DeleteMilestoneDepartment(int? milestonedepartmentID);
        Task<Response<bool>> UpdateMilestoneDepartment(MilestoneDepartment milestonedepartment);
    }
}
