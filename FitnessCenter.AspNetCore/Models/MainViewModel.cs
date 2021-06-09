using FitnessCenter.Model.Database.Entities;
using System.Collections.Generic;

namespace FitnessCenter.AspNetCore.Models
{
    public class MainViewModel
    {
        public List<Testimonial> Testimonials { get; set; }

        public List<Service> Services { get; set; }

        public List<Trainer> Trainers { get; set; }

        public List<Blog> Blog { get; set; }
    }
}
