using EmployeeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EmployeeProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly EmployeeDBContext context;

        public LoginController(EmployeeDBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TblUser tblUser)
        {
            
                var user=context.TblUsers.Where(i=>i.Username==tblUser.Username && i.Password==tblUser.Password).FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("UserSession",tblUser.Username);
                    
                    return RedirectToAction("DashBoard");
                }

                else
                {
                    ViewBag.User = "Login Failed!!";
                }
           
            return View();
        }
        public IActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.Mysession= HttpContext.Session.GetString("UserSession");
            }
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(TblUser tblUser)
        {

            if(ModelState.IsValid)
            {
                context.TblUsers.Add(tblUser);
                context.SaveChanges();
                TempData["Success"] = "Registerd Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
