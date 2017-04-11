using Resturant.BAL;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

       
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Career()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Catering()
        {
            return View();
        }
        public ActionResult Location()
        {
            return View();
        }
        public ActionResult OrderOnline()
        {
            return View();
        }
        
        //public ActionResult ValidatePostcode(string postcode)
        //{
        //    new BLBranch().isValidPostcode(postcode);
        //    return null;
        //}

        //public ActionResult DisplayMenu()
        //{
        //    Cousine cousine = new BLFood().getCousineById(1);
        //    return null;
        //} 

        public ActionResult Login()
        {
            return View();
        }
    }
}
