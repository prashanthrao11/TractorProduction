﻿using System;
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
    public class ProductionController : ControllerBase
    {
        readonly IProductionRepository _repository;
        public ProductionController(IProductionRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/Production
        [HttpGet("Production")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.GetProductions();
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
        #region GET: api/Production/2
        [HttpGet("Production/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetProductionById(id);
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
        public async Task<ActionResult> UpdateProjectMilestone([FromBody]Production model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateProduction(model);
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
        public async Task<ActionResult> AddProjectMilestone(Production model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _repository.AddProduction(model));
            }
            return BadRequest();
        }
        #endregion
        #region POST: api/ProjectMilestone
        [HttpPost("ProductionSearch")]
        public async Task<ActionResult> Search(Production model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productions = await _repository.SearchProduction(model);

                    if (productions!=null)
                    {
                        return Ok(productions);
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
        public async Task<ActionResult> Delete(int? id)
        {
            return Ok(await _repository.DeleteProduction(id));
        }
        #endregion
    }
}