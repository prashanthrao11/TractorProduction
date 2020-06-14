﻿using System;
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
    public class ProductPhasesController : ControllerBase
    {
        readonly IProductPhaseRepository _repository;
        public ProductPhasesController(IProductPhaseRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/ProductPhases
        [HttpGet("ProductPhases")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.GetProductPhases();
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
        #region GET: api/ProductPhases/2
        [HttpGet("ProductPhase/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetProductPhaseById(id);
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
        public async Task<ActionResult> UpdateProjectMilestone([FromBody]ProductPhase model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateProductPhase(model);
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
        [HttpPost("ProductPhase")]
        public async Task<ActionResult> AddProjectMilestone(ProductPhase model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _repository.AddProductPhase(model));
            }
            return BadRequest();
        }
        #endregion

        #region DELETE: api/ProjectMilestone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            return Ok(await _repository.DeleteProductPhase(id));
        }
        #endregion
    }
}