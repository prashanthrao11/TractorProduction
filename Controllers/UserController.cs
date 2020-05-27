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
    public class UserController : ControllerBase
    {
        readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        #region GET: api/Department
        [HttpGet("User")]
        public async Task<ActionResult<IEnumerable<UserVM>>> Get()
        {
            try
            {
                var result = await _repository.GetUsers();
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
        #region GET: api/CurrentUser
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserVM>> GetCurrentUser()
        {
            try
            {
                var result = await _repository.CurrentUser();
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
        #region GET: api/User/2
        [HttpGet("User/{id}")]
        public async Task<ActionResult<IEnumerable<UserVM>>> GetById(int id)
        {
            try
            {
                var result = await _repository.GetUserById(id);
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
        #region POST: api/ProjectMilestone
        [HttpPost("User")]
        public async Task<ActionResult<User>> SaveUser(UserVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var milestoneId = await _repository.AddUser(model);

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
    }
}