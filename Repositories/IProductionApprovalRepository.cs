using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionApprovalRepository : IDisposable
    {
        Task<Response<List<ProductionApproval>>> GetProductionUserApprovals(int productionId);
        Task<Response<List<ProductionApproval>>> GetProductionApprovals(int productionId);
        Task<Response<int>> UpdateProductionApprovals(ProductionApprovalVM model);
    }
}
