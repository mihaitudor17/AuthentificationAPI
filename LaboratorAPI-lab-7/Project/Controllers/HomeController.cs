using Auth0.ManagementApi.Models.Rules;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
namespace Project.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Verify the user's credentials (e.g. username and password) here
            // ...

            // Retrieve the user's information from the database or another data source
            var user = new User
            {
                Id = 123,
                Username = "jdoe",
                Role = "admin"
            };

            // Generate a JWT token based on the user's information
            var tokenGenerator = new JwtService(_config);
            var token = tokenGenerator.GenerateToken(user);

            // Return the token to the client as part of the API response
            return Ok(new { token });
        }
    }
}
