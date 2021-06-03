using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IBlogRepository
    {
        bool SaveBlog(Blog entity);

        Blog GetBlogById(Guid id, bool track = false);
        
        IQueryable<Blog> GetBlog(bool track = false);

        IQueryable<Blog> GetBlog(int itemsPerPage, int numberPage, bool track = false);

        void DeleteBlogById(Guid id);
    }
}
