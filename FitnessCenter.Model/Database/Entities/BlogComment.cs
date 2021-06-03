using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class BlogComment
    {
        public Guid Id { get; set; }
        
        public Guid BlogId { get; set; }

        public Guid ClientId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime WrittenAt { get; set; }

        public Blog Blog { get; set; }
        
        public Client Client { get; set; }
        
        public ICollection<BlogCommentAnswer> Answers { get; set; }
    }
}