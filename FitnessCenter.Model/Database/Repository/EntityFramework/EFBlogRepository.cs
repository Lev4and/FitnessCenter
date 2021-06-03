using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFBlogRepository : IBlogRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFBlogRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool SaveBlog(Blog entity)
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

        public Blog GetBlogById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.Blog.SingleOrDefault(blog => blog.Id == id);
            }
            else
            {
                return _context.Blog.AsNoTracking().SingleOrDefault(blog => blog.Id == id);
            }
        }

        public IQueryable<Blog> GetBlog(bool track = false)
        {
            if (track)
            {
                return _context.Blog
                    .OrderByDescending(blog => blog.CreatedAt);
            }
            else
            {
                return _context.Blog
                    .OrderByDescending(blog => blog.CreatedAt)
                    .AsNoTracking();
            }
        }

        public IQueryable<Blog> GetBlog(int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.Blog
                    .OrderByDescending(blog => blog.CreatedAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.Blog
                    .OrderByDescending(blog => blog.CreatedAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public void DeleteBlogById(Guid id)
        {
            _context.Blog.Remove(GetBlogById(id));
            _context.SaveChanges();
        }
    }
}