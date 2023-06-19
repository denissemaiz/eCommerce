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
    internal class UsuarioNegocio
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
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Mail = (string)Datos.Lector["Mail"];
                    aux.Contraseña = (string)Datos.Lector["Contraseña"];
                    //aux.Direccion = (Direccion)Datos.Lector[""];                   
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
                datos.Consulta("Select ID_Usuario, NombreUsuario, Contraseña, Mail, EsAdmin, ID_Direccion from Usuario Where NombreUsuario = @user and Contraseña = @pass");
                datos.SetParametros("@user", user.Nombre);
                datos.SetParametros("@pass", user.Contraseña);

                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["ID_Usuario"];
                    user.TipoUsuario =  (int)datos.Lector["EsAdmin"] == 2 ? UserType.ADMIN : UserType.CLIENTE ;
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
    
    }
}
