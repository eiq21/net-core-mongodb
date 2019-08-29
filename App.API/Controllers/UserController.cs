using System.Threading.Tasks;
using App.API.Filters;
using App.API.ViewModel.User;
using App.Model;
using App.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ValidateModel]
        public async Task<IActionResult> Authenticate([FromBody]LoginViewModel userVM)
        {
            var user = await _userService.Authenticate(userVM.Username, userVM.Password);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel userVM)
        {
            var user = new User();
            Mapper.Map(userVM, user);
            await _userService.Register(user);
            Mapper.Map(user, userVM);
            return Created(Url.Link("Default", new { controller = "User", id = user.Id.ToString() }), userVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
    }
}