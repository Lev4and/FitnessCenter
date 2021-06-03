using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IServiceCategoriesRepository
    {
        bool ContainsServiceCategoryByName(string name);

        bool SaveServiceCategory(ServiceCategory entity);

        ServiceCategory GetServiceCategoryById(Guid id, bool track = false);

        IQueryable<ServiceCategory> GetServiceCategories(bool track = false);

        void DeleteServiceCategoryById(Guid id);
    }
}