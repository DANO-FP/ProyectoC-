using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;
using System.Web.UI.HtmlControls;

namespace Clientes
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Propiedad> listaProp = LFabrica.getLogicaPropiedad().ListarPropiedades();
                Session["listaProp"] = listaProp;

                try
                {
                    rtPropiedad.DataSource = listaProp;
                    rtPropiedad.DataBind();
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            List<Propiedad> listafinal = (List<Propiedad>)Session["listaprop"];
            List<Propiedad> auxiliar;

            if (ddlAccion.SelectedValue != "0")
            {
                string accion = ddlAccion.Text;

                auxiliar = (from unaProp in listafinal
                            where unaProp.Accion == accion
                            select unaProp).ToList<Propiedad>();

                listafinal = auxiliar;

                if (ddlPropiedad.SelectedValue != "0")
                {
                    int tipo = Convert.ToInt32(ddlPropiedad.SelectedValue);

                    if (tipo == 1) //es apto
                    {
                        auxiliar = (from unaProp in listafinal
                                    where unaProp is Apartamento
                                    select unaProp).ToList<Propiedad>();
                    }

                    if (tipo == 2) //es casa
                    {
                        auxiliar = (from unaProp in listafinal
                                    where unaProp is Casa
                                    select unaProp).ToList<Propiedad>();
                    }

                    if (tipo == 3)
                    {
                        auxiliar = (from unaProp in listafinal
                                    where unaProp is LocalComercial
                                    select unaProp).ToList<Propiedad>();
                    }
                    listafinal = auxiliar;
                }
                if (ddlDepartamento.SelectedValue != "0")
                {
                    string depto = ddlDepartamento.SelectedValue;
                    string acronimo = txtAcronimo.Text.ToUpper();

                    if (acronimo != "")
                    {
                        if (acronimo.Length == 3)
                        {
                            auxiliar = (from unaProp in listafinal
                                        where unaProp.Departamento.IDDepartamento == depto && unaProp.Departamento.Acronimo == acronimo
                                        select unaProp).ToList<Propiedad>();

                            listafinal = auxiliar;
                        }
                        else
                            lblError.Text = "El acronimo debe de tener tres letras";
                    }
                    else
                        lblError.Text = "Para filtrar por zona es necesario el acronimo";
                }

                if (txtMin.Text != "")
                {
                    int precioMin = Convert.ToInt32(txtMin.Text);

                    auxiliar = (from unaProp in listafinal
                                where unaProp.Precio >= precioMin
                                select unaProp).ToList<Propiedad>();

                    listafinal = auxiliar;
                }
                if (txtMax.Text != "")
                {
                    int precioMax = Convert.ToInt32(txtMax.Text);

                    auxiliar = (from unaProp in listafinal
                                where unaProp.Precio <= precioMax
                                select unaProp).ToList<Propiedad>();

                    listafinal = auxiliar;
                }

                try
                {
                    rtPropiedad.DataSource = listafinal;
                    rtPropiedad.DataBind();
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
            else
                lblError.Text = "Debe seleccionar una accion, es obligatorio.";
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlAccion.SelectedValue = "0";
            ddlDepartamento.SelectedValue = "0";
            ddlPropiedad.SelectedValue = "0";
            txtAcronimo.Text = "";
            txtMax.Text = "";
            txtMin.Text = "";
            lblError.Text = "";

            try
            {
                rtPropiedad.DataSource = (List<Propiedad>)Session["listaProp"];
                rtPropiedad.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Session["Propiedad"] = null;
            Entidades.Propiedad Pro = Logica.LFabrica.getLogicaPropiedad().BuscarPropiedad(Convert.ToInt32(((TextBox)(e.Item.Controls[1])).Text));
            
            if (Pro != null)
            {
                Session["Propiedad"] = Pro;
            }
            else
            {
                lblError.Text = "No existe la propiedad";
            }
            Response.Redirect("ConsultaPropiedad.aspx");
        }
    }
}