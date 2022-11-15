using SoccerMatches.Models;

namespace SoccerMatches.Services
{
	public class PlayerService : IPlayerService
	{
		private readonly IDbService _dbService;

		public PlayerService(IDbService dbService)
		{
			_dbService = dbService;
		}

		public async Task<bool> CreatePlayer(Player player)
		{
			var result =
				await _dbService.EditData(
					"INSERT INTO public.player (id,name, age, address, mobile_number) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)",
					player);
			return true;
		}

		public async Task<List<Player>> GetPlayerList()
		{
			var playerList = await _dbService.GetAll<Player>("SELECT * FROM public.player", new { });
			return playerList;
		}


		public async Task<Player> GetPlayer(int id)
		{
			var playerList = await _dbService.GetAsync<Player>("SELECT * FROM public.player where id=@id", new { id });
			return playerList;
		}

		public async Task<Player> UpdatePlayer(Player player)
		{
			var updateplayer =
				await _dbService.EditData(
					"Update public.player SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id",
					player);
			return player;
		}

		public async Task<bool> DeletePlayer(int id)
		{
			var deleteplayer = await _dbService.EditData("DELETE FROM public.player WHERE id=@Id", new { id });
			return true;
		}
	}
}
