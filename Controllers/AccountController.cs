using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.DBModel;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities objUserDBEntities = new UserDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                User objUser = new User();
                objUser.FirstName = objUserModel.FirstName;
                objUser.LastName = objUserModel.LastName;
                objUser.Email = objUserModel.Email;
                objUser.Password = objUserModel.Password;
                objUser.CreatedOn = DateTime.Now;
                objUserDBEntities.Users.Add(objUser);
                objUserDBEntities.SaveChanges();
                objUserModel.message = "successfull registered";
                return View(objUserModel);
            } 
            return View();
        }
        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if(ModelState.IsValid)
            {
                if(objUserDBEntities.Users.Where(m => m.Email == objLoginModel.Email && m.Password==objLoginModel.password).FirstOrDefault()==null)
                {
                    ModelState.AddModelError("Error", "Email and password is not matching");
                    return View();
                }
                else
                {
                    Session["email"] = objLoginModel.Email;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}