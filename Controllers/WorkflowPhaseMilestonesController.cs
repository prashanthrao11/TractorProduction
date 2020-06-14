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
    public class WorkflowPhaseMilestonesController : ControllerBase
    {
        readonly IWorkflowPhaseMilestoneRepository _repository;
        public WorkflowPhaseMilestonesController(IWorkflowPhaseMilestoneRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/WorkflowPhaseMilestone
        [HttpGet("WorkflowPhaseMilestone")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.GetWorkflowPhaseMilestones();
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
        #region GET: api/WorkflowPhaseMilestone/2
        [HttpGet("WorkflowPhaseMilestone/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetWorkflowPhaseMilestoneById(id);
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
        public async Task<ActionResult> UpdateProjectMilestone([FromBody]MilestoneManageVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateWorkflowPhaseMilestone(model);
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
        [HttpPost("WorkflowPhaseMilestone")]
        public async Task<ActionResult> AddProjectMilestone(MilestoneManageVM model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _repository.AddWorkflowPhaseMilestone(model));
            }
            return BadRequest();
        }
        #endregion

        #region DELETE: api/ProjectMilestone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            return Ok(await _repository.DeleteWorkflowPhaseMilestone(id));
        }
        #endregion
    }
}