using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult guahao()
        {
            return View();
        }
        public ActionResult guahao_next()
        {
            return View();
        }
        public ActionResult guahaoByD()
        {
            return View();
        }
        public ActionResult Suceed()
        {
            return View();
        }
        public ActionResult Record()
        {
            return View();
        }
    }
}