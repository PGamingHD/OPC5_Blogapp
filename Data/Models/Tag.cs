using System.ComponentModel.DataAnnotations;

namespace OPC5_Blogapp.Data.Models
{
    public class Tag
    {
        [Key]
        [Required]
        public int TagId { get; set; }

        public string TagName { get; set; }

        public int PostId { get; set; }

        public Post TagPost { get; set; } 
    }
}
