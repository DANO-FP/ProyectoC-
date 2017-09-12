using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;

namespace Clientes
{
    public partial class ConsultaPropiedad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFecha.Visible = false;
                ddlHora.Visible = false;
                txtNombre.Visible = false;
                txtTelefono.Visible = false;

                lblFecha.Visible = false;
                lblHora.Visible = false;
                lblNombre.Visible = false;
                lblTel.Visible = false;
                lbltitulo.Visible = false;

                btnAgregar.Visible = false;
            }
            Entidades.Propiedad Pro = (Entidades.Propiedad)Session["Propiedad"];
            
            if (Pro is Entidades.Apartamento)
            { 
            Compositive1.UnaApa = (Entidades.Apartamento)Session["Propiedad"];
            }
            if (Pro is Entidades.Casa)
            {
                Compositive1.UnaCas = (Entidades.Casa)Session["Propiedad"];
            }
            if (Pro is Entidades.LocalComercial)
            {
                Compositive1.UnaLoc = (Entidades.LocalComercial)Session["Propiedad"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            txtFecha.Visible = true;
            ddlHora.Visible = true;
            txtNombre.Visible = true;
            txtTelefono.Visible = true;

            lblFecha.Visible = true;
            lblHora.Visible = true;
            lblNombre.Visible = true;
            lblTel.Visible = true;
            lbltitulo.Visible = true;

            btnAgregar.Visible = true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            DateTime fecha = DateTime.Now;
            int tel = 0;
            Propiedad prop = (Propiedad)Session["Propiedad"];

            try
            {
                tel = Convert.ToInt32(txtTelefono.Text);
                fecha = Convert.ToDateTime(txtFecha.Text + " " + ddlHora.SelectedValue);
            }
            catch
            {
                lblError.Text = "El formato del telefono debe ser un numero, la fecha se debe escribir: mm/dd/aa";
            }

            try
            {
                if (fecha >= DateTime.Now)
                {
                    Visita v = new Visita(1, nombre, tel, fecha, prop);
                    LFabrica.getLogicaVisita().AltaVisita(v);
                    lblError.Text = "Su visita quedo agendada";

                    txtFecha.Text = "";
                    ddlHora.SelectedIndex = 0;
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                }
                else
                {
                    throw new Exception("La fecha debe ser posterior a la fecha de hoy");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}