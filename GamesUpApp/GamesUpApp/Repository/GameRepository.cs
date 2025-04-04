using GamesUpApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace GamesUpApp.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(GameBase game)
        {
            try
            {
                await _context.Games.AddAsync(game);
                int rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar salvar no banco de dados", ex);
            }
        }

        public async Task<List<GameBase>> GetAsync()
        {
            try
            {
                return await _context.Games.AsNoTracking().ToListAsync() ?? new List<GameBase>();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar obter os jogos do banco de dados", ex);
            }
        }

        public async Task<List<GameBase>> FindByIdAsync(Guid id)
        {
            try
            {
                var products = await _context.Games
                    .Where(t => t.Id == id)
                    .ToListAsync();

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar obter o jogo", ex);
            }
        }

        public async Task<bool> UpdateAsync(GameBase game)
        {
            try
            {
                _context.Games.Update(game);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar atualizar", ex);
            }
        }
    }
}
