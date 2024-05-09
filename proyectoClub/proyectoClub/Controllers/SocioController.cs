using proyectoClub.AccesoDatos;
using proyectoClub.Models;
using proyectoClub.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoClub.Controllers
{
    public class SocioController : Controller
    {
        // GET: Socio
        public ActionResult altaSocio() // esto es lo 9 poner nombre de la vista //10a aca se agrega lo del combo
        {
            List<deporteItemVM> listaDeporte = AD_Socio.ObtenerListaDeporte();
            List<SelectListItem> itemsCombo = listaDeporte.ConvertAll(d =>
            {


                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.idDeporte.ToString(),
                    Selected = false
                };
            });


            ViewBag.items = itemsCombo;
            return View();


            List<dniItemVM> listaDni = AD_Socio.ObtenerListaDocumento();
            List<SelectListItem> itemsComb = listaDni.ConvertAll(d =>
            {


                return new SelectListItem()
                {
                    Text = d.nombre,
                    Value = d.idTipoDocumento.ToString(),
                    Selected = false
                };
            });


            ViewBag.items = itemsComb;
            return View();
        }
        



        [HttpPost]
        public ActionResult alta(socio model) 
        {
            if (ModelState.IsValid) 
            {
                bool resultado = AD_Socio.InsertarSocio(model);
                                                               
                if (true) 
                {
                    return RedirectToAction("listadoSocio", "socio");
                }

                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult listadoAuto() // 40 renombramos por el nombre de la view pero me tiene q devolver lista paso 41
        {
            List<socio> lista = AD_Socio.ObtenerListaSocio();//41 list<nombre clase> nombre x variable= clase AD. y el metodo

            return View(lista);//41a entre ()agregar nombre de la variable 41
        }
    }
}