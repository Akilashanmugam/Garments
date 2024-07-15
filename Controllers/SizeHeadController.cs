using System.Web.Mvc;
using Smart.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Smart.Controllers
{
    public class SizeHeadController : Controller
    {
        readonly SizeHeadDBHandle SHDB = new SizeHeadDBHandle();

        // GET: SizeHead
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var Size = SHDB.List();
            return Json(Size, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(SizeHeadModel Size)
        {
            return Json(SHDB.Add(Size), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var Size = SHDB.List().Find(x => x.SizeId.Equals(Id));
            return Json(Size, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(SizeHeadModel Size)
        {
            return Json(SHDB.Update(Size), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(SHDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}