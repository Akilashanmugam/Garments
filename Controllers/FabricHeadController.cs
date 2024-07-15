using System.Web.Mvc;
using Smart.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Smart.Controllers
{
    public class FabricHeadController : Controller
    {
        readonly FabricHeadDBHandle MHDB = new FabricHeadDBHandle();

        // GET: FabricHead
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var Fabric = MHDB.List();
            return Json(Fabric, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(FabricHeadModel Fabric)
        {
            return Json(MHDB.Add(Fabric), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var Fabric = MHDB.List().Find(x => x.FabricId.Equals(Id));
            return Json(Fabric, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(FabricHeadModel Fabric)
        {
            return Json(MHDB.Update(Fabric), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(MHDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}