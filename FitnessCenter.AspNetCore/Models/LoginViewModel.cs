using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.AspNetCore.Models
{
    public class LoginViewModel
    {
        public string EmailOrLogin { get; set; }

        public string Password { get; set; }
    }
}
