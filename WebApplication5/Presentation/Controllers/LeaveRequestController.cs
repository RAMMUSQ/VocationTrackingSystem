using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/*using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [Authorize]
        [HttpPost("request")]
        public async Task<IActionResult> CreateLeaveRequest([FromBody] LeaveRequestDto leaveRequestDto)
        {
            var userId = int.Parse(User.Identity.Name); // Kullanıcı ID'sini elde et
            var result = await _leaveRequestService.CreateLeaveRequestAsync(userId, leaveRequestDto.LeaveType, leaveRequestDto.StartDate, leaveRequestDto.EndDate, leaveRequestDto.Reason);
            if (result) return Ok("Leave request created.");
            return BadRequest("Failed to create leave request.");
        }

        [Authorize]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingLeaveRequests()
        {
            var adminId = int.Parse(User.Identity.Name); // Admin ID'sini elde et
            var leaveRequests = await _leaveRequestService.GetPendingLeaveRequestsAsync(adminId);
            return Ok(leaveRequests);
        }

        [Authorize]
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveLeaveRequest(int id)
        {
            var result = await _leaveRequestService.ApproveLeaveRequestAsync(id);
            if (result) return Ok("Leave request approved.");
            return BadRequest("Failed to approve leave request.");
        }

        [Authorize]
        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectLeaveRequest(int id)
        {
            var result = await _leaveRequestService.RejectLeaveRequestAsync(id);
            if (result) return Ok("Leave request rejected.");
            return BadRequest("Failed to reject leave request.");
        }
    }
}*/
