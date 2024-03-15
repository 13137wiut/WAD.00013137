using AutoMapper;
using WAD._00013137.DTOs;
using WAD._00013137.Models;

namespace WAD._00013137.MappingProfiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Issue, IssueDto>();
			CreateMap<User, UserDto>();
		}
	}
}
