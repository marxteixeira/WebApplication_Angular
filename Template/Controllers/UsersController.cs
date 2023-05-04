using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Interfaces;
using Template.Application.ViewModels;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(this.userService.Get());
        }

        [HttpPost]
        public IActionResult Post(UserViewModel userViewModel)
        {
            return Ok(this.userService.Post(userViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById (string id)
        {
            return Ok(this.userService.GetById(id));
        }

        [HttpPut]
        public IActionResult Put(UserViewModel userViewModel)
        {
            return Ok(this.userService.Put(userViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.userService.Delete(id));
        }

        [HttpPost("authenticate"),AllowAnonymous]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {
            return Ok(this.userService.Authenticate(userViewModel));
        }
    }
}
