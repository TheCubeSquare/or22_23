using Microsoft.AspNetCore.Mvc;
using SoccerMatches.Models;
using SoccerMatches.Services;

namespace SoccerMatches.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MatchController : Controller
	{
		private readonly IMatchService _matchService;

		public MatchController(IMatchService matchService)
		{
			_matchService = matchService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result = await _matchService.GetMatchList();

			return Ok(result);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetMatch(int id)
		{
			var result = await ((MatchService)_matchService).GetMatch(id);

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> AddMatch([FromBody] Match match)
		{
			var result = await _matchService.CreateMatch(match);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateMatch([FromBody] Match match)
		{
			var result = await _matchService.UpdateMatch(match);

			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteMatch(int id)
		{
			var result = await _matchService.DeleteMatch(id);

			return Ok(result);
		}
	}
}
