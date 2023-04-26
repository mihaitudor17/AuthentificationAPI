using Auth0.ManagementApi.Models.Rules;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using Core.Dtos;
using Microsoft.EntityFrameworkCore;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserService userService;
        private readonly GradesService gradeService;

        public HomeController(IConfiguration config, UserService userService, GradesService gradeService)
        {
            _config = config;
            this.userService = userService;
            this.gradeService = gradeService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto user)
        {
            var result = userService.GetByUserName(user.UserName);
            if (result == null)
            {
                return BadRequest("Student not fount");
            }
            var tokenGenerator = new JwtService(_config);
            var token = tokenGenerator.GenerateToken(result);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public IActionResult Add(UserAddDto payload)
        {
            var result = userService.Add(payload);

            if (result == null)
            {
                return BadRequest("Class cannot be added");
            }

            return Ok(result);
        }
        [Authorize(Roles = "Profesor")]
        [HttpPost("get-all-grades")]
        public ActionResult<Dictionary<string, List<Grade>>> GetAll()
        {
            var result = gradeService.GetAll();

            if (result == null)
            {
                return BadRequest("Class cannot be added");
            }

            return Ok(result);
        }

        [Authorize(Roles = "Student")]
        [HttpPost("get-grades")]
        public ActionResult<List<Grade>> GetResult(int id)
        {
            var result = gradeService.GetGrades(id);

            if (result == null)
            {
                return BadRequest("Class cannot be added");
            }

            return Ok(result);
        }
    }
}
