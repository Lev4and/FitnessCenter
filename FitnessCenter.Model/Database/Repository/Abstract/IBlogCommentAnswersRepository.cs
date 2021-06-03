using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IBlogCommentAnswersRepository
    {
        bool SaveBlogCommentAnswer(BlogCommentAnswer entity);

        BlogCommentAnswer GetBlogCommentAnswerById(Guid id, bool track = false);

        IQueryable<BlogCommentAnswer> GetBlogCommentAnswersByCommentId(Guid commentId, bool track = false);
        
        IQueryable<BlogCommentAnswer> GetBlogCommentAnswersByCommentId(Guid commentId, int itemsPerPage, int numberPage, 
            bool track = false);

        void DeleteBlogCommentAnswerById(Guid id);
    }
}