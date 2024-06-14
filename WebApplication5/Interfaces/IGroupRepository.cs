using Core.Entities;
using WebApplication5.Data;

namespace WebApplication5.Interfaces
{
    public interface IGroupRepository
    {
        Task<UserGroups> AddGroupAsync(UserGroups group);
    }

    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserGroups> AddGroupAsync(UserGroups group)
        {
            _context.UserGroups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }
    }
}