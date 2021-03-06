using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IRolesRepository
    {
        IdentityRole GetRoleByName(string name, bool track = false);

        IQueryable<IdentityRole> GetRoles(bool track = false);
    }
}
