using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionRepository
    {
        Task<List<Production>> GetProductions();
        Task<Production> GetProductionById(int? productionID);
        Task<int> AddProduction(Production production);
        Task<List<Production>> SearchProduction(Production production);
        Task<int> DeleteProduction(int? productionID);
        Task UpdateProduction(Production production);
    }
}
