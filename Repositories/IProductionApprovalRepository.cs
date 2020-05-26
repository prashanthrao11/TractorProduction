using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionApprovalRepository
    {
        Task<List<ProductionApproval>> GetProductionUserApprovals(int productionId);
        Task<List<ProductionApproval>> GetProductionApprovals(int productionId);
        Task<int> UpdateProductionApprovals(ProductionApprovalVM model);
    }
}
