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
                Datos.Consulta("Select U.Id, U.Nombre, U.Mail, U.Contraseña From USUARIO U");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Username = (string)Datos.Lector["Nombre"];
                    aux.Mail = (string)Datos.Lector["Mail"];
                    aux.Contraseña = (string)Datos.Lector["Contraseña"];
                    //aux.DatosUsuario = (DatosUsuario)Datos.Lector[""];                   
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
        
        public bool Registro(Usuario user,ref string mensaje)
        {
            bool registrado;

            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.setearProcedimiento("sp_RegistrarUsuario");
                datos.SetParametros("usuario", user.Username);
                datos.SetParametros("pass", user.Contraseña);
                datos.SetParametros("mail", user.Mail);
                datos.SetParametros("admin", user.EsAdmin);

                datos.Comando.Parameters.Add("Registrado", System.Data.SqlDbType.Bit).Direction = System.Data.ParameterDirection.Output;
                datos.Comando.Parameters.Add("Mensaje", System.Data.SqlDbType.VarChar,100).Direction = System.Data.ParameterDirection.Output;

                datos.EjecutarAccion();

                registrado = Convert.ToBoolean(datos.Comando.Parameters["Registrado"].Value);
                mensaje = datos.Comando.Parameters["Mensaje"].Value.ToString();

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
