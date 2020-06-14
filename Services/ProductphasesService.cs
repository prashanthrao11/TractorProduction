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
    public class ProductPhasesService : BaseService, IProductPhaseRepository
    {
       

        public ProductPhasesService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddProductPhase(ProductPhase productphase)
        {
            try
            {
                productphase.Phase_Key = productphase.Phase_Name.Replace(" ", "_");
                if (productphase.Product_Phase_ID != 0)
                {
                    var item = _context.ProductPhase.Find(productphase.Product_Phase_ID);
                    item.Phase_Name = productphase.Phase_Name;
                    item.Is_Active = productphase.Is_Active;
                }
                else
                {

                    await _context.ProductPhase.AddAsync(productphase);
                }
                await _context.SaveChangesAsync();
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = productphase.Product_Phase_ID
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

        public Task<Response<int>> DeleteProductPhase(int? productphaseID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ProductPhase>> GetProductPhaseById(int? productphaseId)
        {
            try
            {
                var model = await _context.ProductPhase.Where(x => x.Product_Phase_ID == productphaseId).FirstOrDefaultAsync();
                return new Response<ProductPhase>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<ProductPhase>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<ProductPhase>>> GetProductPhases()
        {
            try
            {
                var model = await _context.ProductPhase.ToListAsync();
                return new Response<List<ProductPhase>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<ProductPhase>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateProductPhase(ProductPhase productphase)
        {
            throw new NotImplementedException();
        }
    }
}
