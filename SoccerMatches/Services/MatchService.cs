using SoccerMatches.Models;

namespace SoccerMatches.Services
{
	public class MatchService : IMatchService
	{
		private readonly IDbService _dbService;

		public MatchService(IDbService dbService)
		{
			_dbService = dbService;
		}

		public async Task<bool> CreateMatch(Match match)
		{
			var result =
				await _dbService.EditData(
					"INSERT INTO public.match (id,name, age, address, mobile_number) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)",
					match);
			return true;
		}

		public async Task<List<Match>> GetMatchList()
		{
			var matchList = await _dbService.GetAll<Match>("SELECT * FROM public.match", new { });
			return matchList;
		}


		public async Task<Match> GetMatch(int id)
		{
			var matchList = await _dbService.GetAsync<Match>("SELECT * FROM public.match where id=@id", new { id });
			return matchList;
		}

		public async Task<Match> UpdateMatch(Match match)
		{
			var updateMatch =
				await _dbService.EditData(
					"Update public.match SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id",
					match);
			return match;
		}

		public async Task<bool> DeleteMatch(int id)
		{
			var deleteMatch = await _dbService.EditData("DELETE FROM public.match WHERE id=@Id", new { id });
			return true;
		}
	}
}
