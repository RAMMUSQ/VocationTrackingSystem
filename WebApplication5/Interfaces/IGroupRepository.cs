using System.Threading.Tasks;
using Core.Entities;

namespace WebApplication5.Interfaces
{
    public interface IGroupRepository
    {
        Task<UserGroups> AddGroupAsync(UserGroups group);
    }
}
