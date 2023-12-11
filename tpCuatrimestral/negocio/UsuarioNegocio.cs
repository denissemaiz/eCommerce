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
                Datos.Consulta("SELECT * FROM Usuario");
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

        public bool VerificarCorreo(string correo)
        {
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("SELECT COUNT(*) FROM Usuario WHERE Mail = @correo");
                Datos.SetParametros("@correo", correo);
                int count = Datos.EjecutarScalar();
                return count > 0;

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

        public bool VerificarPassUsada(string mail, string pass)
        {
            AccesoSQL Datos = new AccesoSQL();
            try
            {
                Datos.Consulta("SELECT COUNT(*) FROM Usuario WHERE Mail = @correo AND Contraseña = @pass");
                Datos.SetParametros("@correo", mail);
                Datos.SetParametros("@pass", pass);
                int count = Datos.EjecutarScalar();
                return count > 0;

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

        public Usuario buscarUsuario_x_Id(int id)
        {
            AccesoSQL datos = new AccesoSQL();
            Usuario usuario = null;
            try
            {
                datos.Consulta("SELECT * FROM Usuario WHERE ID_Usuario = @id");
                datos.SetParametros("@id", id);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = id;
                    usuario.Username = (string)datos.Lector["NombreUsuario"];
                    usuario.Mail = (string)datos.Lector["Mail"];
                    usuario.Contraseña = (string)datos.Lector["Contraseña"];
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuario;
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
                datos.Consulta("UPDATE Usuario SET NombreUsuario = @nombre, Mail = @mail, Contraseña = @pass, EsAdmin = @admin where ID_Usuario = @ID ");
                datos.SetParametros("@nombre", usuario.Username);
                datos.SetParametros("@mail", usuario.Mail);
                datos.SetParametros("@pass", usuario.Contraseña);
                datos.SetParametros("@admin", usuario.EsAdmin);
                datos.SetParametros("@ID", usuario.Id);
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

        public void NuevaContraseña (string Contraseña)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("UPDATE Usuario SET NombreUsuario = @nombre, Mail = @mail, Contraseña = @pass, EsAdmin = @admin where ID_Usuario = @ID ");
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
