namespace WebApi.Entities
{
    public class TVShowEntity : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double ImdbScore { get; set; }
    }
}