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
    public class ProductPhasesService : IProductPhaseRepository
    {
        private readonly APIContext _context;
        public ProductPhasesService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddProductPhase(ProductPhase productphase)
        {
            if (_context != null)
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
                return productphase.Product_Phase_ID;
            }
            return 0;
        }

        public Task<int> DeleteProductPhase(int? productphaseID)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductPhase> GetProductPhaseById(int? productphaseId)
        {
            if (_context != null)
            {
                return await _context.ProductPhase.Where(x => x.Product_Phase_ID == productphaseId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<ProductPhase>> GetProductPhases()
        {
            if (_context != null)
            {
                return await _context.ProductPhase.ToListAsync();
            }
            return null;
        }

        public Task UpdateProductPhase(ProductPhase productphase)
        {
            throw new NotImplementedException();
        }
    }
}
