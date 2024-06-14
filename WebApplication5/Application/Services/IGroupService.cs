using System.Threading.Tasks;
using WebApplication5.DTOs;

namespace WebApplication5.Interfaces
{
    public interface IGroupService
    {
        Task<GroupDto> CreateGroupAsync(GroupDto groupDto, string adminUsername);
    }
}