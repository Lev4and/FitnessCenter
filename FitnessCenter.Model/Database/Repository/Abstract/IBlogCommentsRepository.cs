using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IBlogCommentsRepository
    {
        bool SaveBlogComment(BlogComment entity);

        BlogComment GetBlogCommentById(Guid id, bool track = false);
        
        IQueryable<BlogComment> GetBlogCommentsByBlogId(Guid blogId, bool track = false);

        IQueryable<BlogComment> GetBlogCommentsByBlogId(Guid blogId, int itemsPerPage, int numberPage, 
            bool track = false);
        
        IQueryable<BlogComment> GetBlogCommentsByClientId(Guid clientId, bool track = false);
        
        IQueryable<BlogComment> GetBlogCommentsByClientId(Guid clientId, int itemsPerPage, int numberPage, 
            bool track = false);

        void DeleteBlogCommentById(Guid id);
    }
}