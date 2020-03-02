using System.Collections.Generic;

namespace WebApi.DTO
{
    public class TVShowResponse
    {
        public int TVShowId { get; set; }
        public string Title { get; set; }
        public double ImdbScore { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
    }
}