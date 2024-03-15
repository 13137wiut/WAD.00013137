using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD._00013137.DAL.Interfaces;
using WAD._00013137.Data;
using WAD._00013137.Services;

namespace WAD._00013137.DAL
{
	public static class ConfigrationDAL
	{
		public static IServiceCollection DalConfiguration(
			this IServiceCollection services, 
			IConfiguration configuration
		)
		{
			// Adding connection string to sql
			services.AddDbContext<IssueTrackerContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			// Depedency injection 
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IIssueRepository, IssueRepository>();

			// Adding profile
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}
