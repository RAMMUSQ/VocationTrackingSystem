using Core.Entities;
using WebApplication5.Core;


namespace WebApplication5.Interfaces
{
    public interface IGroupRepository
    {
        Task<UserGroups> AddGroupAsync(UserGroups group);
        Task AddGroupMemberAsync(UserGroupMember groupMember);
       
    }

    
}