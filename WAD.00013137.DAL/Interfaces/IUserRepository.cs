using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD._00013137.Models;

namespace WAD._00013137.DAL.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllUsersAsync();
		Task<User> GetUserByIdAsync(int id);
		Task<User> CreateUserAsync(User user);
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(int id);
	}
}
