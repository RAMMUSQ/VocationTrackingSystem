/*using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace Infrastructure.Data
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<IEnumerable<LeaveRequest>> GetPendingLeaveRequestsAsync(int adminId)
        {
            // Burada adminId'ye bağlı olan kullanıcıların bekleyen izin isteklerini getirmek için gerekli sorgulama yapılmalıdır.
            return await _context.LeaveRequests
                .Where(lr => !lr.Approved.HasValue && lr.UserId == adminId)
                .ToListAsync();
        }

        public async Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            await _context.SaveChangesAsync();
        }
    }
}*/