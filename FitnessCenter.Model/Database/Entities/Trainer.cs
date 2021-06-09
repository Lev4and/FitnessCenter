using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class Trainer
    {
        public Guid Id { get; set; }
        
        public Guid GenderId { get; set; }
        
        public Guid CategoryId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Photo { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public string VKontakteUrl { get; set; }
        
        public string InstagramUrl { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public Gender Gender { get; set; }
        
        public TrainerCategory Category { get; set; }

        public int GetAge()
        {
            if (DateOfBirth < DateTime.Now)
            {
                if (DateTime.Now.Year - DateOfBirth.Year > 0)
                {
                    return DateTime.Now.Year - DateOfBirth.Year - 1;
                }
                else
                {
                    return 0;
                }
            }

            return DateTime.Now.Year - DateOfBirth.Year;
        }
    }
}