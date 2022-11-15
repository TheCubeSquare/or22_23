using Microsoft.AspNetCore.Mvc;
using SoccerMatches.Models;
using SoccerMatches.Services;

namespace SoccerMatches.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PlayerController : Controller
	{
		private readonly IPlayerService _playerService;

		public PlayerController(IPlayerService playerService)
		{
			_playerService = playerService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result = await _playerService.GetPlayerList();

			return Ok(result);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetPlayer(int id)
		{
			var result = await ((PlayerService)_playerService).GetPlayer(id);

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddPlayer([FromBody] Player player)
		{
			var result = await _playerService.CreatePlayer(player);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePlayer([FromBody] Player player)
		{
			var result = await _playerService.UpdatePlayer(player);

			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeletePlayer(int id)
		{
			var result = await _playerService.DeletePlayer(id);

			return Ok(result);
		}
	}
}
