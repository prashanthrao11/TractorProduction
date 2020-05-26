using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
   public interface IStatusTypeRepository
    {
        Task<List<StatusType>> GetStatusTypes();
        Task<StatusType> GetStatusTypeById(int? statustypeId);
       
        Task<int> AddStatusType(StatusType statustype);
        Task<int> DeleteStatusType(int? statustypeId);
        Task UpdateStatusType(StatusType statustype);
    }
}
