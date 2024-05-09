using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoClub.ViewModel
{
    public class InfoGralVM
    {
        public List<deporteItemVM> listaDeporte{ get; set; }
        


        public void CargarVariables()
        {

            listaDeporte = AccesoDatos.AD_Reporte.ObtenerCantidadDeporte();//listaMarca es la varialble de arriba y lo otro esta ad_reporte.metodo
                                                                           //      listaPersona = AccesoDatos.AD_Reportes.ObtenerReportePersona();
        }

        public InfoGralVM() //reportes
        {
            listaDeporte = new List<deporteItemVM>();
            // listaPersona = new List<PersonaItemVM>();
            CargarVariables();
        }
    }
}