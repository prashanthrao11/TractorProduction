using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TractorProduction.Web.Models;
using TractorProduction.Web.Repositories;

namespace TractorProduction.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionUserApprovalsController : ControllerBase
    {
        readonly IProductionUserApprovalRepository _repository;
        public ProductionUserApprovalsController(IProductionUserApprovalRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/Production
        [HttpGet("Production")]
        public async Task<ActionResult<IEnumerable<ProductionUserApproval>>> Get()
        {
            try
            {
                var result = await _repository.GetProductionUserApprovals();
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
        #region GET: api/ProductionUserApproval/2
        [HttpGet("ProductionUserApproval/{id}")]
        public async Task<ActionResult<IEnumerable<ProductionUserApproval>>> GetById(int id)
        {
            try
            {
                var result = await _repository.GetProductionUserApprovalById(id);
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
        #region PUT: api/ProjectMilestone
        [HttpPut]
        public async Task<ActionResult<ProductionUserApproval>> UpdateProjectMilestone([FromBody]ProductionUserApproval model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateProductionUserApproval(model);
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
        #region POST: api/ProjectMilestone
        [HttpPost("ProductionUserApproval")]
        public async Task<ActionResult<ProductionUserApproval>> AddProjectMilestone(ProductionUserApproval model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var milestoneId = await _repository.AddProductionUserApproval(model);

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

        #region DELETE: api/ProjectMilestone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductionUserApproval>> Delete(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _repository.DeleteProductionUserApproval(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw new JsonException(ex.Message, ex);
            }
        }
        #endregion
    }
}