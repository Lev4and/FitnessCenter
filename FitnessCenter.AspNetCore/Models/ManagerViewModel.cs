using Microsoft.AspNetCore.Identity;

namespace FitnessCenter.AspNetCore.Models
{
    public class ManagerViewModel
    {
        public IdentityUser Manager { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
