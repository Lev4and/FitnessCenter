using Microsoft.AspNetCore.Identity;

namespace FitnessCenter.AspNetCore.Models
{
    public class ClientViewModel
    {
        public IdentityUser Client { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
