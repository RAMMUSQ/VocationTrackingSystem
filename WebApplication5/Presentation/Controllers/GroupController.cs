using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTOs;
using WebApplication5.Interfaces;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateGroup([FromBody] GroupDto groupDto)
        {
            var adminUsername = User.Identity.Name; // Assuming the username is stored in the identity

            try
            {
                var createdGroup = await _groupService.CreateGroupAsync(groupDto, adminUsername);
                return Ok(createdGroup);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
        }
    }
}
