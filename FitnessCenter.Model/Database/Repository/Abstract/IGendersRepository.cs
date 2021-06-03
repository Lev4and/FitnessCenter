using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IGendersRepository
    {
        bool ContainsGenderByName(string name);

        bool SaveGender(Gender entity);

        Gender GetGenderById(Guid id, bool track = false);

        IQueryable<Gender> GetGenders(bool track = false);

        void DeleteGenderById(Guid id);
    }
}