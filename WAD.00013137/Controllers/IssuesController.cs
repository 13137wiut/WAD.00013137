using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00013137.DAL.Interfaces;
using WAD._00013137.DTOs;
using WAD._00013137.Models;

namespace WAD._00013137.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IssuesController : ControllerBase
	{
		private readonly IIssueRepository _issueRepository;
		private readonly IMapper _mapper;

		public IssuesController(IIssueRepository issueRepository, IMapper mapper)
		{
			_issueRepository = issueRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<IssueDto>>> GetIssues()
		{
			var issues = await _issueRepository.GetAllIssuesAsync();
			var issueDtos = _mapper.Map<IEnumerable<IssueDto>>(issues);
			return Ok(issueDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<IssueDto>> GetIssue(int id)
		{
			var issue = await _issueRepository.GetIssueByIdAsync(id);
			if (issue == null) return NotFound();
			var issueDto = _mapper.Map<IssueDto>(issue);
			return Ok(issueDto);
		}

		[HttpPost]
		public async Task<ActionResult<IssueDto>> PostIssue(IssueDto issueDto)
		{
			var issue = _mapper.Map<Issue>(issueDto);
			await _issueRepository.CreateIssueAsync(issue);
			return Ok(issueDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutIssue(int id, IssueDto issueDto)
		{
			if (id != issueDto.Id) return BadRequest();
			var issue = await _issueRepository.GetIssueByIdAsync(id);
			if (issue == null) return NotFound();

			_mapper.Map(issueDto, issue);
			await _issueRepository.UpdateIssueAsync(issue);
			return Ok("The record with " + id + " has been updated!");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteIssue(int id)
		{
			var issue = await _issueRepository.GetIssueByIdAsync(id);
			if (issue == null) return NotFound();

			await _issueRepository.DeleteIssueAsync(id);
			return Ok("Record with " + id + " has been deleted!");
		}
	}
}
