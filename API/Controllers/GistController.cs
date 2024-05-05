using API.DTOs;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Gists")]
    [Route("/api/gists")]
    public class GistController : Controller
    {
        private readonly IGistService gistService;
        private readonly UserManager<IdentityUser> userManager;
        public GistController(IGistService gistService, UserManager<IdentityUser> userManager)
        {
            this.gistService = gistService;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
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
        public async Task<IActionResult> CreateAsync([FromBody] GistCreateDTO gistDto)
        {
            // get me current user
            var user = await userManager.GetUserAsync(User);
            var gist = gistDto.ToModel(user!);
            var result = await gistService.CreateAsync(gist);
            return Created("", result.GetValue());
        }

        [HttpPatch]
        [Route("upvote")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Gist upvoted successfully")]
        [SwaggerOperation(Summary = "Upvotes a gist")]
        public async Task<IActionResult> UpvoteAsync([FromBody] GistUpdateDTO gistDto)
        {
            var gistToUpdate = await gistService.GetByIdAsync(gistDto.Id);
            var gist = gistDto.ToModel(gistToUpdate.GetValue());
            await gistService.UpvoteAsync(gist);
            return Ok();
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, "Gist updated successfully", typeof(Gist))]
        [SwaggerOperation(Summary = "Updates a gist")]
        public async Task<IActionResult> UpdateAsync([FromBody] GistUpdateDTO gistDto)
        {
            var gistToUpdate = await gistService.GetByIdAsync(gistDto.Id);
            var gist = gistDto.ToModel(gistToUpdate.GetValue());
            var result = await gistService.UpdateAsync(gist);
            return Ok();
        }
    }
}
