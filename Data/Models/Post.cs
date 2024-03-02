using System.ComponentModel.DataAnnotations;

namespace OPC5_Blogapp.Data.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int PostId { get; set; }

        public string PostData { get; set; }
        public int PostUpvotes { get; set; }
        public int PostDownvotes { get; set; }
        public List<Tag>? PostTags { get; set; }
        public List<Comment>? PostComments { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
