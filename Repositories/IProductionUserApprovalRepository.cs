using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionUserApprovalRepository
    {
        Task<List<ProductionUserApproval>> GetProductionUserApprovals();
        Task<ProductionUserApproval> GetProductionUserApprovalById(int? productionuserapprovalID);
        Task<ProductionUserApproval> GetProductionUserApprovalByUserId(int? productionId);

        Task<int> AddProductionUserApproval(ProductionUserApproval productionuserapproval);
        Task<int> DeleteProductionUserApproval(int? productionuserapprovalID);
        Task UpdateProductionUserApproval(ProductionUserApproval productionuserapproval);
    }
}

