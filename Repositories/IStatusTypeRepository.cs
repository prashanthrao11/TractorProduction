using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
   public interface IStatusTypeRepository : IDisposable
    {
        Task<Response<List<StatusType>>> GetStatusTypes();
        Task<Response<StatusType>> GetStatusTypeById(int? statustypeId);
       
        Task<Response<int>> AddStatusType(StatusType statustype);
        Task<Response<int>> DeleteStatusType(int? statustypeId);
        Task<Response<bool>> UpdateStatusType(StatusType statustype);
    }
}
