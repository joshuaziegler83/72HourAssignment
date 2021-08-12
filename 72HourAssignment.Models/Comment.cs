using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourAssignment.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
        
        public virtual ICollection<Reply> Replies { get; set; } 

        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
