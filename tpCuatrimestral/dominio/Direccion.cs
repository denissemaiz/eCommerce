using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Direccion
    {
        public int id;
        public string calle;
        public int altura;
        public string localidad;
        public int cp;
        public string provincia;

        public Direccion() 
        {

        }

        public Direccion(int id, string calle, int altura, string localidad, int cp, string provincia)
        {
            this.id = id;
            this.calle = calle;
            this.altura = altura;
            this.localidad = localidad;
            this.cp = cp;
            this.provincia = provincia;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Calle
        { 
            get { return calle; } 
            set {  calle = value; } 
        }
        public int Altura
        { 
            get { return altura; } 
            set {  altura = value; } 
        }
        public string Localidad 
        { 
            get {  return localidad; } 
            set {  localidad = value; } 
        }
        public int Cp
        {
            get { return cp; }
            set { cp = value; }
        }
        public string Provincia 
        { 
            get {  return provincia; } 
            set {  provincia = value; } 
        }
    }
}
