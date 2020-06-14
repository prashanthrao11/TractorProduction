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
    public class StatusController : ControllerBase
    {
        readonly IStatusRepository _repository;
        public StatusController(IStatusRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/Status
        [HttpGet("Status")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.GetStatuss();
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
        #region GET: api/Status/2
        [HttpGet("Status/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetStatusById(id);
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
        public async Task<ActionResult> UpdateProjectMilestone([FromBody]Status model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateStatus(model);
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
        [HttpPost("Status")]
        public async Task<ActionResult> AddProjectMilestone(Status model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _repository.AddStatus(model));
            }
            return BadRequest();
        }
        #endregion

        #region DELETE: api/ProjectMilestone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            return Ok(await _repository.DeleteStatus(id));
        }
        #endregion
    }
}