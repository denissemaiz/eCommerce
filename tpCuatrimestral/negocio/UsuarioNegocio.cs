using Clases;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Conexiones
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("SELECT U.ID_Usuario, U.NombreUsuario, U.Mail, U.Contraseña, U.EsAdmin, " +
                    "DU.Nombre, DU.Apellido, D.Calle, D.Altura, D.Localidad, D.CP, D.Provincia, DU.Telefono " +
                    "FROM Usuario U INNER JOIN Datos_Usuario DU ON U.ID_Usuario = DU.ID_Usuario INNER JOIN Direccion D ON DU.ID_Direccion = D.ID_Direccion");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    Direccion auxDir = new Direccion();
                    DatosUsuario auxDat = new DatosUsuario();
                    aux.Id = (int)Datos.Lector["ID_Usuario"];
                    aux.Username = (string)Datos.Lector["NombreUsuario"];
                    aux.Mail = (string)Datos.Lector["Mail"];
                    aux.Contraseña = (string)Datos.Lector["Contraseña"];
                    aux.EsAdmin = (bool)Datos.Lector["EsAdmin"];

                    auxDat.Nombres = (string)Datos.Lector["Nombre"];
                    auxDat.Apellidos = (string)Datos.Lector["Apellido"];
                    auxDat.Telefono = (string)Datos.Lector["Telefono"];

                    auxDir.Calle = (string)Datos.Lector["Calle"];
                    auxDir.Altura = (int)Datos.Lector["Altura"];
                    auxDir.Localidad = (string)Datos.Lector["Localidad"];
                    auxDir.Cp = (int)Datos.Lector["CP"];
                    auxDir.Provincia = (string)Datos.Lector["Provincia"];

                    aux.DireccionUsuario = auxDir;
                    aux.DatosUsuario = auxDat;

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


        public List<Usuario> ListarL()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select U.ID_Usuario, U.NombreUsuario, U.Mail, U.Contraseña from Usuario U");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)Datos.Lector["ID_Usuario"];
                    aux.Username = (string)Datos.Lector["NombreUsuario"];
                    aux.Mail = (string)Datos.Lector["Mail"];
                    aux.Contraseña = (string)Datos.Lector["Contraseña"];


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

        public Usuario ListarLPrueba(int Id)
        {
            //List<Usuario> lista = new List<Usuario>();
            Usuario aux = null;
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select U.Mail, U.ID_Usuario, DU.Nombre, DU.Apellido, DU.Telefono, D.Calle, D.Altura, D.CP, D.Localidad, D.Provincia from Usuario U inner join Datos_Usuario DU on DU.ID_Usuario = U.ID_Usuario inner join Direccion D on D.ID_Direccion = DU.ID_Direccion where U.ID_Usuario =" + Id);
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    aux = new Usuario();
                    DatosUsuario aux2 = new DatosUsuario();
                    Direccion aux3 = new Direccion();

                    aux.Id = (int)Datos.Lector["ID_Usuario"];
                    aux.Mail = (string)Datos.Lector["Mail"];
 
                    aux2.Nombres = (string)Datos.Lector["Nombre"];
                    aux2.Apellidos = (string)Datos.Lector["Apellido"];
                    aux2.Telefono = (string)Datos.Lector["Telefono"];

                    aux3.Calle = (string)Datos.Lector["Calle"];
                    aux3.Altura = (Int16)Datos.Lector["Altura"];
                    aux3.Cp = (Int16)Datos.Lector["CP"];
                    aux3.Localidad = (string)Datos.Lector["Localidad"];
                    aux3.Provincia = (string)Datos.Lector["Provincia"];


                    aux.DatosUsuario = aux2;
                    aux.DireccionUsuario = aux3;

                    
                   
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


        public void Agregar(Usuario nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("INSERT INTO Usuario (NombreUsuario, Mail, Contraseña, EsAdmin) VALUES('" + nuevo.Username + "', '" + nuevo.Mail + "', '" + nuevo.Contraseña + "" +
                    ", '" + nuevo.EsAdmin + "'')");
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

        public void Eliminar(int Id)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("DELETE FROM Datos_Usuario WHERE ID_Usuario = " + Id);
                datos.EjecutarAccion();

                datos.Consulta("DELETE FROM Usuario WHERE ID_Usuario = " + Id);
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

        public void Modificar(Usuario usuario)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("UPDATE Usuario SET NombreUsuario = '" + usuario.Username + "', Mail = '" + usuario.Mail + "', Contraseña = '" + usuario.Contraseña + "'," +
                    " EsAdmin = " + usuario.EsAdmin + " WHERE ID_Usuario =" + usuario.Id);
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

        public List<Usuario> RemoveDuplicadosUsuario(List<Usuario> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Usuario> finalList = new List<Usuario>();
            foreach (Usuario us in inputList)
            {
                if (!uniqueStore.ContainsKey(us.Id.ToString()))
                {
                    uniqueStore.Add(us.Id.ToString(), "0");
                    finalList.Add(us);
                }
            }
            return finalList;
        }
    
        public bool Login(Usuario user)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("Select ID_Usuario, Mail, EsAdmin from Usuario Where NombreUsuario = @user and Contraseña = @pass");
                datos.SetParametros("@user", user.Username);
                datos.SetParametros("@pass", user.Contraseña);

                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["ID_Usuario"];
                    user.Mail = (string)datos.Lector["Mail"];
                    user.EsAdmin = (bool)datos.Lector["EsAdmin"];
                    return true;
                }
                return false;
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

        public bool Registro(Usuario user, ref string mensaje, DatosUsuario userData)
        {
            bool registrado;

            AccesoSQL datos = new AccesoSQL();
            ///Primero intenta generar el nuevo registro de Usuario
            try
            {
                datos.setearProcedimiento("sp_RegistrarUsuario");
                datos.SetParametros("usuario", user.Username);
                datos.SetParametros("pass", user.Contraseña);
                datos.SetParametros("mail", user.Mail);
                datos.SetParametros("admin", user.EsAdmin);

                datos.Comando.Parameters.Add("Registrado", System.Data.SqlDbType.Bit).Direction = System.Data.ParameterDirection.Output;
                datos.Comando.Parameters.Add("Mensaje", System.Data.SqlDbType.VarChar,100).Direction = System.Data.ParameterDirection.Output;

                userData.Id = datos.EjecutarScalar(); ///Obtengo el ID del nuevo usuario

                registrado = Convert.ToBoolean(datos.Comando.Parameters["Registrado"].Value);
                mensaje = datos.Comando.Parameters["Mensaje"].Value.ToString();
                ///Con el ID del nuevo usuario intento generar un registro de DatosUsuario
                try
                {
                    DatosUsuarioNegocio ConexionDatosUsuario = new DatosUsuarioNegocio();
                    if (ConexionDatosUsuario.Agregar(userData, ref mensaje) != true)
                        registrado = false;
                }
                catch (Exception ex)
                {
                    mensaje = ex.ToString();
                    return false;
                }
                return registrado;
            }
            catch (Exception ex )
            {

                mensaje = ex.ToString();
                return false;
            }
            finally
            {
                datos.CerrarConexion();
            }
            
        }
    }
}
