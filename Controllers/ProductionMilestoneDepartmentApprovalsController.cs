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
    public class ProductionMilestoneDepartmentApprovalsController : ControllerBase
    {
        readonly IProductionMilestoneDepartmentApprovalRepository _repository;
        public ProductionMilestoneDepartmentApprovalsController(IProductionMilestoneDepartmentApprovalRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/ProductionMilestoneDepartmentApproval
        [HttpGet("ProductionMilestoneDepartmentApproval")]
        public async Task<ActionResult<IEnumerable<ProductionMilestoneDepartmentApproval>>> Get()
        {
            try
            {
                var result = await _repository.GetProductionMilestoneDepartmentApprovals();
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
        #region GET: api/ProductionMilestoneDepartmentApproval/2
        [HttpGet("ProductionMilestoneDepartmentApproval/{id}")]
        public async Task<ActionResult<IEnumerable<ProductionMilestoneDepartmentApproval>>> GetById(int id)
        {
            try
            {
                var result = await _repository.GetProductionMilestoneDepartmentApprovalById(id);
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
        public async Task<ActionResult<ProductionMilestoneDepartmentApproval>> UpdateProjectMilestone([FromBody]ProductionMilestoneDepartmentApproval model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateProductionMilestoneDepartmentApproval(model);
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
        [HttpPost("Production")]
        public async Task<ActionResult<ProductionMilestoneDepartmentApproval>> AddProjectMilestone(ProductionMilestoneDepartmentApproval model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var milestoneId = await _repository.AddProductionMilestoneDepartmentApproval(model);

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
        public async Task<ActionResult<ProductionMilestoneDepartmentApproval>> Delete(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _repository.DeleteProductionMilestoneDepartmentApproval(id);
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