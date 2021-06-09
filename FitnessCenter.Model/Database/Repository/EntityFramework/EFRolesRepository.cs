using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFRolesRepository : IRolesRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFRolesRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public IdentityRole GetRoleByName(string name, bool track = false)
        {
            if (track)
            {
                return _context.Roles.SingleOrDefault(role => role.Name == name);
            }
            else
            {
                return _context.Roles.AsNoTracking().SingleOrDefault(role => role.Name == name);
            }
        }

        public IQueryable<IdentityRole> GetRoles(bool track = false)
        {
            if (track)
            {
                return _context.Roles;
            }
            else
            {
                return _context.Roles.AsTracking();
            }
        }
    }
}
