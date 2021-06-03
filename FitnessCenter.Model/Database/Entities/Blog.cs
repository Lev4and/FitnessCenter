using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public DateTime CreatedAt  { get; set; }

        public ICollection<BlogComment> Comments { get; set; }
    }
}