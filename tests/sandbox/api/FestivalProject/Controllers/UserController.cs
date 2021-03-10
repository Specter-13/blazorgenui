using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Helpers;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.UserDto;
using FestivalProject.BL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FestivalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserFacade _facade;
        private readonly IUserAuthenticationService _authentication;

        public UserController(UserFacade facade, IUserAuthenticationService authentication)
        {
            _facade = facade;
            _authentication = authentication;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_facade.GetAll());

        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {

            var returnedItem = _facade.GetById(id);
            if (returnedItem == null) return NotFound();
            return Ok(returnedItem);

        }


        [HttpPost]
        public IActionResult Create([FromBody] UserCreateEditDto item)
        {
            var returnedItem = _facade.Create(item);
            if (returnedItem == null)
                return BadRequest();

            return Ok(returnedItem);


        }

        [HttpPut]
        public IActionResult Update([FromBody] UserCreateEditDto item)
        {
            try
            {
                return Ok(_facade.Update(item));
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _facade.Delete(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser([FromBody] UserAuthenticateDto item)
        {

            var response = _authentication.Authenticate(item);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);

        }
        
        [HttpGet("password/{id}")]
        public IActionResult GetPassword(Guid id)
        {
            try
            {

                return Ok(_facade.GetUserPassword(id));
            }
            catch
            {
                return BadRequest();
            }

        }

        [Authorize]
        [HttpGet("validate")]
        public IActionResult ValidateToken()
        {

            return Ok();

        }
    }
}
