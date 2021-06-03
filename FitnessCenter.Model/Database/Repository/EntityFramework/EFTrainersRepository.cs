using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFTrainersRepository : ITrainersRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFTrainersRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool SaveTrainer(Trainer entity)
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

        public Trainer GetTrainerById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.Trainers.SingleOrDefault(trainer => trainer.Id == id);
            }
            else
            {
                return _context.Trainers.AsNoTracking().SingleOrDefault(trainer => trainer.Id == id);
            }
        }

        public IQueryable<Trainer> GetTrainers(bool track = false)
        {
            if (track)
            {
                return _context.Trainers
                    .Include(trainer => trainer.Gender)
                    .Include(trainer => trainer.Category)
                    .OrderBy(trainer => trainer.Category.Name)
                    .ThenBy(trainer => trainer.Name);
            }
            else
            {
                return _context.Trainers
                    .Include(trainer => trainer.Gender)
                    .Include(trainer => trainer.Category)
                    .OrderBy(trainer => trainer.Category.Name)
                    .ThenBy(trainer => trainer.Name)
                    .AsNoTracking();
            }
        }

        public IQueryable<Trainer> GetTrainers(int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.Trainers
                    .Include(trainer => trainer.Gender)
                    .Include(trainer => trainer.Category)
                    .OrderBy(trainer => trainer.Category.Name)
                    .ThenBy(trainer => trainer.Name)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.Trainers
                    .Include(trainer => trainer.Gender)
                    .Include(trainer => trainer.Category)
                    .OrderBy(trainer => trainer.Category.Name)
                    .ThenBy(trainer => trainer.Name)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public void DeleteTrainerById(Guid id)
        {
            _context.Trainers.Remove(GetTrainerById(id));
            _context.SaveChanges();
        }
    }
}