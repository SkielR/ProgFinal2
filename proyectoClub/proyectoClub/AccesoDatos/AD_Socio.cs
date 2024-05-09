using proyectoClub.Models;
using proyectoClub.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace proyectoClub.AccesoDatos
{
    public class AD_Socio
    {
        public static bool InsertarSocio(socio au) 
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try 
            {
                SqlCommand cmd = new SqlCommand(); 

                string consulta = "INSERT INTO Socios VALUES(@Nombre,@Apellido,@IdTipoDocumento,@NroDocumento,@IdDeporte)";
                cmd.Parameters.Clear();

                
                cmd.Parameters.AddWithValue("@Nombre", au.nombre);
                cmd.Parameters.AddWithValue("@Apellido", au.apellido);
                cmd.Parameters.AddWithValue("@IdTipoDocumento", au.idTipoDocumento);
                cmd.Parameters.AddWithValue("@NroDocumento", au.numero);
                cmd.Parameters.AddWithValue("@IdDeporte", au.idDeporte); 

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open(); 
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                resultado = true;

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


        public static List<socio> ObtenerListaSocio() 
        {
            List<socio> resultado = new List<socio>(); 
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion); 
            try 
            {
                SqlCommand cmd = new SqlCommand(); 

                string consulta = "SELECT * FROM Socios";  //VER
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
                        socio aux = new socio(); 
                        
                        aux.idSocio = int.Parse(dr["Id"].ToString()); 
                        aux.nombre = dr["Nombre"].ToString();
                        aux.apellido = dr["Apellido"].ToString();
                        aux.idTipoDocumento = int.Parse(dr["IdTipoDocumento"].ToString());
                        aux.numero = dr["NroDocumento"].ToString();
                        aux.idDeporte = int.Parse(dr["IdDeporte"].ToString());

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

        public static List<deporteItemVM> ObtenerListaDeporte()  
        {
            List<deporteItemVM> resultado = new List<deporteItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try // creamos try catch
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM Deportes";
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
                        
                        aux.idDeporte = int.Parse(dr["Id"].ToString()); 
                        aux.nombre = dr["Nombre"].ToString();


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


        public static List<dniItemVM> ObtenerListaDocumento()
        {
            List<dniItemVM> resultado = new List<dniItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try // creamos try catch
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM TiposDocumentos";
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
                        dniItemVM aux = new dniItemVM();

                        aux.idTipoDocumento = int.Parse(dr["Id"].ToString());
                        aux.nombre = dr["Nombre"].ToString();
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