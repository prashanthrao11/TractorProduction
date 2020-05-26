using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetStatuss();
        Task<Status> GetStatusById(int? statusID);
        
        Task<int> AddStatus(Status status);
        Task<int> DeleteStatus(int? statusID);
        Task UpdateStatus(Status status);
    }
}
