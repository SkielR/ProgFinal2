using proyectoClub.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace proyectoClub.AccesoDatos
{
    public class AD_Reporte
    {
        public static List<deporteItemVM> ObtenerCantidadDeporte() 
        {
            List<deporteItemVM> resultado = new List<deporteItemVM>(); 
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try 
            {
                SqlCommand cmd = new SqlCommand(); 

                string consulta = @"select m.nombre as 'DEPORTE', COUNT(*) as 'CANTIDAD'
                                    FROM Deportes m
                                    join Socios v on v.idDeportes = m.id
                                    group by m.nombre"; 
                cmd.Parameters.Clear();


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open(); 
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader(); 
                if (dr != null)
                { 
                    while (dr.Read())
                    {
                        deporteItemVM aux = new deporteItemVM();
                        
                        aux.nombre = dr["DEPORTE"].ToString();//
                        aux.cantidad = int.Parse(dr["CANTIDAD"].ToString());


                        resultado.Add(aux);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                cn.Close();

            }

            return resultado; 

        }
    }
}