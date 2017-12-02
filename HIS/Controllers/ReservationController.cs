using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HIS.Models;
using HIS.BLL;

namespace HIS.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetReservationInfo()
        {
            string name = Request.Form["Name"];
            PatientInfo patientinfo = new PatientInfo();
            patientinfo.PatientName = name;
            BaseClass bc = new BaseClass();
            bc.SaveReservation(patientinfo);
            return View();
        }
    }
}