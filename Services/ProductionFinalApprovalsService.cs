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
    public class ProductionFinalApprovalsService : IProductionFinalApprovalRepository
    {
        private readonly APIContext _context;
        public ProductionFinalApprovalsService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddProductionFinalApproval(ProductionFinalApproval productionfinalapproval)
        {
            if (_context != null)
            {
                await _context.ProductionFinalApproval.AddAsync(productionfinalapproval);
                await _context.SaveChangesAsync();
                return productionfinalapproval.Final_Approval_ID;
            }
            return 0;
        }

        public Task<int> DeleteProductionFinalApproval(int? productionfinalapprovalID)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductionFinalApproval> GetProductionFinalApprovalById(int? productionfinalapprovalID)
        {
            if (_context != null)
            {
                return await _context.ProductionFinalApproval.Where(x => x.Final_Approval_ID == productionfinalapprovalID).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<ProductionFinalApproval>> GetProductionFinalApprovals()
        {
            if (_context != null)
            {
                return await _context.ProductionFinalApproval.ToListAsync();
            }
            return null;
        }

        public Task UpdateProductionFinalApproval(ProductionFinalApproval productionFinalapproval)
        {
            throw new NotImplementedException();
        }
    }
}
