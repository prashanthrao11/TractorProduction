using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IProductionFinalApprovalRepository : IDisposable
    {
        Task<Response<List<ProductionFinalApproval>>> GetProductionFinalApprovals();
        Task<Response<ProductionFinalApproval>> GetProductionFinalApprovalById(int? productionfinalapprovalID);
        Task<Response<int>> AddProductionFinalApproval(ProductionFinalApproval productionfinalapproval);
        Task<Response<int>> DeleteProductionFinalApproval(int? productionfinalapprovalID);
        Task<Response<bool>> UpdateProductionFinalApproval(ProductionFinalApproval productionFinalapproval);
    }
}
