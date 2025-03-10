using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportify.core.cs;
using sportify.Datalayer.Interfaces;

namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly Iusers _iusers;


        public UsersController(Iusers iusers)
        {
            _iusers = iusers;
        }



        [HttpGet("Get-all-users")]

        public async Task<ActionResult<Users>> GetAllUsers()
        {
            try
            {
                var users = await _iusers.GetAllUsers();
                return Ok(users);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }



        [HttpDelete("Delete-User/{id}")]
        public async Task<IActionResult> DeleteUsers(int number)
        {
            try
            {
                var userDeleted = await _iusers.DeleteUser(number);

                if (userDeleted)
                {
                    return Ok(new { success = true, message = "User deleted successfully." });
                }
                else
                {
                    return NotFound(new { success = false, message = "User not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred.", error = ex.Message });
            }
        }







    }

}
