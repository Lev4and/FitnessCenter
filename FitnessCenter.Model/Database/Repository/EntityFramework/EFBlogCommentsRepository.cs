using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFBlogCommentsRepository : IBlogCommentsRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFBlogCommentsRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool SaveBlogComment(BlogComment entity)
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

        public BlogComment GetBlogCommentById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.BlogComments.SingleOrDefault(comment => comment.Id == id);
            }
            else
            {
                return _context.BlogComments.AsNoTracking().SingleOrDefault(comment => comment.Id == id);
            }
        }

        public IQueryable<BlogComment> GetBlogCommentsByBlogId(Guid blogId, bool track = false)
        {
            if (track)
            {
                return _context.BlogComments
                    .Include(blog => blog.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(comment => comment.BlogId == blogId)
                    .OrderBy(comment => comment.WrittenAt);
            }
            else
            {
                return _context.BlogComments
                    .Include(blog => blog.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(comment => comment.BlogId == blogId)
                    .OrderBy(comment => comment.WrittenAt)
                    .AsNoTracking();
            }
        }

        public IQueryable<BlogComment> GetBlogCommentsByBlogId(Guid blogId, int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.BlogComments
                    .Include(blog => blog.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(comment => comment.BlogId == blogId)
                    .OrderBy(comment => comment.WrittenAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.BlogComments
                    .Include(blog => blog.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(comment => comment.BlogId == blogId)
                    .OrderBy(comment => comment.WrittenAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public IQueryable<BlogComment> GetBlogCommentsByClientId(Guid clientId, bool track = false)
        {
            if (track)
            {
                return _context.BlogComments
                    .Include(blog => blog.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(comment => comment.ClientId == clientId)
                    .OrderBy(comment => comment.WrittenAt);
            }
            else
            {
                return _context.BlogComments
                    .Include(blog => blog.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(comment => comment.ClientId == clientId)
                    .OrderBy(comment => comment.WrittenAt)
                    .AsNoTracking();
            }
        }

        public IQueryable<BlogComment> GetBlogCommentsByClientId(Guid clientId, int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.BlogComments
                    .Include(blog => blog.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(comment => comment.ClientId == clientId)
                    .OrderBy(comment => comment.WrittenAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.BlogComments
                    .Include(blog => blog.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(comment => comment.ClientId == clientId)
                    .OrderBy(comment => comment.WrittenAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public void DeleteBlogCommentById(Guid id)
        {
            _context.BlogComments.Remove(GetBlogCommentById(id));
            _context.SaveChanges();
        }
    }
}