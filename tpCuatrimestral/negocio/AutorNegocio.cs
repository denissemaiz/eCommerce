﻿using Clases;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    public class AutorNegocio
    {
        public List<Autor> Listar()
        {
            List<Autor> Listar = new List<Autor>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select G.ID_Categoria, G.Nombre From GENERO G");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    Listar.Add(aux);
                }
                return Listar;
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

        public List<Autor> RemoveDuplicadosGenero(List<Autor> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Autor> finalList = new List<Autor>();
            foreach (Autor aut in inputList)
            {
                if (!uniqueStore.ContainsKey(aut.Nombre))
                {
                    uniqueStore.Add(aut.Nombre, "0");
                    finalList.Add(aut);
                }
            }
            return finalList;
        }
    }
}