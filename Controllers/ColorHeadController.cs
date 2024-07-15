using System.Web.Mvc;
using Smart.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Smart.Controllers
{
    public class ColorHeadController : Controller
    {
        readonly ColorHeadDBHandle CHDB = new ColorHeadDBHandle();

        // GET: ColorHead
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var Color = CHDB.List();
            return Json(Color, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ColorHeadModel Color)
        {
            return Json(CHDB.Add(Color), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var Color = CHDB.List().Find(x => x.ColorId.Equals(Id));
            return Json(Color, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ColorHeadModel Color)
        {
            return Json(CHDB.Update(Color), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(CHDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}