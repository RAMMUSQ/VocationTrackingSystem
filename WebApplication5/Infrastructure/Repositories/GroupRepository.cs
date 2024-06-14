using System.Threading.Tasks;
using Core.Entities;
using WebApplication5.Data;
using WebApplication5.Interfaces;

namespace WebApplication5.Repositories
{
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