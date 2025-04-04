using GamesUpApp.Domain;

namespace GamesUpApp.Service
{
    public interface IGameService
    {
        Task<bool> CreateAsync(GameBase game);
        Task<List<GameResult>> GetAsync();
        Task<List<GameResult>> FindByIdAsync(Guid id);
        Task<bool> ChangeAsync(GameParams gameParams);
    }
}
