using FitnessCenter.Model.Database.Entities;
using System.Collections.Generic;

namespace FitnessCenter.AspNetCore.Models
{
    public class RegisterViewModel
    {
        public string Login { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Client Client { get; set; }

        public List<Gender> Genders { get; set; }
    }
}
