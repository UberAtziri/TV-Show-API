using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class TVShowEntity
    {
        [Key]
        public int TVShowId { get; set; }
        public string Title { get; set; }
        public double ImdbScore { get; set; }
        public ICollection<TVShowGenre> TVShowGenre { get; set; }
    }
}