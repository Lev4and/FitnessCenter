using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface ITestimonialsRepository
    {
        bool ContainsTestimonialByClientId(Guid clientId);

        bool SaveTestimonial(Testimonial entity);

        Testimonial GetTestimonialById(Guid id, bool track = false);

        Testimonial GetTestimonialByClientId(Guid clientId, bool track = false);

        IQueryable<Testimonial> GetTestimonials(bool track = false);

        IQueryable<Testimonial> GetTestimonials(int itemsPerPage, int numberPage, bool track = false);

        void DeleteTestimonialById(Guid id);
    }
}