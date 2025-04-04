namespace GamesUpApp.Domain
{
    public class GameBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public int TotalHours { get; set; }
        public bool Finished { get; set; }
        public int FinishedTimes { get; set; }
        private DateTime CreationDate { get; set; }
        private DateTime? UpdateDate { get; set; }
        private DateTime? DeleteDate { get; set; }
        private bool Active { get; set; }


        public GameBase()
        {

        }

        public GameBase(Guid userId, string name, string description, string platform, int totalHours, bool finished)
        {
            if (userId == Guid.Empty || userId == default)
                throw new Exception("Acesso de usuário inválido");

            if (string.IsNullOrEmpty(name) || name == "string" || name.Length > 200)
                throw new Exception("Nome está em branco ou inválido");

            if (string.IsNullOrEmpty(description) || description == "string" || description.Length > 300)
                throw new Exception("Descrição está em branco ou inválida");

            if (string.IsNullOrEmpty(platform) || platform == "string" || platform.Length > 100)
                throw new Exception("Platforma está em branco ou inválida");

            if (totalHours < 0)
                throw new Exception("Horas jogadas está em branco ou inválida");

            
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name.ToUpper();
            Description = description.ToUpper();
            Platform = platform.ToUpper();
            TotalHours = totalHours;
            Finished = finished;
            FinishedTimes += finished ? 1 : 0;
            CreationDate = DateTime.UtcNow;
            Active = true;
        }

        public GameBase SetChangeParams(GameBase oldGame, GameParams gameParams)
        {
            if (!string.IsNullOrEmpty(gameParams.Name))
            {
                gameParams.Name = gameParams.Name.ToUpper();

                if (oldGame.Name != gameParams.Name)
                    oldGame.Name = gameParams.Name;
            }

            if (!string.IsNullOrEmpty(gameParams.Description))
            {
                gameParams.Description = gameParams.Description.ToUpper();

                if (oldGame.Description != gameParams.Description)
                    oldGame.Description = gameParams.Description;
            }

            if (gameParams.TotalHours > 0)
            {
                if (oldGame.TotalHours != gameParams.TotalHours)
                    oldGame.TotalHours = (int)gameParams.TotalHours;
            }

            oldGame.UpdateDate = DateTime.UtcNow;

            return oldGame;
        }
    }
}
