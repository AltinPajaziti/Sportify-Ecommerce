using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.core.cs;
using sportify.Datalayer.DTOs;
using sportify.Datalayer.Interfaces;

namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public Authentication _Authentication;


        public AuthenticationController(Authentication Authentication)
        {
            _Authentication = Authentication;
        }




        [HttpPost("Register")]

        public async Task<ActionResult<Users>> Register([FromBody] RegisterDto register)
        {
            if (register == null)
            {
                return BadRequest("register is empty");
            }

            try
            {
                var user = await _Authentication.RegisterAsync(register);

                if(user == null)
                {
                    return BadRequest("The user did not register");
                }

                return Ok(user);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("The username is null");
            }

            try
            {
                var userDto = await _Authentication.LoginAsync(loginDto);

                if (userDto == null)
                {
                    return Unauthorized("Invalid credentials");
                }

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }





    }
}
