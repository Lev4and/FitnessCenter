using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFBlogCommentAnswersRepository : IBlogCommentAnswersRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFBlogCommentAnswersRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool SaveBlogCommentAnswer(BlogCommentAnswer entity)
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

        public BlogCommentAnswer GetBlogCommentAnswerById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.BlogCommentAnswers.SingleOrDefault(answer => answer.Id == id);
            }
            else
            {
                return _context.BlogCommentAnswers.AsNoTracking().SingleOrDefault(answer => answer.Id == id);
            }
        }

        public IQueryable<BlogCommentAnswer> GetBlogCommentAnswersByCommentId(Guid commentId, bool track = false)
        {
            if (track)
            {
                return _context.BlogCommentAnswers
                    .Include(answer => answer.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(answer => answer.CommentId == commentId)
                    .OrderBy(answer => answer.WrittenAt);
            }
            else
            {
                return _context.BlogCommentAnswers
                    .Include(answer => answer.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(answer => answer.CommentId == commentId)
                    .OrderBy(answer => answer.WrittenAt)
                    .AsNoTracking();
            }
        }

        public IQueryable<BlogCommentAnswer> GetBlogCommentAnswersByCommentId(Guid commentId, int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.BlogCommentAnswers
                    .Include(answer => answer.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(answer => answer.CommentId == commentId)
                    .OrderBy(answer => answer.WrittenAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.BlogCommentAnswers
                    .Include(answer => answer.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(answer => answer.CommentId == commentId)
                    .OrderBy(answer => answer.WrittenAt)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public void DeleteBlogCommentAnswerById(Guid id)
        {
            _context.BlogCommentAnswers.Remove(GetBlogCommentAnswerById(id));
            _context.SaveChanges();
        }
    }
}