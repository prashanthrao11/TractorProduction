using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface ILogDetailsRepository
    {
        Task<List<LogDetails>> GetLogDetails();
        Task<LogDetails> GetLogDetailsById(int? logdetailsId);
       
        Task<int> AddLogDetails(LogDetails logdetails);
        Task<int> DeleteLogDetails(int? logdetailsId);
        Task UpdateLogDetails(LogDetails logdetails);
    }
}
