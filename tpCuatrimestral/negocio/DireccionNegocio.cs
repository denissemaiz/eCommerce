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
    internal class DireccionNegocio
    {
        public List<Direccion> Listar()
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("SELECT D.ID_Direccion, D.Calle, D.Altura, D.Localidad, D.CP, D.Provincia FROM Direccion D");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.Id = (int)Datos.Lector["ID_Direccion"];
                    aux.Calle = (string)Datos.Lector["Calle"];
                    aux.Altura = (int)Datos.Lector["Altura"];
                    aux.Localidad = (string)Datos.Lector["Localidad"];
                    aux.Cp = (int)Datos.Lector["CP"];
                    aux.Provincia = (string)Datos.Lector["Provincia"];
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

        public void Agregar(Direccion nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("INSERT INTO Direccion (Calle, Altura, Localidad, CP, Provincia) VALUES('" + nuevo.Calle + "', '" + nuevo.Altura + "', '" + nuevo.Localidad + "" +
                    ", '" + nuevo.Cp + "', '" + nuevo.Provincia + "'')");
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
                datos.Consulta("DELETE FROM Direccion WHERE ID_Direccion =" + Id);
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

        public void Modificar(Direccion direccion)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("UPDATE Direccion SET Calle = '" + direccion.calle + "', Altura = " + direccion.altura + ", Localidad = '" + direccion.localidad + "', CP = " +
                    "" + direccion.cp + ", Provincia = '" + direccion.provincia + "' WHERE ID_Direccion =" + direccion.id);
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

        public List<Direccion> RemoveDuplicadosDireccion(List<Direccion> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Direccion> finalList = new List<Direccion>();
            foreach (Direccion dir in inputList)
            {
                if (!uniqueStore.ContainsKey(dir.Id.ToString()))
                {
                    uniqueStore.Add(dir.Id.ToString(), "0");
                    finalList.Add(dir);
                }
            }
            return finalList;
        }
    }
}
