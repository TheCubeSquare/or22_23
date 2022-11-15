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
			var matchList = await _dbService.GetAll<Match>("select distinct public.match.matchid, first_team, first_team_goals, firstplayer.player_name as firstplayername, firstplayer.player_surname as firstplayersurname,\r\n\tsecond_team, second_team_goals, secondplayer.player_name as secondplayername, secondplayer.player_surname as secondplayersurname, date, stadium,\r\n\toutgoingplayer.player_name as outgoingplayername, outgoingplayer.player_surname as outgoingplayersurname, \r\n\tincomingplayer.player_name as incomingplayername, incomingplayer.player_surname as incomingplayersurname from public.match\r\nleft join first_team_players on first_team_players.matchid = public.match.matchid\r\nleft join player firstplayer on first_team_players.playerid = firstplayer.playerid\r\nleft join second_team_players on second_team_players.matchid = public.match.matchid\r\nleft join player secondplayer on second_team_players.playerid = secondplayer.playerid\r\nleft join substitutions on substitutions.matchid = public.match.matchid\r\nleft join substitution on substitution.substitutionid = substitutions.substitutionid\r\nleft join player outgoingplayer on substitution.outgoingid = outgoingplayer.playerid\r\nleft join player incomingplayer on substitution.incomingid = incomingplayer.playerid", new { });
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
