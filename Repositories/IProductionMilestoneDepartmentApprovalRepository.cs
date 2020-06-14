using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionMilestoneDepartmentApprovalRepository : IDisposable
    {
        Task<Response<List<ProductionMilestoneDepartmentApproval>>> GetProductionMilestoneDepartmentApprovals();
        Task<Response<ProductionMilestoneDepartmentApproval>> GetProductionMilestoneDepartmentApprovalById(int? productionmilestonedepartmentapprovalID);
       
        Task<Response<int>> AddProductionMilestoneDepartmentApproval(ProductionMilestoneDepartmentApproval productionmilestonedepartmentapproval);
        Task<Response<int>> DeleteProductionMilestoneDepartmentApproval(int? productionmilestonedepartmentapprovalID);
        Task<Response<bool>> UpdateProductionMilestoneDepartmentApproval(ProductionMilestoneDepartmentApproval productionmilestonedepartmentapproval);
    }
}
