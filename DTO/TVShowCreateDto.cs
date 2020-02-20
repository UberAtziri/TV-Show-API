using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class TVShowCreateDto
    {
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public double ImdbScore { get; set; }
    }
}