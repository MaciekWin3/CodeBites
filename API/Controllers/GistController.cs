using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Gists")]
    [Route("/api/gists")]
    public class GistController : Controller
    {
        private readonly IGistService gistService;
        public GistController(IGistService gistService)
        {
            this.gistService = gistService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "Public gists returned successfully", typeof(List<Gist>))]
        [SwaggerOperation(Summary = "Fetches all public gists")]
        public async Task<IActionResult> GetPublicGistsAsync()
        {
            var result = await gistService.GetPublicGistsAsync();
            return Ok(result.GetValue());
        }

        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Gist returned successfully", typeof(Gist))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Gist not found")]
        [SwaggerOperation(Summary = "Fetches a gist by its id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await gistService.GetByIdAsync(id);
            return result.Success ? Ok(result.GetValue()) : NotFound(result.Error);
        }

        [HttpGet("user/{email}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "User gists returned successfully", typeof(List<Gist>))]
        [SwaggerOperation(Summary = "Fetches all gists of a user")]
        public async Task<IActionResult> GetUserGistsAsync(string email)
        {
            var result = await gistService.GetUserGistsAsync(email);
            return Ok(result.GetValue());
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created, "Gist created successfully", typeof(Gist))]
        [SwaggerOperation(Summary = "Creates a new gist")]
        public async Task<IActionResult> CreateAsync([FromBody] Gist gist)
        {
            var result = await gistService.CreateAsync(gist);
            return Created("", result.GetValue());
        }

        [HttpPost]
        [Route("upvote")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Gist upvoted successfully")]
        [SwaggerOperation(Summary = "Upvotes a gist")]
        public async Task<IActionResult> UpvoteAsync([FromBody] Gist gist)
        {
            await gistService.UpvoteAsync(gist);
            return Ok();
        }
    }
}
