using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductPhaseRepository : IDisposable
    {
        Task<Response<List<ProductPhase>>> GetProductPhases();
        Task<Response<ProductPhase>> GetProductPhaseById(int? productphaseId);
       
        Task<Response<int>> AddProductPhase(ProductPhase productphase);
        Task<Response<int>> DeleteProductPhase(int? productphaseID);
        Task<Response<bool>> UpdateProductPhase(ProductPhase productphase);
    }
}
