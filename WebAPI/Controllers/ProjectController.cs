using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TQ_Project.Application.Interfaces;
using TQ_Project.Application.Models.Project;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectCreate>>> GetAllProjects()
        {
            var result = await _projectService.GetAllProjects();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectCreate>> GetProjectById(int id)
        {
            var result = await _projectService.GetProjectById(id);

            if (result is null)
            {
                return BadRequest("Project not found!");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectCreate>>> AddProject([FromBody] ProjectCreate project) //optional attribute expecting user object in the body
        {
            var result = await _projectService.AddProject(project);

            if (result is null)
            {
                return BadRequest("Project already exists!");
            }
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectCreate>> UpdateProjectById(int id, ProjectCreate requestedProject)
        {
            var result = await _projectService.UpdateProjectById(id, requestedProject);
            if (result is null) return NotFound("Project not found!");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectCreate>>> DeleteProject(int id)
        {
            var result = await _projectService.GetProjectById(id);

            if (result is null) return NotFound("Project not found!");

            await _projectService.DeleteProject(id);
            return Ok("Project deleted!");
        }
    }
}
