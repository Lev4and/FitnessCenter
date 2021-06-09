using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Components
{
    public class NavBarAccount : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Клиент"))
                {
                    return View("Authenticated");
                }
            }

            return View("Default");
        }
    }
}
