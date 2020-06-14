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
    public class ProductionUserApprovalsService : BaseService, IProductionUserApprovalRepository
    {

        public ProductionUserApprovalsService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddProductionUserApproval(ProductionUserApproval productionuserapproval)
        {
            try
            {
                if (productionuserapproval.P_U_Approval_ID != 0)
                {
                    var item = _context.ProductionUserApproval.Find(productionuserapproval.P_U_Approval_ID);
                    item.Comments = productionuserapproval.Comments;
                    item.Status_ID = productionuserapproval.Status_ID;
                    item.Submitted_By_ID = _user.GetCurrentUser().User_ID;
                    await _context.SaveChangesAsync();
                }
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = productionuserapproval.P_U_Approval_ID
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<int>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<int>> DeleteProductionUserApproval(int? productionuserapprovalID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ProductionUserApproval>> GetProductionUserApprovalById(int? productionId)
        {
            try
            {
                int userRoleId = _user.GetCurrentUser().Role_ID;
                var model = await _context.ProductionUserApproval.Where(x => x.Production_ID == productionId && x.Role_ID == _user.GetCurrentUser().Role_ID).FirstOrDefaultAsync();
                return new Response<ProductionUserApproval>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<ProductionUserApproval>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response<ProductionUserApproval>> GetProductionUserApprovalByUserId(int? productionId)
        {
            try
            {
                var model = await _context.ProductionUserApproval.Where(x => x.Production_ID == productionId && x.Role_ID == _user.GetCurrentUser().Role_ID).FirstOrDefaultAsync();
                return new Response<ProductionUserApproval>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<ProductionUserApproval>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<ProductionUserApproval>>> GetProductionUserApprovals(int productionId)
        {
            try
            {
                var model = await _context.ProductionUserApproval.Where(x => x.Production_ID == productionId).ToListAsync();
                return new Response<List<ProductionUserApproval>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<ProductionUserApproval>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<int>> UpdateProductionUserApproval(ProductionUserApproval productionuserapproval)
        {
            try
            {
                if (productionuserapproval.P_U_Approval_ID != 0)
                {
                    var item = _context.ProductionUserApproval.Find(productionuserapproval.P_U_Approval_ID);
                    item.Comments = productionuserapproval.Comments;
                    item.Status_ID = productionuserapproval.Status_ID;
                    item.Submitted_By_ID = _user.GetCurrentUser().User_ID;
                    item.Modified_By = _user.GetCurrentUser().User_Name;
                    item.Modified_Date = DateTime.Now;
                    await _context.SaveChangesAsync();

                    CheckAndUpdateStatus(productionuserapproval.Production_ID);
                    return new Response<int>()
                    {
                        IsSuccess = true,
                        Model = productionuserapproval.P_U_Approval_ID
                    };
                }

                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = 0
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<int>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        private void CheckAndUpdateStatus(int id)
        {
            if (_context.ProductionUserApproval.Where(x => x.Production_ID == id && x.Status_ID == 0).Count() == 0)
            {
                var production = _context.Production.Where(x => x.Production_ID == id).First();
                production.Status_ID = _context.Status.Where(x => x.Status_Key == "Approved").First().Status_ID;
                production.Modified_By = _user.GetCurrentUser().User_Name;
                production.Modified_Date = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
