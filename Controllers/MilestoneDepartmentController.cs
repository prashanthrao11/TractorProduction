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
        public async Task<ActionResult<IEnumerable<MilestoneDepartment>>> Get()
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
        public async Task<ActionResult<IEnumerable<MilestoneDepartment>>> GetById(int id)
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
        public async Task<ActionResult<MilestoneDepartment>> UpdateProjectMilestone([FromBody]MilestoneDepartment model)
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
        public async Task<ActionResult<Production>> AddProjectMilestone(MilestoneDepartment model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var milestoneId = await _repository.AddMilestoneDepartment(model);

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
        public async Task<ActionResult<MilestoneDepartment>> Delete(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _repository.DeleteMilestoneDepartment(id);
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