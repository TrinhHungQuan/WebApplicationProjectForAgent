using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplicationProjectAgent.Models;


namespace WebApplicationProjectAgent.Controllers
{
    
    public class HomeController : Controller
    {
        SellingPhoneEntities1 db = new SellingPhoneEntities1();

        [Authorize]
        public ActionResult Index()
        {
            return View(db.Goods.ToList());
        }

        [Authorize]
        public ActionResult OrderStatus()
        {
            var agentId = Session["AgentID"];
            var orders = db.Orders.Where(o => o.AgentID == agentId).ToList();
            return View(orders);
        }

        

       
       
    }
}