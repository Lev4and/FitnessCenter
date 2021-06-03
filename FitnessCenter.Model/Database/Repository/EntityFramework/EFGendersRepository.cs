using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFGendersRepository : IGendersRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFGendersRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool ContainsGenderByName(string name)
        {
            return _context.Genders.SingleOrDefault(gender => gender.Name == name) != null;
        }

        public bool SaveGender(Gender entity)
        {
            if (!ContainsGenderByName(entity.Name))
            {
                if (entity.Id == default)
                {
                    _context.Entry(entity).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public Gender GetGenderById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.Genders.SingleOrDefault(gender => gender.Id == id);
            }
            else
            {
                return _context.Genders.AsNoTracking().SingleOrDefault(gender => gender.Id == id);
            }
        }

        public IQueryable<Gender> GetGenders(bool track = false)
        {
            if (track)
            {
                return _context.Genders;
            }
            else
            {
                return _context.Genders.AsNoTracking();
            }
        }

        public void DeleteGenderById(Guid id)
        {
            _context.Genders.Remove(GetGenderById(id));
            _context.SaveChanges();
        }
    }
}