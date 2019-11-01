using ProjektGruppF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGruppF.Controllers
{
    public class TestcvFreelancerController : Controller
    {
        // GET: TestcvFreelancer
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Databaseexample()
        //{
        //    ProjektGruppFEntities dbModel = new ProjektGruppFEntities();
        //    var getDrivers_licenseOptions = dbModel.cv.ToList();
        //    SelectList list = new SelectList(getDrivers_licenseOptions, "drivers_license");// alla parametrers van Cv?
        //    ViewBag.drivers_license = list;
        //    return View();
        //}

        //        public JsonResult SaveUser(TUser UserData)
        //        {
        //            int Userid = 0;
        //            try
        //            {
        //                if (UserData != null)
        //                {
        //                    using (ProjektGruppFEntities db = new ProjektGruppFEntities())
        //                    {
        //                        //saves the user data and returns userid from procedure.  
        //                        var id = db.Database.SqlQuery("sp_InsertUser @Name,@Email,@PhoneNumber",
        //                            new SqlParameter("", UserData.Name),
        //                            new SqlParameter("Email", UserData.Email),
        //                            new SqlParameter("PhoneNumber", UserData.PhoneNumber)).Single();
        //                        Userid = id;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            return Json(Userid, JsonRequestBehavior.AllowGet);
        //        }
        //        //saves Address data TAddress table  
        //        public JsonResult SaveAddress(TAddress AddressData)
        //        {
        //            bool result = false;
        //            try
        //            {
        //                if (AddressData != null)
        //                {
        //                    using (ProjektGruppFEntities db = new ProjektGruppFEntities())
        //                    {
        //                        db.TAddresses.Add(AddressData);
        //                        db.SaveChanges();
        //                        result = true;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //        //saves orderdata in TOrders table  
        //        public JsonResult SaveOrders(TOrder OrdersData)
        //        {
        //            bool result = false;
        //            try
        //            {
        //                if (OrdersData != null)
        //                {
        //                    using (ProjektGruppFEntities db = new ProjektGruppFEntities())
        //                    {
        //                        db.TOrders.Add(OrdersData);
        //                        db.SaveChanges();
        //                        result = true;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            return Json(result, JsonRequestBehavior.AllowGet);
        //        }
        //    }
    }
}