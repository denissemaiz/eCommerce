using Clases;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    internal class AdministradorNegocio
    {
        public List<Administrador> Listar()
        {
            List<Administrador> lista = new List<Administrador>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select U.Id, U.Nombre, U.Mail, U.Contraseña From USUARIO U");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Administrador aux = new Administrador();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
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

        public List<Administrador> RemoveDuplicadosAdministrador(List<Administrador> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Administrador> finalList = new List<Administrador>();
            foreach (Administrador admin in inputList)
            {
                if (!uniqueStore.ContainsKey(admin.Id.ToString()))
                {
                    uniqueStore.Add(admin.Id.ToString(), "0");
                    finalList.Add(admin);
                }
            }
            return finalList;
        }
    }
}
