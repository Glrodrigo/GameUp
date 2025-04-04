using GamesUpApp.Domain;

namespace GamesUpApp.Repository
{
    public interface IGameRepository
    {
        Task<bool> InsertAsync(GameBase game);
        Task<List<GameBase>> GetAsync();
        Task<List<GameBase>> FindByIdAsync(Guid id);
        Task<bool> UpdateAsync(GameBase game);
    }
}
