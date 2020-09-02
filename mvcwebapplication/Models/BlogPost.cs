using System.ComponentModel.DataAnnotations;
namespace mvcwebapplication.Models
{
    public class BlogPost
    {
        [Key]
        public int id {get;set;}
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string title {get;set;}
        [Required]
        public string text {get;set;}
        [Range(1,5)]
        public int rating {get;set;}
    }
}