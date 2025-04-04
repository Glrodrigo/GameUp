namespace GamesUpApp.Domain
{
    public class GameResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public int TotalHours { get; set; }
        public bool Finished { get; set; }
        public int FinishedTimes { get; set; }
    }
}
