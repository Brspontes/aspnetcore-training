using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok(projectService.GetAll(query));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(projectService.GetById(id));
        }

        [HttpPost()]
        public IActionResult Post([FromBody] NewProjectInputModel createProjectModel)
        {
            if (createProjectModel.Title.Length > 50)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel createProjectModel)
        {
            if (createProjectModel.Description.Length > 200)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment([FromBody] CreateCommentModel createCommentModel)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
