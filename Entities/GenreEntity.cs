using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class GenreEntity
    {
        [Key]
        public int GenreId { get; set; }
        public string Genre { get; set; }
        public ICollection<TVShowGenre> TVShowGenre { get; set; }

    }
}