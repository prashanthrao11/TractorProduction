using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TractorProduction.Web.Repositories;
using TractorProduction.Web.Models;
using System.Text.Json;

namespace TractorProduction.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionMilestonesController : ControllerBase
    {
        readonly IProductionMilestoneRepository _repository;
        public ProductionMilestonesController(IProductionMilestoneRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/ProductionMilestone/2
        [HttpGet("ProductionMilestones/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetProductionMilestones(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new JsonException(ex.Message, ex);
            }
        }
        #endregion
        #region POST: api/ProjectMilestone
        [HttpPost("ProductionMilestones")]
        public async Task<ActionResult> UpdateProjectMilestone([FromBody]ProductionMilestonesVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateProductionMilestone(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
       
    }
}