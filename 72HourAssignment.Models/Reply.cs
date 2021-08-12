﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72HourAssignment.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        public string Text { get; set; }  
        
        [Required]
        public Guid AuthorId { get; set; }
    }
}
