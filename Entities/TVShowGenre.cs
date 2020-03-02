using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class TVShowGenre
    {
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        [ForeignKey("TVShow")]
        public int TVShowId { get; set; }
        public GenreEntity Genre { get; set; }
        public TVShowEntity TVShow { get; set; }
        
    }
}