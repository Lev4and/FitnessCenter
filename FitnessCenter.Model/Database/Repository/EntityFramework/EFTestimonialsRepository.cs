using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFTestimonialsRepository : ITestimonialsRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFTestimonialsRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool ContainsTestimonialByClientId(Guid clientId)
        {
            return _context.Testimonials.SingleOrDefault(testimonial => testimonial.ClientId == clientId) != null;
        }

        public bool SaveTestimonial(Testimonial entity)
        {
            if (entity.Id == default)
            {
                if (!ContainsTestimonialByClientId(entity.ClientId))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetTestimonialById(entity.Id);

                if (oldVersionEntity.ClientId != entity.ClientId)
                {
                    if (!ContainsTestimonialByClientId(entity.ClientId))
                    {
                        _context.Entry(entity).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        _context.Entry(entity).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
            }

            return false;
        }

        public Testimonial GetTestimonialById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.Testimonials.SingleOrDefault(testimonial => testimonial.Id == id);
            }
            else
            {
                return _context.Testimonials.AsNoTracking().SingleOrDefault(testimonial => testimonial.Id == id);
            }
        }

        public Testimonial GetTestimonialByClientId(Guid clientId, bool track = false)
        {
            if (track)
            {
                return _context.Testimonials.SingleOrDefault(testimonial => testimonial.ClientId == clientId);
            }
            else
            {
                return _context.Testimonials.AsNoTracking().SingleOrDefault(testimonial => 
                    testimonial.ClientId == clientId);
            }
        }

        public IQueryable<Testimonial> GetTestimonials(bool track = false)
        {
            if (track)
            {
                return _context.Testimonials
                    .Include(testimonial => testimonial.Client)
                    .ThenInclude(client => client.Gender)
                    .OrderByDescending(testimonial => testimonial.WrittenAt);
            }
            else
            {
                return _context.Testimonials
                    .Include(testimonial => testimonial.Client)
                    .ThenInclude(client => client.Gender)
                    .OrderByDescending(testimonial => testimonial.WrittenAt)
                    .AsNoTracking();
            }
        }

        public IQueryable<Testimonial> GetTestimonials(int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.Testimonials
                    .Include(testimonial => testimonial.Client)
                    .ThenInclude(client => client.Gender)
                    .OrderByDescending(testimonial => testimonial.WrittenAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.Testimonials
                    .Include(testimonial => testimonial.Client)
                    .ThenInclude(client => client.Gender)
                    .OrderByDescending(testimonial => testimonial.WrittenAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public void DeleteTestimonialById(Guid id)
        {
            _context.Testimonials.Remove(GetTestimonialById(id));
            _context.SaveChanges();
        }
    }
}