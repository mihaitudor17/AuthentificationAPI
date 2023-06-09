﻿using Auth0.ManagementApi.Models.Rules;
using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{

    [ApiController]
    [Route("api/classes")]
    public class ClassesController : ControllerBase
    {
        private readonly ClassService classService;

        public ClassesController(ClassService classService)
        {
            this.classService = classService;
        }
        [Authorize(Roles = "Profesor")]
        [HttpPost("add")]
        public IActionResult Add(ClassAddDto payload)
        {
            var result = classService.Add(payload);

            if (result == null)
            {
                return BadRequest("Class cannot be added");
            }

            return Ok(result);
        }
        [Authorize(Roles = "Student")]
        [HttpGet("get-all")]
        public ActionResult<List<ClassViewDto>> GetAll()
        {
            var result = classService.GetAll();

            return Ok(result);
        }
    }
}
