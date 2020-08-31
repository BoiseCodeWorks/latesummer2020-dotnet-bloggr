using System.ComponentModel.DataAnnotations;

namespace latesummer2020_dotnet_bloggr.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Body { get; set; }
        [Required]
        public int blogId { get; set; }
    }
}