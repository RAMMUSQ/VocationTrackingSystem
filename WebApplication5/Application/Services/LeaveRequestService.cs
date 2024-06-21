/*using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Services;

namespace Infrastructure.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<bool> CreateLeaveRequestAsync(int userId, string leaveType, DateTime startDate, DateTime endDate, string reason)
        {
            var leaveRequest = new LeaveRequest
            {
                UserId = userId,
                LeaveType = leaveType,
                StartDate = startDate,
                EndDate = endDate,
                Reason = reason
            };

            await _leaveRequestRepository.AddLeaveRequestAsync(leaveRequest);
            return true;
        }

        public async Task<IEnumerable<LeaveRequest>> GetPendingLeaveRequestsAsync(int adminId)
        {
            return await _leaveRequestRepository.GetPendingLeaveRequestsAsync(adminId);
        }

        public async Task<bool> ApproveLeaveRequestAsync(int requestId)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(requestId);
            if (leaveRequest == null) return false;

            leaveRequest.Approved = true;
            await _leaveRequestRepository.UpdateLeaveRequestAsync(leaveRequest);
            return true;
        }

        public async Task<bool> RejectLeaveRequestAsync(int requestId)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(requestId);
            if (leaveRequest == null) return false;

            leaveRequest.Approved = false;
            await _leaveRequestRepository.UpdateLeaveRequestAsync(leaveRequest);
            return true;
        }
    }
}*/
