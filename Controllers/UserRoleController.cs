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
    public class UserRoleController : ControllerBase
    {
        readonly IUserRoleRepository _repository;
        public UserRoleController(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/UserRole
        [HttpGet("UserRole")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.GetUserRoles();
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
        #region GET: api/UserRole/2
        [HttpGet("UserRole/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await _repository.GetUserRoleById(id);
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
        public async Task<ActionResult> UpdateProjectMilestone([FromBody]UserRole model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateUserRole(model);
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
        [HttpPost("UserRole")]
        public async Task<ActionResult> AddProjectMilestone(UserRole model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _repository.AddUserRole(model));
            }
            return BadRequest();
        }
        #endregion

        #region DELETE: api/ProjectMilestone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            return Ok(await _repository.DeleteUserRole(id));
        }
        #endregion
    }
}