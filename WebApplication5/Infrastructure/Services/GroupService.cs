using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.DTOs;
using Core.Entities;
using Core.Enums;
using Infrastructure.Repositories;
using WebApplication5.Interfaces;

namespace WebApplication5.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;

        public GroupService(IGroupRepository groupRepository, IUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }

        public async Task<GroupDto> CreateGroupAsync(GroupDto groupDto, string adminUsername)
        {
            // Admin kullanıcı doğrulaması
            var adminUser = await _userRepository.GetUserByUsernameAsync(adminUsername);
            if (adminUser == null || adminUser.Role != UserRole.Admin) // Role özelliğiyle admin kontrolü
            {
                throw new UnauthorizedAccessException("Sadece adminler grup oluşturabilir.");
            }

            var users = new List<User>();

            foreach (var username in groupDto.MemberNames)
            {
                var user = await _userRepository.GetUserByUsernameAsync(username);
                if (user != null)
                {
                    users.Add(user);
                }
            }

            var group = new UserGroups
            {
                Name = groupDto.GroupName,
                Members = users
            };

            await _groupRepository.AddGroupAsync(group);

            return groupDto;
        }
    }
}