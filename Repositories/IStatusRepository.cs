using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IStatusRepository : IDisposable
    {
        Task<Response<List<Status>>> GetStatuss();
        Task<Response<Status>> GetStatusById(int? statusID);
        
        Task<Response<int>> AddStatus(Status status);
        Task<Response<int>> DeleteStatus(int? statusID);
        Task<Response<bool>> UpdateStatus(Status status);
    }
}
