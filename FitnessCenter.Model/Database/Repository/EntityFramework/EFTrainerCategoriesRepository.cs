using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFTrainerCategoriesRepository : ITrainerCategoriesRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFTrainerCategoriesRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool ContainsTrainerCategoryByName(string name)
        {
            return _context.TrainerCategories.SingleOrDefault(category => category.Name == name) != null;
        }

        public bool SaveTrainerCategory(TrainerCategory entity)
        {
            if (!ContainsTrainerCategoryByName(entity.Name))
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

        public TrainerCategory GetTrainerCategoryById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.TrainerCategories.SingleOrDefault(category => category.Id == id);
            }
            else
            {
                return _context.TrainerCategories.AsNoTracking().SingleOrDefault(category => category.Id == id);
            }
        }

        public IQueryable<TrainerCategory> GetTrainerCategories(bool track = false)
        {
            if (track)
            {
                return _context.TrainerCategories
                    .OrderBy(category => category.Name);
            }
            else
            {
                return _context.TrainerCategories
                    .OrderBy(category => category.Name)
                    .AsNoTracking();
            }
        }

        public void DeleteTrainerCategoryById(Guid id)
        {
            _context.TrainerCategories.Remove(GetTrainerCategoryById(id));
            _context.SaveChanges();
        }
    }
}