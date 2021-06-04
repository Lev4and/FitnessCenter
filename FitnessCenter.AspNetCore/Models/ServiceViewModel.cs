using FitnessCenter.Model.Database.Entities;
using System.Collections.Generic;

namespace FitnessCenter.AspNetCore.Models
{
    public class ServiceViewModel
    {
        public Service Service { get; set; }

        public List<ServiceCategory> Categories { get; set; }
    }
}
