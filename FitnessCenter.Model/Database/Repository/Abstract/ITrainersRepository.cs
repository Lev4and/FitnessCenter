using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface ITrainersRepository
    {
        bool SaveTrainer(Trainer entity);

        Trainer GetTrainerById(Guid id, bool track = false);

        IQueryable<Trainer> GetTrainers(bool track = false);

        IQueryable<Trainer> GetTrainers(int itemsPerPage, int numberPage, bool track = false);

        void DeleteTrainerById(Guid id);
    }
}