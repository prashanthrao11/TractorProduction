using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionMilestoneDepartmentApprovalRepository
    {
        Task<List<ProductionMilestoneDepartmentApproval>> GetProductionMilestoneDepartmentApprovals();
        Task<ProductionMilestoneDepartmentApproval> GetProductionMilestoneDepartmentApprovalById(int? productionmilestonedepartmentapprovalID);
       
        Task<int> AddProductionMilestoneDepartmentApproval(ProductionMilestoneDepartmentApproval productionmilestonedepartmentapproval);
        Task<int> DeleteProductionMilestoneDepartmentApproval(int? productionmilestonedepartmentapprovalID);
        Task UpdateProductionMilestoneDepartmentApproval(ProductionMilestoneDepartmentApproval productionmilestonedepartmentapproval);
    }
}
