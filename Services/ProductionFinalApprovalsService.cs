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
    public class ProductionFinalApprovalsService : BaseService, IProductionFinalApprovalRepository
    {
       

        public ProductionFinalApprovalsService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddProductionFinalApproval(ProductionFinalApproval productionfinalapproval)
        {
            try
            {
                await _context.ProductionFinalApproval.AddAsync(productionfinalapproval);
                await _context.SaveChangesAsync();
                var model = productionfinalapproval.Final_Approval_ID;
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = model
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

        public Task<Response<int>> DeleteProductionFinalApproval(int? productionfinalapprovalID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ProductionFinalApproval>> GetProductionFinalApprovalById(int? productionfinalapprovalID)
        {
            try
            {
                var model = await _context.ProductionFinalApproval.Where(x => x.Final_Approval_ID == productionfinalapprovalID).FirstOrDefaultAsync();
                return new Response<ProductionFinalApproval>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<ProductionFinalApproval>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<ProductionFinalApproval>>> GetProductionFinalApprovals()
        {
            try
            {
                var model = await _context.ProductionFinalApproval.ToListAsync();
                return new Response<List<ProductionFinalApproval>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<ProductionFinalApproval>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateProductionFinalApproval(ProductionFinalApproval productionFinalapproval)
        {
            throw new NotImplementedException();
        }
    }
}
