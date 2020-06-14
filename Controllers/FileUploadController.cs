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
    public class FileUploadController : ControllerBase
    {
        public readonly IAttachmentRepository _repository;
        public FileUploadController(IAttachmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("MilestoneAttachments/{id}")]
        public async Task<ActionResult> GetProductionMilestoneAttachments(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _repository.GetProductionMilestoneAttachments(id);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message, ex);
                }
            }
            return BadRequest();
        }
        [HttpPost("MilestoneAttachment")]
        public async Task<ActionResult> Delete([FromBody]AttachmentHeader model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.DeleteDoc(model);
                    return Ok(model);
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message, ex);
                }
            }
            return BadRequest();
        }

        #region POST: api/FileUpload/Upload
        [HttpPost("Upload")]
        public async Task<ActionResult> FileUploadSave([FromBody]AttachmentDoc model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UploadDoc(model);
                    return Ok(model);
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message, ex);
                }
            }
            return BadRequest();
        }
        #endregion
    }
}