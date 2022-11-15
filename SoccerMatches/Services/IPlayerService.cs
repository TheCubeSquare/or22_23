using SoccerMatches.Models;

namespace SoccerMatches.Services
{
	public interface IPlayerService
	{
		Task<bool> CreatePlayer(Player player);
		Task<List<Player>> GetPlayerList();
		Task<Player> UpdatePlayer(Player player);
		Task<bool> DeletePlayer(int key);
	}
}
