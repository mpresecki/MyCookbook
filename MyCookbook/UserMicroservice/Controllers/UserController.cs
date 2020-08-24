using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserMicroserviceAPI.Business.Models;
using UserMicroserviceAPI.Business.Services;
using UserMicroserviceAPI.Data.Entities;
using UserMicroserviceAPI.Helpers;

namespace UserMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<UserListModel>> GetUsersAsync()
        {
            return await _service.GetAllUsersAsync();
        }

        [HttpGet]
        [Route("{userId:long}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<UserModel> GetUserByIdAsync(long userId)
        {
            return await _service.GetUserById(userId);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task AddUserAsync(UserInsertModel user)
        {
            await _service.InsertUser(user);
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _service.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


        [HttpPut]
        public async Task UpdateUserAsync(UserListModel user)
        {
            await _service.UpdateUser(user);
        }

        [HttpDelete]
        [Route("{userId:long}")]
        public async Task DeleteUserAsync(long userId)
        {
            await _service.DeleteUser(userId);
        }
    }
}
