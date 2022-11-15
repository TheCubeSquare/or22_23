using SoccerMatches.Models;

namespace SoccerMatches.Services
{
	public interface IMatchService
	{
		Task<bool> CreateMatch(Match match);
		Task<List<Match>> GetMatchList();
		Task<Match> UpdateMatch(Match match);
		Task<bool> DeleteMatch(int key);
	}
}
