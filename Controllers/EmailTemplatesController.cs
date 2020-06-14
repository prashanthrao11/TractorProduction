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
    public class EmailTemplatesController : ControllerBase
    {
        readonly IEmailTemplateRepository _repository;
        public EmailTemplatesController(IEmailTemplateRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/Production
        [HttpGet("EmailTemplates")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.GetEmailTemplates();
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
        #region GET: api/EmailTemplates/2
        [HttpGet("EmailTemplates/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetEmailTemplateById(id);
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
        public async Task<ActionResult> UpdateProjectMilestone([FromBody]EmailTemplate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateEmailTemplate(model);
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
        [HttpPost("EmailTemplates")]
        public async Task<ActionResult> AddProjectMilestone(EmailTemplate model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _repository.AddEmailTemplate(model));
            }
            return BadRequest();
        }
        #endregion

        #region DELETE: api/ProjectMilestone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            return Ok(await _repository.DeleteEmailTemplate(id));
        }
        #endregion
    }
}