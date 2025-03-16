using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Resume1.core.Services.Interfaces;
using Resume1.domain.Models.Auth;
using Resume1.domain.ViewModel.Address;

namespace Resume1.Controllers
{
    public class AddressController : Controller
    {
        private IUserService userService;
        private IAddressService addressService;
        public AddressController(IUserService _userService, IAddressService _addressService)
        {
            userService = _userService;
            addressService = _addressService;
        }
        #region AddressMng


        [HttpGet("AddressMng/{UserId}")]

        public IActionResult AddressMng(int UserId)
        {
            if (UserId > 0)
            {
                if (userService.IsExist(UserId))
                {
                    User user = userService.GetUserById(UserId);
                    ViewBag.user = user;
                    return View();


                }
                else
                {
                    return RedirectToAction("showuser", "user", new { ErrorMessage = " user not found " });
                }

            }
            else
            {
                return RedirectToAction("showuser", "user", new { ErrorMessage = " user not found " });
            }

        }

        [HttpPost("AddressMng/{UserId}")]

        public IActionResult AddressMng(AddressViewModel model)
        {

            if (model.UserId > 0)
            {
                if (userService.IsExist(model.UserId))
                {
                    User user = userService.GetUserById(model.UserId);
                    ViewBag.user = user;
                   // return View();
                   List<Address> addresses = addressService.GetAllByUserId(model.UserId);
                    ViewBag.address = addresses;


                }
                else
                {
                    return RedirectToAction("showuser", "user", new { ErrorMessage = " user not found " });
                }

            }
            else
            {
                return RedirectToAction("showuser", "user", new { ErrorMessage = " user not found " });
            }


            if (ModelState.IsValid)
            {
                try
                {
                    Address address = new Address()
                    {
                        AddressContent = model.AddressContent,
                        UserId = model.UserId
                    };
                    addressService.AddAddress(address);
                    return View();
                    
                }
                catch (Exception ex) {
                    ModelState.AddModelError("AddressContent",ex.ToString());
                    return View(model);

                }

            }
            else
            {
                ModelState.AddModelError("AddressContent", "Address is not valid ");
                return View(model);
            }

        }

        #endregion
    }
}
