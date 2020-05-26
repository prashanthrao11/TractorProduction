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
    public class ProductionFinalApprovalsController : ControllerBase
    {
        readonly IProductionFinalApprovalRepository _repository;
        public ProductionFinalApprovalsController(IProductionFinalApprovalRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/ProductionFinalApproval
        [HttpGet("ProductionFinalApproval")]
        public async Task<ActionResult<IEnumerable<ProductionFinalApproval>>> Get()
        {
            try
            {
                var result = await _repository.GetProductionFinalApprovals();
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
        #region GET: api/ProductionFinalApproval/2
        [HttpGet("ProductionFinalApproval/{id}")]
        public async Task<ActionResult<IEnumerable<ProductionFinalApproval>>> GetById(int id)
        {
            try
            {
                var result = await _repository.GetProductionFinalApprovalById(id);
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
        public async Task<ActionResult<ProductionFinalApproval>> UpdateProjectMilestone([FromBody]ProductionFinalApproval model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateProductionFinalApproval(model);
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
        [HttpPost("ProductionFinalApproval")]
        public async Task<ActionResult<ProductionFinalApproval>> AddProjectMilestone(ProductionFinalApproval model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var milestoneId = await _repository.AddProductionFinalApproval(model);

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
        public async Task<ActionResult<ProductionFinalApproval>> Delete(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _repository.DeleteProductionFinalApproval(id);
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