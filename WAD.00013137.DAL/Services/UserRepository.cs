using Microsoft.EntityFrameworkCore;
using WAD._00013137.DAL.Interfaces;
using WAD._00013137.Data;
using WAD._00013137.Models;

namespace WAD._00013137.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly IssueTrackerContext _context;

		public UserRepository(IssueTrackerContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<User>> GetAllUsersAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> GetUserByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<User> CreateUserAsync(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
			return user;
		}

		public async Task UpdateUserAsync(User user)
		{
			_context.Entry(user).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteUserAsync(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
			}
		}
	}
}
