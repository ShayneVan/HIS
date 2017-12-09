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
            string id = Request.Form["IdNumber"];
            string phone = Request.Form["Phone"];
            PatientInfo patientinfo = new PatientInfo();
            patientinfo.PatientName = name;
            patientinfo.PatientID = id;
            patientinfo.PatientPhone = phone;
            BaseClass bc = new BaseClass();
            bc.SaveReservation(patientinfo);
            //return Content("预约成功！");
            return View("Suceed");
        }
    }
}