using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class Testimonial
    {
        public Guid Id { get; set; }
        
        public Guid ClientId { get; set; }
        
        [Required]
        public string Message { get; set; }

        public DateTime WrittenAt { get; set; }
        
        public Client Client { get; set; }
    }
}