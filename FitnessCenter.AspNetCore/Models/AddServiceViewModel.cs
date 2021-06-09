using FitnessCenter.Model.Database.Entities;
using System;
using System.Collections.Generic;

namespace FitnessCenter.AspNetCore.Models
{
    public class AddServiceViewModel
    {
        public Guid ClientId { get; set; }

        public Guid ServiceId { get; set; }

        public List<Service> Services { get; set; }
    }
}
