using Clases;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    public class DireccionNegocio
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

        public Direccion Buscar(int ID)
        {
            Direccion aux = null ;
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("SELECT D.ID_Direccion, D.Calle, D.Altura, D.Localidad, D.CP, D.Provincia FROM Direccion D WHERE D.ID_Direccion = " + ID);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    aux = new Direccion();
                    aux.Id = (int)datos.Lector["ID_Direccion"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Altura = Convert.ToInt32((Int16)datos.Lector["Altura"]);
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Cp = Convert.ToInt32((Int16)datos.Lector["CP"]);
                    aux.Provincia = (string)datos.Lector["Provincia"];
                }
                return aux;
            }
            catch(Exception ex) 
            { 
                throw ex; 
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public Direccion Buscar_X_Usuario(int ID_Usuario) 
        {
            Direccion aux = null;
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("SELECT D.ID_Direccion, D.Calle, D.Altura, D.Localidad, D.CP, D.Provincia FROM Direccion D " +
                               "INNER JOIN Direccion_X_Usuario dxu ON dxu.ID_Direccion = D.ID_Direccion " + 
                               "WHERE dxu.ID_Usuario = @ID_Usuario");
                datos.SetParametros("@ID_Usuario", ID_Usuario);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    aux = new Direccion();
                    aux.Id = (int)datos.Lector["ID_Direccion"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Altura = Convert.ToInt32((Int16)datos.Lector["Altura"]);
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Cp = Convert.ToInt32((Int16)datos.Lector["CP"]);
                    aux.Provincia = (string)datos.Lector["Provincia"];
                }
                return aux;
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

        public Direccion Buscar_X_Compra(int ID_Compra)
        {
            Direccion aux = null;
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("SELECT D.ID_Direccion, D.Calle, D.Altura, D.Localidad, D.CP, D.Provincia FROM Direccion D " +
                               "INNER JOIN Direccion_X_Compra dxc ON dxc.ID_Direccion = D.ID_Direccion " +
                               "WHERE dxc.ID_Compra = @ID_Compra");
                datos.SetParametros("ID_Compra", ID_Compra);
                datos.EjecutarLectura();
                while(datos.Lector.Read())
                {
                    aux = new Direccion();
                    aux.Id = (int)datos.Lector["ID_Direccion"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Altura = Convert.ToInt32((Int16)datos.Lector["Altura"]);
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Cp = Convert.ToInt32((Int16)datos.Lector["CP"]);
                    aux.Provincia = (string)datos.Lector["Provincia"];
                }
                return aux;
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

        public void Agregar(Direccion nuevo)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("INSERT INTO Direccion (Calle, Altura, Localidad, CP, Provincia) VALUES( @calle, @altura, @localidad, @cp, @provincia)");
                datos.SetParametros("@calle", nuevo.Calle);
                datos.SetParametros("@altura", (Int16)nuevo.Altura);
                datos.SetParametros("@localidad", nuevo.Localidad);
                datos.SetParametros("@cp", (Int16)nuevo.Cp);
                datos.SetParametros("@provincia", nuevo.Provincia);
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

        //Metodo para agregar una direccion nueva a un usuario
        public void NuevaDireccion_Usuario(Direccion nuevaDireccion, int ID_Usuario)
        {
            AccesoSQL datos = new AccesoSQL();
            int ID_Direccion = -1;
            try
            {
                datos.Consulta("INSERT INTO Direccion (Calle, Altura, Localidad, CP, Provincia) " +
                               "OUTPUT INSERTED.ID_Direccion " + //Hago que el insert devuelva el ID de la direccion
                               "VALUES(@Calle, @Altura, @Localidad, @Cp, @Provincia)");

                datos.SetParametros("@calle", nuevaDireccion.Calle);
                datos.SetParametros("@altura", (Int16)nuevaDireccion.Altura);
                datos.SetParametros("@localidad", nuevaDireccion.Localidad);
                datos.SetParametros("@cp", (Int16)nuevaDireccion.Cp);
                datos.SetParametros("@provincia", nuevaDireccion.Provincia);
                
                ID_Direccion = datos.EjecutarScalar();//Obtengo el ID_Direccion               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            try
            {
                if(ID_Direccion != -1)
                {
                    datos = new AccesoSQL();
                    datos.Consulta("INSERT INTO Direccion_X_Usuario (ID_Direccion, ID_Usuario) VALUES(@ID_Direccion, @ID_Usuario)");
                    datos.SetParametros("ID_Direccion", ID_Direccion);
                    datos.SetParametros("ID_Usuario", ID_Usuario);
                    datos.EjecutarAccion();
                }
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

        //Metodo para agregar una direccion nueva a una compra
        public void NuevaDireccion_Compra(Direccion nuevaDireccion, int ID_Compra)
        {
            AccesoSQL datos = new AccesoSQL();
            int ID_Direccion = -1;
            try
            {
                datos.Consulta("INSERT INTO Direccion (Calle, Altura, Localidad, CP, Provincia) " +
                               "OUTPUT INSERTED.ID_Direccion " + //Hago que el insert devuelva el ID de la direccion
                               "VALUES(@Calle, @Altura, @Localidad, @Cp, @Provincia)");

                datos.SetParametros("@calle", nuevaDireccion.Calle);
                datos.SetParametros("@altura", (Int16)nuevaDireccion.Altura);
                datos.SetParametros("@localidad", nuevaDireccion.Localidad);
                datos.SetParametros("@cp", (Int16)nuevaDireccion.Cp);
                datos.SetParametros("@provincia", nuevaDireccion.Provincia);

                ID_Direccion = datos.EjecutarScalar();//Obtengo el ID_Direccion               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            try
            {
                if (ID_Direccion != -1)
                {
                    datos = new AccesoSQL();
                    datos.Consulta("INSERT INTO Direccion_X_Compra (ID_Direccion, ID_Compra) VALUES(@ID_Direccion, @ID_Compra)");
                    datos.SetParametros("ID_Direccion", ID_Direccion);
                    datos.SetParametros("ID_Compra", ID_Compra);
                    datos.EjecutarAccion();
                }
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

        //Metodo para agregar una direccion existente a un usuario
        public void Agregar_a_Usuario(int ID_Direccion, int ID_Usuario)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {                
                datos.Consulta("INSERT INTO Direccion_X_Usuario (ID_Direccion, ID_Usuario) VALUES(@ID_Direccion, @ID_Usuario)");
                datos.SetParametros("ID_Direccion", ID_Direccion);
                datos.SetParametros("ID_Usuario", ID_Usuario);
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

        //Metodo para agregar una direccion existente a una compra
        public void Agregar_a_Compra(int ID_Direccion, int ID_Compra)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("INSERT INTO Direccion_X_Usuario (ID_Direccion, ID_Compra) VALUES(@ID_Direccion, @ID_Compra)");
                datos.SetParametros("ID_Direccion", ID_Direccion);
                datos.SetParametros("ID_Usuario", ID_Compra);
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
                datos.Consulta("UPDATE Direccion SET Calle = @calle, Altura = @altura, Localidad = @localidad, CP = @cp, Provincia = @provincia WHERE ID_Direccion = @ID");
                datos.SetParametros("@ID", direccion.Id);
                datos.SetParametros("@calle", direccion.Calle);
                datos.SetParametros("@localidad", direccion.Localidad);
                datos.SetParametros("@cp", (Int16)direccion.Cp);
                datos.SetParametros("@altura",(Int16)direccion.Altura);
                datos.SetParametros("@provincia",direccion.Provincia);
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
