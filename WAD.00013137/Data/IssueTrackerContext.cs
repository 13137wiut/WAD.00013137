using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WAD._00013137.Models;

namespace WAD._00013137.Data
{
	public class IssueTrackerContext : DbContext
	{
		public IssueTrackerContext(DbContextOptions<IssueTrackerContext> options)
			: base(options) { }

		public DbSet<Issue> Issues { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Issue>()
				.HasOne(i => i.User)
				.WithMany(u => u.Issues)
				.HasForeignKey(i => i.UserId);
		}
	}
}
