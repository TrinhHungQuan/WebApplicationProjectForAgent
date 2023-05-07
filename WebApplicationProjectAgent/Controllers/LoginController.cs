using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplicationProjectAgent.Models;

namespace WebApplicationProjectAgent.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        SellingPhoneEntities1 db = new SellingPhoneEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Agent log)
        {

            var user = db.Agents.FirstOrDefault(x => x.AgentEmail == log.AgentEmail && x.PasswordAgent == log.PasswordAgent);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(log.AgentEmail, false);
                Session["AgentID"] = user.AgentID;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }


    }
}