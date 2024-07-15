using System.Web.Mvc;
using Smart.Models;
using System.Collections.Generic;
using System.Linq;
using System;
namespace Smart.Controllers
{
    public class CompanyHeadController : Controller
    {
        readonly CompanyHeadDBHandle CHDB = new CompanyHeadDBHandle();
       
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var company = CHDB.List();
            return Json(company, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(CompanyHeadModel company)
        {
            return Json(CHDB.Add(company), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var company = CHDB.List().Find(x => x.CompanyId.Equals(Id));
            return Json(company, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(CompanyHeadModel company)
        {
            return Json(CHDB.Update(company), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(CHDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}