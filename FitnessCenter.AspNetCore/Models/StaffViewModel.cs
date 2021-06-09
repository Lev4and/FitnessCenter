using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FitnessCenter.AspNetCore.Models
{
    public class StaffViewModel
    {
        public List<IdentityUser> Managers { get; set; }
    }
}
