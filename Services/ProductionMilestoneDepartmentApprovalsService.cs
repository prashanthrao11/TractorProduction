using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Data;
using TractorProduction.Web.Models;
using TractorProduction.Web.Repositories;
namespace TractorProduction.Web.Services
{
    public class ProductionMilestoneDepartmentApprovalsService : IProductionMilestoneDepartmentApprovalRepository
    {
        private readonly APIContext _context;
        public ProductionMilestoneDepartmentApprovalsService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddProductionMilestoneDepartmentApproval(ProductionMilestoneDepartmentApproval productionmilestonedepartmentapproval)
        {
            if (_context != null)
            {
                await _context.ProductionMilestoneDepartmentApproval.AddAsync(productionmilestonedepartmentapproval);
                await _context.SaveChangesAsync();
                return productionmilestonedepartmentapproval.P_D_ID;
            }
            return 0;
        }

        public Task<int> DeleteProductionMilestoneDepartmentApproval(int? productionmilestonedepartmentapprovalID)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductionMilestoneDepartmentApproval> GetProductionMilestoneDepartmentApprovalById(int? productionmilestonedepartmentapprovalID)
        {
            if (_context != null)
            {
                return await _context.ProductionMilestoneDepartmentApproval.Where(x => x.P_D_ID == productionmilestonedepartmentapprovalID).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<ProductionMilestoneDepartmentApproval>> GetProductionMilestoneDepartmentApprovals()
        {
            if (_context != null)
            {
                return await _context.ProductionMilestoneDepartmentApproval.ToListAsync();
            }
            return null;
        }

        public Task UpdateProductionMilestoneDepartmentApproval(ProductionMilestoneDepartmentApproval productionmilestonedepartmentapproval)
        {
            throw new NotImplementedException();
        }
    }
}
