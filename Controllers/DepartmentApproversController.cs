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
    public class DepartmentApproversController : ControllerBase
    {
        readonly IDepartmentApproverRepository _repository;
        public DepartmentApproversController(IDepartmentApproverRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/DepartmentApprover/2
        [HttpGet("DepartmentApprovers/{id}")]
        public async Task<ActionResult> GetDepartmentApproversById(int id)
        {
            try
            {
                var result = await _repository.GetDepartmentApprovers(id);
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
        #region PUT: api/DepartmentApprovers
        [HttpPost("DepartmentApprovers")]
        public async Task<ActionResult> UpdateDepartmentApprovers([FromBody]DepartmentApproversVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateDepartmentApprovers(model);
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