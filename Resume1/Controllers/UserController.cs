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

        #region CreateUser

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
        #endregion

        #region EditUser
        [HttpGet("EditUser/{Id}")]
        public IActionResult EditUser(int Id)
        {
            if (Id > 0)
            {
                if (userService.IsExist(Id))
                {
                    User user=userService.GetUserById(Id);
                    return View(user);
                }
                else
                {
                    // Id not found !
                    return RedirectToAction("ShowUser");
                }
            }
            else
            {
                // Id not found !
                return RedirectToAction("ShowUser");
            
            }

        }

        [Route("EditUser")]
        [Route("EditUser/{id}")]
        [HttpPost]
        public IActionResult EditUser(User model)
        {
            User user = userService.GetUserById(model.Id);
            if (user == null)
            {
                return RedirectToAction("ShowUser");
            }
            else
            {
                bool isChanged = false;
                if (!user.FullName.Equals(model.FullName))
                    user.FullName = model.FullName;
                isChanged = true;
                if (!user.Password.Equals(model.Password))
                    user.Password = model.Password;
                isChanged = true;
                if (isChanged)
                    userService.UpdateUser(user);

                return RedirectToAction("ShowUser");

            }
        }
        #endregion

    }
}
