namespace GamesUpApp.Domain
{
    public class GameParams
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? TotalHours { get; set; }

        public GameParams() 
        { 

        }

        public GameParams(Guid id, Guid userId, string? name, string? description, int? totalHours)
        {
            if (id == Guid.Empty || id == default)
                throw new Exception("Identificação de jogo inválido");

            if (userId == Guid.Empty || userId == default)
                throw new Exception("Acesso de usuário inválido");

            if (!string.IsNullOrEmpty(name))
            {
                if (name == "string" || name.Length > 200)
                    throw new Exception("Nome está em branco ou inválido");
            }

            if (!string.IsNullOrEmpty(description))
            {
                if (description == "string" || description.Length > 300)
                    throw new Exception("Descrição está em branco ou inválida");
            }

            if (totalHours < 0)
                throw new Exception("Horas jogadas está em branco ou inválida");

            Id = id;
            UserId = userId;
            Name = name;
            Description = description;
            TotalHours = totalHours;
        }
    }

}
