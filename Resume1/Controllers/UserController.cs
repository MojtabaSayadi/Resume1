using Microsoft.AspNetCore.Mvc;
using Resume1.core.Services.Implementation;
using Resume1.core.Services.Interfaces;
using Resume1.domain.Models.Auth;

namespace Resume1.Controllers
{
    public class UserController: Controller
    {
        private IUserService  userService;

        public UserController(IUserService _userService)
        {
                userService = _userService;
        }
        public ActionResult ShowUser()
        {
            List<User> users=userService.GetUsers();
            return View(users);
        }
      
    }
}
