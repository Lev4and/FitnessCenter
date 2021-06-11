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

        public IDaysOfWeekRepository DaysOfWeek { get; private set; }
        
        public IGendersRepository Genders { get; private set; }

        public IRolesRepository Roles { get; private set; }
        
        public IServiceCategoriesRepository ServiceCategories { get; private set; }
        
        public IServicesRepository Services { get; private set; }
        
        public ITestimonialsRepository Testimonials { get; private set; }
        
        public ITrainerCategoriesRepository TrainerCategories { get; private set; }

        public ITrainerSchedulesRepository TrainerSchedules { get; private set; }

        public ITrainerServicesRepository TrainerServices { get; private set; }
        
        public ITrainersRepository Trainers { get; private set; }

        public IUsersRepository Users { get; private set; }

        public DataManager(IBlogCommentAnswersRepository blogCommentAnswers, IBlogCommentsRepository blogComments, 
            IBlogRepository blog, IClientServicesRepository clientServices, IClientsRepository clients, IDaysOfWeekRepository daysOfWeek,
            IGendersRepository genders, IRolesRepository roles, IServiceCategoriesRepository serviceCategories, 
            IServicesRepository services, ITestimonialsRepository testimonials, ITrainerCategoriesRepository trainerCategories, 
            ITrainerSchedulesRepository trainerSchedules, ITrainerServicesRepository trainerServices, ITrainersRepository trainers, IUsersRepository users)
        {
            BlogCommentAnswers = blogCommentAnswers;
            BlogComments = blogComments;
            Blog = blog;
            ClientServices = clientServices;
            Clients = clients;
            DaysOfWeek = daysOfWeek;
            Genders = genders;
            Roles = roles;
            ServiceCategories = serviceCategories;
            Services = services;
            Testimonials = testimonials;
            TrainerCategories = trainerCategories;
            TrainerSchedules = trainerSchedules;
            TrainerServices = trainerServices;
            Trainers = trainers;
            Users = users;
        }
    }
}
