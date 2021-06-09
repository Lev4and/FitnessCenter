using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public Guid GenderId { get; set; }
        
        public string Photo { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public Gender Gender { get; set; }
        
        public Testimonial Testimonial { get; set; }
        
        public ICollection<BlogComment> Comments { get; set; }
        
        public ICollection<ClientService> Services { get; set; }

        public ICollection<BlogCommentAnswer> Answers { get; set; }

        public int GetAge()
        {
            if(DateOfBirth < DateTime.Now)
            {
                if(DateTime.Now.Year -DateOfBirth.Year > 0)
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