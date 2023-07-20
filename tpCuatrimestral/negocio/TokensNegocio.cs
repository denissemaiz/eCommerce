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



    }
}
