using FitnessCenter.Model.Database.Repository.Abstract;

namespace FitnessCenter.Model.Database
{
    public class DataManager
    {
        public IBlogCommentAnswersRepository BlogCommentAnswers { get; private set; }
        
        public IBlogCommentsRepository BlogComments { get; private set; }
        
        public IBlogRepository Blog { get; private set; }
        
        public IClientServicesRepository ClientServices { get; private set; }
        
        public IClientsRepository Clients { get; private set; }
        
        public IGendersRepository Genders { get; private set; }

        public IRolesRepository Roles { get; private set; }
        
        public IServiceCategoriesRepository ServiceCategories { get; private set; }
        
        public IServicesRepository Services { get; private set; }
        
        public ITestimonialsRepository Testimonials { get; private set; }
        
        public ITrainerCategoriesRepository TrainerCategories { get; private set; }
        
        public ITrainersRepository Trainers { get; private set; }

        public IUsersRepository Users { get; private set; }

        public DataManager(IBlogCommentAnswersRepository blogCommentAnswers, IBlogCommentsRepository blogComments, 
            IBlogRepository blog, IClientServicesRepository clientServices, IClientsRepository clients, 
            IGendersRepository genders, IRolesRepository roles, IServiceCategoriesRepository serviceCategories, 
            IServicesRepository services, ITestimonialsRepository testimonials, ITrainerCategoriesRepository trainerCategories, 
            ITrainersRepository trainers, IUsersRepository users)
        {
            BlogCommentAnswers = blogCommentAnswers;
            BlogComments = blogComments;
            Blog = blog;
            ClientServices = clientServices;
            Clients = clients;
            Genders = genders;
            Roles = roles;
            ServiceCategories = serviceCategories;
            Services = services;
            Testimonials = testimonials;
            TrainerCategories = trainerCategories;
            Trainers = trainers;
            Users = users;
        }
    }
}
