using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionRepository : IDisposable
    {
        Task<Response<List<Production>>> GetProductions();
        Task<Response<Production>> GetProductionById(int? productionID);
        Task<Response<int>> AddProduction(Production production);
        Task<Response<List<Production>>> SearchProduction(Production production);
        Task<Response<int>> DeleteProduction(int? productionID);
        Task<Response<bool>> UpdateProduction(Production production);
    }
}
