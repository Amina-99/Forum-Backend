using ForumTask.Models;
using ForumTask.Models.DTOs;
using ForumTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFromDb(int page, int pagesize = 5)
        {
            var users = await _userService.GetUsersFromDb(page, pagesize);
            return Ok(users);
        }
    }
}
