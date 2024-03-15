using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00013137.DAL.Interfaces;
using WAD._00013137.DTOs;
using WAD._00013137.Models;

namespace WAD._00013137.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UsersController(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
		{
			var users = await _userRepository.GetAllUsersAsync();
			var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
			return Ok(userDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserDto>> GetUser(int id)
		{
			var user = await _userRepository.GetUserByIdAsync(id);
			if (user == null) return NotFound();
			var userDto = _mapper.Map<UserDto>(user);
			return Ok(userDto);
		}

		[HttpPost]
		public async Task<ActionResult<UserDto>> PostUser(UserDto userDto)
		{
			var user = _mapper.Map<User>(userDto);
			await _userRepository.CreateUserAsync(user);
			return Ok(userDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(int id, UserDto userDto)
		{
			if (id != userDto.Id) return BadRequest();
			var user = await _userRepository.GetUserByIdAsync(id);
			if (user == null) return NotFound();

			_mapper.Map(userDto, user);
			await _userRepository.UpdateUserAsync(user);
			return Ok("The record with " + id + " has been updated!");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var user = await _userRepository.GetUserByIdAsync(id);
			if (user == null) return NotFound();

			await _userRepository.DeleteUserAsync(id);
			return Ok("Record with " + id + " has been deleted!");
		}
	}
}
