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

        public List<DatosUsuario> ListarPrueba(int Id)
        {
            List<DatosUsuario> lista = new List<DatosUsuario>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select DU.ID_Usuario, DU.Nombre, DU.Apellido, DU.Telefono, U.Mail from Datos_Usuario DU inner join Usuario U on U.ID_Usuario = DU.ID_Usuario where DU.ID_Usuario =" + Id);
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    DatosUsuario aux = new DatosUsuario();
                    Usuario auxx = new Usuario();
                    aux.id = (int)Datos.Lector["ID_Usuario"];
                    aux.Nombres = (string)Datos.Lector["Nombre"];
                    aux.Apellidos = (string)Datos.Lector["Apellido"];
                    aux.Telefono = (string)Datos.Lector["Telefono"];
                    auxx.Mail = (string)Datos.Lector["Mail"];
                   

                    //auxDir.Calle = (string)Datos.Lector["Calle"];
                    //auxDir.Altura = (int)Datos.Lector["Altura"];
                    //auxDir.Localidad = (string)Datos.Lector["Localidad"];
                    //auxDir.Cp = (int)Datos.Lector["CP"];
                    //auxDir.Provincia = (string)Datos.Lector["Provincia"];

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
                    aux.id = (int)Datos.Lector["ID_Usuario"];
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

        public void Agregar(DatosUsuario nuevo) 
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("INSERT INTO Datos_Usuario (ID_Usuario, Nombre, Apellido, Telefono) VALUES('" + nuevo.Id + "', '" + nuevo.Nombres + "', " +
                    "'" + nuevo.Apellidos + ", '" + nuevo.Telefono + "'')");
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
                /*Cuando actualizo datos de usuario, debería actualizar la direccion en su tabla? O agrego una nueva direccion a la tabla y le cambio el Id acá?*/
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
