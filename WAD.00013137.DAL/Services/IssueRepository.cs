using Microsoft.EntityFrameworkCore;
using WAD._00013137.DAL.Interfaces;
using WAD._00013137.Data;
using WAD._00013137.Models;

namespace WAD._00013137.Services
{
	public class IssueRepository : IIssueRepository
	{
		private readonly IssueTrackerContext _context;

		public IssueRepository(IssueTrackerContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Issue>> GetAllIssuesAsync()
		{
			return await _context.Issues.ToListAsync();
		}

		public async Task<Issue> GetIssueByIdAsync(int id)
		{
			return await _context.Issues.FindAsync(id);
		}

		public async Task<Issue> CreateIssueAsync(Issue issue)
		{
			_context.Issues.Add(issue);
			await _context.SaveChangesAsync();
			return issue;
		}

		public async Task UpdateIssueAsync(Issue issue)
		{
			_context.Entry(issue).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteIssueAsync(int id)
		{
			var issue = await _context.Issues.FindAsync(id);
			if (issue != null)
			{
				_context.Issues.Remove(issue);
				await _context.SaveChangesAsync();
			}
		}
	}
}
