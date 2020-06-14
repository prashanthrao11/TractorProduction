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

        #region GET: api/ProductionUserApprovals
        [HttpGet("ProductionUserApprovals/{id}")]
        public async Task<ActionResult> GetProductionUserApprovals(int id)
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
        #region GET: api/ProductionUserApproval/2
        [HttpGet("ProductionUserApproval/{id}")]
        public async Task<ActionResult> GetProductionUserApprovalByUserId(int id)
        {
            try
            {
                var result = await _repository.GetProductionUserApprovalByUserId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new JsonException(ex.Message, ex);
            }
        }
        #endregion
        #region PUT: api/ProjectMilestone
        [HttpPost("ProductionFinalApproval")]
        public async Task<ActionResult> UpdateProductionUserApproval([FromBody]ProductionUserApproval model)
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
      
    }
}