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
    public class WorkflowController : ControllerBase
    {
        readonly IWorkflowRepository _repository;
        public WorkflowController(IWorkflowRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/Workflow
        [HttpGet("Workflow")]
        public async Task<ActionResult<IEnumerable<Workflow>>> Get()
        {
            try
            {
                var result = await _repository.GetWorkflows();
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
        #region GET: api/Workflow/2
        [HttpGet("Workflow/{id}")]
        public async Task<ActionResult<IEnumerable<Workflow>>> GetById(int id)
        {
            try
            {
                var result = await _repository.GetWorkflowById(id);
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
        public async Task<ActionResult<Workflow>> UpdateProjectMilestone([FromBody]Workflow model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateWorkflow(model);
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
        [HttpPost("Workflow")]
        public async Task<ActionResult<Production>> AddProjectMilestone(Workflow model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var milestoneId = await _repository.AddWorkflow(model);

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
        public async Task<ActionResult<Workflow>> Delete(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _repository.DeleteWorkflow(id);
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