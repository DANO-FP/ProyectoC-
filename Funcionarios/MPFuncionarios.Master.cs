using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Funcionarios
{
    public partial class MPFuncionarios : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Entidades.Funcionario Fu = (Entidades.Funcionario)Session["Logueo"];
                if (Fu != null)
                {
                    LblUsuario.Text = Fu.Nombre;
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                LblUsuario.Text = ex.Message;
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnDeslog_Click(object sender, EventArgs e)
        {
            Session.Remove("Logueo");
            Response.Redirect("~/Default.aspx");
        }

    }
}