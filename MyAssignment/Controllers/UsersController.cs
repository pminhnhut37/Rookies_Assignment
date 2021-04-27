using Assignment.Shared.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAssignment.Data;
using MyAssignment.Respositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRespo _userRespo;
        public UsersController(IUserRespo userRespo)
        {
            _userRespo = userRespo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUser()
        {
            var user = await _userRespo.GetUser();

            return Ok(user);
        }
    }
}
