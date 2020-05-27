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
        [HttpGet("ProductionFinalApprovals/{id}")]
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
        [HttpPost("ProductionFinalApproval")]
        public async Task<ActionResult<ProductionFinalApproval>> UpdateProductionFinalApproval([FromBody]ProductionFinalApproval model)
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
    }
}