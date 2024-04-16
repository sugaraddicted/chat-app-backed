using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatApp.Core.DTO;
using ChatApp.Core.Entities;
using ChatApp.Core.Interfaces;
using ChatApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repository
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Photos)
                .SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Photos)
                .ToListAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetDtosAsync()
        {
            return await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<MemberDto> GetDtoByUsernameAsync(string username)
        {
            return await _context.Users.Where(u => u.Username == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            if (await _context.SaveChangesAsync() == 0) return false;
            return true;
        }
    }
}
