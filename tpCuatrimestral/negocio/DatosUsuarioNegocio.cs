using Clases;
using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    public class DatosUsuarioNegocio
    {
        public List<DatosUsuario> Listar()
        {
            List<DatosUsuario> lista = new List<DatosUsuario>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("SELECT DU.ID_Usuario, DU.Nombre, DU.Apellido, DU.Telefono FROM Datos_Usuario DU");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    DatosUsuario aux = new DatosUsuario();
                    aux.id = (int)Datos.Lector["ID_Usuario"];
                    aux.Nombres = (string)Datos.Lector["Nombre"];
                    aux.Apellidos = (string)Datos.Lector["Apellido"];
                    aux.Telefono = (string)Datos.Lector["Telefono"];
                    
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public DatosUsuario Buscar_x_Usuario(int UserId)
        {
            DatosUsuario aux = null;
            AccesoSQL Datos = new AccesoSQL();
            try
            {
                Datos.Consulta("SELECT DU.ID_Usuario, DU.Nombre, DU.Apellido, DU.Telefono FROM Datos_Usuario DU WHERE DU.ID_Usuario = " + UserId);
                Datos.EjecutarLectura();
                while (Datos.Lector.Read())
                {
                    aux = new DatosUsuario();
                    aux.Id = (int)Datos.Lector["ID_Usuario"];
                    aux.Nombres = (string)Datos.Lector["Nombre"];
                    aux.Apellidos = (string)Datos.Lector["Apellido"];
                    aux.Telefono = (string)Datos.Lector["Telefono"];
                    
                                        
                }
                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public bool Agregar(DatosUsuario nuevo, ref string  Mensaje)///Devuelve un bool si carga y no carga el id de Direccion
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("INSERT INTO Datos_Usuario (ID_Usuario, Nombre, Apellido, Telefono) VALUES( @ID, @Nombre, @Apellido, @Telefono)");
                datos.SetParametros("@ID", nuevo.Id);
                datos.SetParametros("@Nombre", nuevo.Nombres);
                datos.SetParametros("@Apellido", nuevo.Apellidos);
                datos.SetParametros("@Telefono", nuevo.Telefono);
                datos.EjecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.ToString();
                return false;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Eliminar(int Id)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("DELETE FROM Datos_Usuario WHERE ID_Usuario =" + Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(DatosUsuario datosUsuario)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("UPDATE Datos_Usuario SET Nombre = @nombre, Apellido = @apellido, Telefono = @telefono WHERE ID_Usuario = @ID ");
                datos.SetParametros("nombre", datosUsuario.Nombres);
                datos.SetParametros("apellido", datosUsuario.Apellidos);
                datos.SetParametros("telefono", datosUsuario.Telefono);
                datos.SetParametros("ID", datosUsuario.Id);
                
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
