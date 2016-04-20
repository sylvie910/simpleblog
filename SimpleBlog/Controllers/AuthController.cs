using SimpleBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleBlog.Controllers
{

    public class AuthController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
        //这个方法是GET method
        public ActionResult Login()
        {
            return View();
        }
        //这个方法是POST method
        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            //传入的实参是AuthLogin类型的变量form,有两个属性Username和Password
            //数据从view中的form传到了controller，中间通过model
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            //Authentication并不验证用户名密码是否有授权
            //在有用户名密码输入之后，会产生cookie
            FormsAuthentication.SetAuthCookie(form.Username, true);
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToRoute("home");
        }

    }
}