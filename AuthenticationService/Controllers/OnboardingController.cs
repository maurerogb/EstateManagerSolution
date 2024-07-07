using EstateManager.Contract;
using EstateManager.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EstateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingController(IUsersService usersRepo) : Controller { 
   
        [HttpPost("Register")]       
        public IActionResult RegisterUser( UserRequest request)
        {
            var response = usersRepo.AddUser(request);
            return Ok(response);
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            
            return Ok("test is working");
        }
    }
}
