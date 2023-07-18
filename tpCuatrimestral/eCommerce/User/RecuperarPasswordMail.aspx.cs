using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce.User
{
    public partial class RecuperarPasswordMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {

            string Correo = txtRecuperarMail.Text;

            

        }

        //private bool Verificar(string correo)
        //{
            
        //    string connectionString = "tu cadena de conexión a la base de datos";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT COUNT(*) FROM Usuarios WHERE CorreoElectronico = @CorreoElectronico";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@CorreoElectronico", correo);
        //            int count = (int)command.ExecuteScalar();
        //            return count > 0;
        //        }
        //    }
        //}


    }
}