using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Resume1.core.Services.Implementation;
using Resume1.core.Services.Interfaces;
using Resume1.domain.Models.Auth;

namespace Resume1.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }



        [HttpGet("ShowUser")]
        public ActionResult ShowUser(string SuccessMessage, string ErrorMessage)
        {
            if (!string.IsNullOrEmpty(SuccessMessage))
                ViewBag.SuccessMessage = SuccessMessage;

            if (!string.IsNullOrEmpty(ErrorMessage))
                ViewBag.ErrorMessage = ErrorMessage;

            List<User> users = userService.GetUsers();
            return View(users);
        }

        #region CreateUser
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
                    User user = userService.GetUserById(Id);
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
                {

                    userService.UpdateUser(user);
                    return RedirectToAction("ShowUser", "User", new { SuccessMessage = "User added successFully " });
                }
                else
                {

                    return RedirectToAction("ShowUser", "User", new { ErrorMessage = "User not added " });
                }



            }
        }
        #endregion

        #region Delete User
        [HttpPost("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if(id > 0)
                {
                    User user = userService.GetUserById(id);
                    if(user != null)
                    {
                        userService.DeleteUsers(user);
                        return Ok("Deleted successfully ");//// 200
                    }
                    else
                    {
                        return BadRequest("error , user not found");
                    }


                }
                else
                {
                    return BadRequest("error , user not found");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest("error : "+ex.Message.ToList());//// 400
            }
        }
        #endregion

    }
}
