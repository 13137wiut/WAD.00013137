using WAD._00013137.DAL.Interfaces;
using WAD._00013137.DAL.Services;
using WAD._00013137.Data;
using WAD._00013137.Models;

namespace WAD._00013137.Services
{
	public class IssueRepository : BaseRepository<Issue>, IIssueRepository
	{
        public IssueRepository(IssueTrackerContext context) : base(context)
        {
        }
    }
}
