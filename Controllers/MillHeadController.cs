using System.Web.Mvc;
using Smart.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Smart.Controllers
{
    public class MillHeadController : Controller
    {
        readonly MillHeadDBHandle MHDB = new MillHeadDBHandle();

        // GET: MillHead
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var Mill = MHDB.List();
            return Json(Mill, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(MillHeadModel Mill)
        {
            return Json(MHDB.Add(Mill), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var Mill = MHDB.List().Find(x => x.MillId.Equals(Id));
            return Json(Mill, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(MillHeadModel Mill)
        {
            return Json(MHDB.Update(Mill), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(MHDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}