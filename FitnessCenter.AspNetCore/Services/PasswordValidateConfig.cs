namespace FitnessCenter.AspNetCore.Services
{
    public class PasswordValidateConfig
    {
        public static string Pattern { get; } = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!#№$%^&*]).{5,}$";

        //public static string Pattern { get; } = @"^.*(?=.{5,})(?=.*\\d)(?=.*[!#№$%^&*])(?=.*[a-z])(?=.*[A-Z]).*$\";
    }
}
