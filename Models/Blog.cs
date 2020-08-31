using System.ComponentModel.DataAnnotations;

namespace latesummer2020_dotnet_bloggr.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Title { get; set; }
        [MaxLength(80)]
        public string Body { get; set; }
        [Required]
        public bool isPublished { get; set; }
    }
}