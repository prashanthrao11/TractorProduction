using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductPhaseRepository
    {
        Task<List<ProductPhase>> GetProductPhases();
        Task<ProductPhase> GetProductPhaseById(int? productphaseId);
       
        Task<int> AddProductPhase(ProductPhase productphase);
        Task<int> DeleteProductPhase(int? productphaseID);
        Task UpdateProductPhase(ProductPhase productphase);
    }
}
