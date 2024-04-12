using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ChatApp.Core.Entities;
using ChatApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure
{
    public class Seed
    {
        public static async Task SeedUsers(AppDbContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("C:\\Users\\ma7i7\\Source\\repos\\ChatApp\\ChatApp\\ChatApp.Infrastructure\\UserSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<User>>(userData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.LastActive = DateTime.SpecifyKind(user.LastActive, DateTimeKind.Utc);
                user.Created = DateTime.SpecifyKind(user.Created, DateTimeKind.Utc);
                user.DateOfBirth = DateTime.SpecifyKind(user.DateOfBirth, DateTimeKind.Utc);
                user.Username = user.Username.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}
