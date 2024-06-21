/*using Microsoft.AspNetCore.Mvc;
using WebApplication5.DTOs;
using WebApplication5.Services;

namespace WebApplication5.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost]
        public async Task<IActionResult> RequestPermission(PermissionRequestDto requestDto)
        {
            var result = await _permissionService.RequestPermissionAsync(requestDto);
            return Ok(result);
        }

        [HttpPost("{requestId}/approve")]
        public async Task<IActionResult> ApprovePermission(int requestId)
        {
            var result = await _permissionService.ApprovePermissionAsync(requestId);
            return Ok(result);
        }

        [HttpPost("{requestId}/deny")]
        public async Task<IActionResult> DenyPermission(int requestId)
        {
            var result = await _permissionService.DenyPermissionAsync(requestId);
            return Ok(result);
        }
    }
}*/