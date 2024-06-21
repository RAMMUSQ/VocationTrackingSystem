using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services;
using WebApplication5.DTOs;
using Microsoft.AspNetCore.Authorization;


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

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateGroup(GroupDto groupDto)
        {
            object? result = await _groupService.CreateGroupAsync(groupDto);
            return Ok(result);
        }
    }
}