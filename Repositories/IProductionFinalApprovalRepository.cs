using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IProductionFinalApprovalRepository
    {
        Task<List<ProductionFinalApproval>> GetProductionFinalApprovals();
        Task<ProductionFinalApproval> GetProductionFinalApprovalById(int? productionfinalapprovalID);
        Task<int> AddProductionFinalApproval(ProductionFinalApproval productionfinalapproval);
        Task<int> DeleteProductionFinalApproval(int? productionfinalapprovalID);
        Task UpdateProductionFinalApproval(ProductionFinalApproval productionFinalapproval);
    }
}
