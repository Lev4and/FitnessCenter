using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class BlogCommentAnswer
    {
        public Guid Id { get; set; }
        
        public Guid? CommentId { get; set; }
        
        public Guid? ClientId { get; set; }
        
        [Required]
        public string Message { get; set; }

        public DateTime WrittenAt { get; set; }
        
        public BlogComment Comment { get; set; }
        
        public Client Client { get; set; }
    }
}