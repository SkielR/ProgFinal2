using proyectoClub.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoClub.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            InfoGralVM resultado = new InfoGralVM();//10d
            return View(resultado);
        }
    }
}