using Core.Entities;
using WebApplication5.Controllers;

namespace WebApplication5.Interfaces
{
    public interface IPermissionRepository
    {
        Task<PermissionRequest> AddPermissionRequestAsync(PermissionRequest request);
        Task<PermissionRequest> UpdatePermissionRequestAsync(PermissionRequest request);
        Task<PermissionRequest> GetPermissionRequestByIdAsync(int requestId);
    }
}