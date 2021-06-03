using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class Gender
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<Client> Clients { get; set; }
        
        public ICollection<Trainer> Trainers { get; set; }
    }
}