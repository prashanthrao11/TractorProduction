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
    public class ProductionApprovalsController : ControllerBase
    {
        readonly IProductionApprovalRepository _repository;
        public ProductionApprovalsController(IProductionApprovalRepository repository)
        {
            _repository = repository;
        }

        
        #region GET: api/ProductionApproval/2
        [HttpGet("ProductionApproval/{id}")]
        public async Task<ActionResult<IEnumerable<ProductionApproval>>> GetById(int id)
        {
            try
            {
                var result = await _repository.GetProductionApprovals(id);
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
        #region GET: api/ProductionApproval/2
        [HttpGet("ProductionUserApproval/{id}")]
        public async Task<ActionResult<IEnumerable<ProductionApproval>>> GetUserById(int id)
        {
            try
            {
                var result = await _repository.GetProductionUserApprovals(id);
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
        [HttpPost("ProductionApproval")]
        public async Task<ActionResult<ProductionApproval>> UpdateProjectMilestone(ProductionApprovalVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var milestoneId = await _repository.UpdateProductionApprovals(model);

                    if (milestoneId > 0)
                    {
                        return Ok(milestoneId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message, ex);
                }
            }
            return BadRequest();
        }
        #endregion
    }
}