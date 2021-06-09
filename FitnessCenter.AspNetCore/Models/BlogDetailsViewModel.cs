using FitnessCenter.Model.Database.Entities;
using System;

namespace FitnessCenter.AspNetCore.Models
{
    public class BlogDetailsViewModel
    {
        public Blog Blog { get; set; }

        public Guid? CommentId { get; set; }

        public string Message { get; set; }
    }
}
