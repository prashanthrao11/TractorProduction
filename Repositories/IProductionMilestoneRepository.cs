using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IProductionMilestoneRepository
    {
        Task<List<ProductionMilestoneVM>> GetProductionMilestones(int productionId);
      
        Task<int> UpdateProductionMilestone(ProductionMilestonesVM list);
    }
}
