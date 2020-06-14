using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionUserApprovalRepository : IDisposable
    {
        Task<Response<List<ProductionUserApproval>>> GetProductionUserApprovals(int productionId);
        Task<Response<ProductionUserApproval>> GetProductionUserApprovalById(int? productionuserapprovalID);
        Task<Response<ProductionUserApproval>> GetProductionUserApprovalByUserId(int? productionId);

        Task<Response<int>> AddProductionUserApproval(ProductionUserApproval productionuserapproval);
        Task<Response<int>> DeleteProductionUserApproval(int? productionuserapprovalID);
        Task<Response<int>> UpdateProductionUserApproval(ProductionUserApproval productionuserapproval);
    }
}

