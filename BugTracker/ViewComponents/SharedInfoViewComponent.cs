using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Components
{
    public class SharedInfoViewComponent:ViewComponent
    {
        private readonly IBugRepository _bugRepository;
        public SharedInfoViewComponent( IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
