using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public enum UserType
    {
        ADMIN = 1,
        CLIENTE = 2
    }
    public class Usuario
    {

        private int id;
        private string nombreUsuario;
        private string contra;

        public UserType TipoUsuario { get; set; }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        public string Contra
        {
            get { return contra; }
            set { contra = value; }
        }
    
        public bool ValidarAdmin()
        {
            return TipoUsuario == UserType.ADMIN;
        } 
    }
}
