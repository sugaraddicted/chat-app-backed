﻿using ChatApp.Core.DTO;
using ChatApp.Core.Entities;

namespace ChatApp.Core.Interfaces
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<MemberDto>> GetDtosAsync();
        Task<MemberDto> GetDtoByUsernameAsync(string username);
        public Task<bool> SaveAsync();
    }
}
