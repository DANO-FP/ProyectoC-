using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Funcionarios
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Entidades.Funcionario Fu = (Entidades.Funcionario)Session["Logueo"];
                if (Fu != null)
                {
                    lblUsuario.Text = Fu.Nombre;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                lblUsuario.Text = ex.Message;
                Response.Redirect("Default.aspx");
            }
        }
    }
}