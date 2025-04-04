using GamesUpApp.Domain;
using GamesUpApp.Repository;

namespace GamesUpApp.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<bool> CreateAsync(GameBase game)
        {
            try
            {
                var result = await _gameRepository.InsertAsync(game);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<GameResult>> GetAsync()
        {
            try
            {
                List<GameResult> result = new List<GameResult>();
                var games = await _gameRepository.GetAsync();

                foreach (var game in games)
                {
                    GameResult resultGame = new GameResult()
                    {
                        Id = game.Id,
                        Name = game.Name,
                        Description = game.Description,
                        Platform = game.Platform,
                        TotalHours = game.TotalHours,
                        Finished = game.Finished,
                        FinishedTimes = game.FinishedTimes,
                    };

                    result.Add(resultGame);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<GameResult>> FindByIdAsync(Guid id)
        {
            try
            {
                List<GameResult> result = new List<GameResult>();
                var games = await _gameRepository.FindByIdAsync(id);

                foreach (var game in games)
                {
                    GameResult resultGame = new GameResult()
                    {
                        Id = game.Id,
                        Name = game.Name,
                        Description = game.Description,
                        Platform = game.Platform,
                        TotalHours = game.TotalHours,
                        Finished = game.Finished,
                        FinishedTimes = game.FinishedTimes,
                    };

                    result.Add(resultGame);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ChangeAsync(GameParams gameParams)
        {
            try
            {
                GameParams game = new GameParams(gameParams.Id, gameParams.UserId, gameParams.Name, gameParams.Description, gameParams.TotalHours) { };
                var oldGames = await _gameRepository.FindByIdAsync(game.Id);

                if (oldGames.Count == 0)
                    throw new Exception("Jogo inexistente");

                var oldGame = oldGames[0];
                oldGame.SetChangeParams(oldGame, gameParams);

                var result = await _gameRepository.UpdateAsync(oldGame);

                return result;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
