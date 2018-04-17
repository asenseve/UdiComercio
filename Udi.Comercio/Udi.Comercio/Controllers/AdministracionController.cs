using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Udi.Comercio.Controllers
{
    public class AdministracionController : Controller
    {

        public ActionResult Vista2()
        {
            ViewBag.Message = "Esta es mi vista 2";

            return View();
        }

        public ActionResult Tipo()
        {
            ViewBag.Message = "Tipo";

            return View();
        }

        public ActionResult Producto()
        {
            ViewBag.Message = "Productos";

            return View();
        }

    }
}