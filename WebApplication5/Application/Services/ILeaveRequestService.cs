/*using System.Threading.Tasks;
using Core.Entities;

namespace Core.Services
{
    public interface ILeaveRequestService
    {
        Task<bool> CreateLeaveRequestAsync(int userId, string leaveType, DateTime startDate, DateTime endDate, string reason);
        Task<IEnumerable<LeaveRequest>> GetPendingLeaveRequestsAsync(int adminId);
        Task<bool> ApproveLeaveRequestAsync(int requestId);
        Task<bool> RejectLeaveRequestAsync(int requestId);
    }
}*/