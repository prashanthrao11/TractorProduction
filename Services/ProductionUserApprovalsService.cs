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
    public class ProductionUserApprovalsService : IProductionUserApprovalRepository
    {
        private readonly APIContext _context;
        private readonly UserService _userService;
        public ProductionUserApprovalsService(APIContext context)
        {
            _context = context;
            _userService = new UserService(context);
        }
        public async Task<int> AddProductionUserApproval(ProductionUserApproval productionuserapproval)
        {
            if (_context != null)
            {
                if (productionuserapproval.P_U_Approval_ID != 0)
                {
                    var item = _context.ProductionUserApproval.Find(productionuserapproval.P_U_Approval_ID);
                    item.Comments = productionuserapproval.Comments;
                    item.Status_ID = productionuserapproval.Status_ID;
                    item.Submitted_By_ID = _userService.GetCurrentUser().User_ID;
                    await _context.SaveChangesAsync();
                    return productionuserapproval.P_U_Approval_ID;
                }
            }
            return 0;
        }

        public Task<int> DeleteProductionUserApproval(int? productionuserapprovalID)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductionUserApproval> GetProductionUserApprovalById(int? productionId)
        {
            if (_context != null)
            {
                int userRoleId = _userService.GetCurrentUser().Role_ID;
                return await _context.ProductionUserApproval.Where(x => x.Production_ID == productionId && x.Role_ID==_userService.GetCurrentUser().Role_ID).FirstOrDefaultAsync();
            }
            return null;
        }
        public async Task<ProductionUserApproval> GetProductionUserApprovalByUserId(int? productionId)
        {
            if (_context != null)
            {
                
                return await _context.ProductionUserApproval.Where(x => x.Production_ID == productionId && x.Role_ID==_userService.GetCurrentUser().Role_ID).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<ProductionUserApproval>> GetProductionUserApprovals(int productionId)
        {
            if (_context != null)
            {
                return await _context.ProductionUserApproval.Where(x=>x.Production_ID==productionId).ToListAsync();
            }
            return null;
        }

        public async Task<int> UpdateProductionUserApproval(ProductionUserApproval productionuserapproval)
        {
            if (_context != null)
            {
                if (productionuserapproval.P_U_Approval_ID != 0)
                {
                    var item = _context.ProductionUserApproval.Find(productionuserapproval.P_U_Approval_ID);
                    item.Comments = productionuserapproval.Comments;
                    item.Status_ID = productionuserapproval.Status_ID;
                    item.Submitted_By_ID = _userService.GetCurrentUser().User_ID;
                    await _context.SaveChangesAsync();
               

                CheckAndUpdateStatus(productionuserapproval.Production_ID);

                return productionuserapproval.P_U_Approval_ID;
                }
            }
            return 0;
        }
        private void CheckAndUpdateStatus(int id)
        {
            if (_context.ProductionUserApproval.Where(x => x.Production_ID == id && x.Status_ID == 0).Count() == 0)
            {
                var production = _context.Production.Where(x => x.Production_ID == id).First();
                production.Status_ID = _context.Status.Where(x => x.Status_Key == "Approved").First().Status_ID;
                production.Modified_By = _userService.GetCurrentUser().User_Name;
                production.Modified_Date = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
