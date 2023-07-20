using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using negocio;
using dominio;

namespace negocio
{
    public class TokensNegocio
    {
        public void Cargar(string token, string mail)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("INSERT INTO Tokens (Token, Mail) VALUES(@token, @mail)");
                datos.SetParametros("@token", token);
                datos.SetParametros("@mail", mail);
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

        public string BuscarMail_x_Token(string token)
        {
            AccesoSQL datos = new AccesoSQL();
            string mail = "";
            try
            {
                datos.Consulta("Select T.Mail FROM Tokens T Where T.Token = @token");
                datos.SetParametros("token", token);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    mail = (string)datos.Lector["Mail"];
                }
                return mail;
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

        public void UpdatePass_x_Token(string token, string pass)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("Update Usuario\r\nSET Contraseña = @pass FROM Usuario Inner JOIN Tokens ON Tokens.Mail = Usuario.Mail Where Tokens.Token = @token");
                datos.SetParametros("@token", token);
                datos.SetParametros("@pass", pass);
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
