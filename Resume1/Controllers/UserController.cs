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
        [HttpGet("ShowUser")]
        public ActionResult ShowUser()
        {
            List<User> users=userService.GetUsers();
            return View(users);
        }
        [HttpGet("CreateUser")]
        public ActionResult CreateUser()
        {
            return View(new User());
        }
        [HttpPost("CreateUser")]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(user);
                return RedirectToAction("ShowUser");
            }
            else
            {
                return View(user);
            }

        }

    }
}
