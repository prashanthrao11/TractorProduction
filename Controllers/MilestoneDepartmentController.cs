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
    public class MilestoneDepartmentController : ControllerBase
    {
        readonly IMilestoneDepartmentrepository _repository;
        public MilestoneDepartmentController(IMilestoneDepartmentrepository repository)
        {
            _repository = repository;
        }

        #region GET: api/MilestoneDepartment
        [HttpGet("MilestoneDepartment")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.GetMilestoneDepartments();
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
        #region GET: api/MilestoneDepartment/2
        [HttpGet("MilestoneDepartment/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetMilestoneDepartmentById(id);
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
        public async Task<ActionResult> UpdateProjectMilestone([FromBody]MilestoneDepartment model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateMilestoneDepartment(model);
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
        [HttpPost("MilestoneDepartment")]
        public async Task<ActionResult> AddProjectMilestone(MilestoneDepartment model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _repository.AddMilestoneDepartment(model));
            }
            return BadRequest();
        }
        #endregion

        #region DELETE: api/ProjectMilestone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            return Ok(await _repository.DeleteMilestoneDepartment(id));
        }
        #endregion
    }
}