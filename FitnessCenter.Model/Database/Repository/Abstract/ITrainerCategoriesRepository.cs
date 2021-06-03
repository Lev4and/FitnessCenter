using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface ITrainerCategoriesRepository
    {
        bool ContainsTrainerCategoryByName(string name);

        bool SaveTrainerCategory(TrainerCategory entity);

        TrainerCategory GetTrainerCategoryById(Guid id, bool track = false);

        IQueryable<TrainerCategory> GetTrainerCategories(bool track = false);

        void DeleteTrainerCategoryById(Guid id);
    }
}