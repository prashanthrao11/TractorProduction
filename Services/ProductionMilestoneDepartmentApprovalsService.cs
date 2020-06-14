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
    public class ProductionMilestoneDepartmentApprovalsService : BaseService, IProductionMilestoneDepartmentApprovalRepository
    {
      

        public ProductionMilestoneDepartmentApprovalsService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddProductionMilestoneDepartmentApproval(ProductionMilestoneDepartmentApproval productionmilestonedepartmentapproval)
        {
            try
            {
                await _context.ProductionMilestoneDepartmentApproval.AddAsync(productionmilestonedepartmentapproval);
                await _context.SaveChangesAsync();
                var model= productionmilestonedepartmentapproval.P_D_ID;

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

        public Task<Response<int>> DeleteProductionMilestoneDepartmentApproval(int? productionmilestonedepartmentapprovalID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ProductionMilestoneDepartmentApproval>> GetProductionMilestoneDepartmentApprovalById(int? productionmilestonedepartmentapprovalID)
        {
            try
            {
                var model = await _context.ProductionMilestoneDepartmentApproval.Where(x => x.P_D_ID == productionmilestonedepartmentapprovalID).FirstOrDefaultAsync();
                return new Response<ProductionMilestoneDepartmentApproval>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<ProductionMilestoneDepartmentApproval>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<ProductionMilestoneDepartmentApproval>>> GetProductionMilestoneDepartmentApprovals()
        {
            try
            {
                var model = await _context.ProductionMilestoneDepartmentApproval.ToListAsync();
                return new Response<List<ProductionMilestoneDepartmentApproval>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<ProductionMilestoneDepartmentApproval>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateProductionMilestoneDepartmentApproval(ProductionMilestoneDepartmentApproval productionmilestonedepartmentapproval)
        {
            throw new NotImplementedException();
        }
    }
}
