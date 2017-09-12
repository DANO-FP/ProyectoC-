using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Funcionarios
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Logueo"] = null;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario Fu = Logica.LFabrica.GetLogicaFun().Logueo(txtNombre.Text.Trim(), txtPass.Text.Trim(), txtPass.Text.Trim());
                if (Fu != null)
                {
                    Session["Logueo"] = Fu;
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    lblError.Text = "Error en el usuario, Verifique sus datos.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}