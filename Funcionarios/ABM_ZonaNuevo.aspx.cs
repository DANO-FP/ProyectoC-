using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;

namespace Funcionarios
{
    public partial class ABM_ZonaNuevo : System.Web.UI.Page
    {
        protected void bloquear()
        {
            btnAltaServicio.Enabled = false;
            btnAltaZona.Enabled = false;
            btnBajaServicio.Enabled = false;
            btnBajaZona.Enabled = false;
            btnBuscarZona.Enabled = true;
            btnModificarZona.Enabled = false;

            ddlDepartamento.Enabled = true;
            txtAcronimo.Enabled = true;

            txtCantHabitantes.Enabled = false;
            txtNombreOficial.Enabled = false;
            txtServicios.Enabled = false;
        }

        protected void desbloquear()
        {
            btnAltaServicio.Enabled = true;
            btnAltaZona.Enabled = true;
            btnBajaServicio.Enabled = true;
            btnBajaZona.Enabled = true;
            btnBuscarZona.Enabled = false;
            btnModificarZona.Enabled = true;

            ddlDepartamento.Enabled = false;
            txtAcronimo.Enabled = false;

            txtCantHabitantes.Enabled = true;
            txtNombreOficial.Enabled = true;
            txtServicios.Enabled = true;
        }

        protected void limpiar()
        {
            txtAcronimo.Text = "";
            txtCantHabitantes.Text = "";
            txtNombreOficial.Text = "";
            txtServicios.Text = "";
            ddlDepartamento.SelectedIndex = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarZona_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string dpto, acron;
            Zona z = null;
            try
            {
                if ((string.IsNullOrEmpty(ddlDepartamento.Text.Trim())) || (ddlDepartamento.Text.Length > 1))
                {
                    ddlDepartamento.Focus();
                    throw new Exception("ERROR! Se ingresó de forma incorrecta el ID Departamento, ingrese una letra. ");
                }
                else if ((string.IsNullOrEmpty(txtAcronimo.Text.Trim())) || (txtAcronimo.Text.Length != 3))
                {
                    txtAcronimo.Focus();
                    throw new Exception("ERROR! Se ingresó de forma incorrecta el Acrónimo que identifica la zona, ingrese tres letras. ");
                }
                else
                {
                    dpto = ddlDepartamento.Text.Trim().ToUpper();
                    acron = txtAcronimo.Text.Trim().ToUpper();
                }
                ILogicaZona lz = LFabrica.GetInstZona();
                z = lz.BuscarZona(dpto, acron);
                if (z != null)
                {
                    desbloquear();

                    txtAcronimo.Text = z.Acronimo;
                    txtCantHabitantes.Text = z.Habitantes.ToString();
                    txtNombreOficial.Text = z.NombreOficial;

                    gvServicios.DataSource = z.Servicios;
                    gvServicios.DataBind();

                    Session["zona"] = z;
                }
                else
                {
                    desbloquear();
                    lblError.Text = "No se encontraron datos en el sistema que concuerden con los datos ingresados";
                }
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnAltaZona_Click(object sender, EventArgs e)
        {
            string depto, acron, nombOf;
            int habitantes;

            Zona z = null;
            try
            {
                if (string.IsNullOrEmpty(txtAcronimo.Text))
                {
                    txtAcronimo.Focus();
                    throw new Exception("Debe ingresar el acronimo. ");
                }
                else if (string.IsNullOrEmpty(txtNombreOficial.Text))
                {
                    txtNombreOficial.Focus();
                    throw new Exception("Debe ingresar el Nombre Oficial. ");
                }
                else if (string.IsNullOrEmpty(txtCantHabitantes.Text))
                {
                    txtCantHabitantes.Focus();
                    throw new Exception("Debe ingresar la cantidad de habitantes. ");
                }
                else
                {
                    depto = ddlDepartamento.SelectedValue.ToString();
                    acron = txtAcronimo.Text.Trim().ToUpper();
                    nombOf = txtNombreOficial.Text.Trim().ToUpper();
                    habitantes = Convert.ToInt32(txtCantHabitantes.Text.Trim());
                }

                List<Servicio> listaservicio = (List<Servicio>)Session["listaservicio"];
                z = new Zona(depto, acron, nombOf, habitantes, listaservicio);

                ILogicaZona lz = LFabrica.GetInstZona();
                lz.AltaZona(z);
                bloquear();
                limpiar();
                lblError.Text = "El alta se realizó con exito. " + z.NombreOficial.ToString();

            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void txtServicios_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBajaZona_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            Zona z = (Zona)Session["zona"];
            try
            {
                ILogicaZona lz = LFabrica.GetInstZona();
                lz.BajaZona(z);
                bloquear();
                limpiar();
                lblError.Text = "Baja con éxito";
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnModificarZona_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                if (((Zona)Session["zona"]) == null)
                {
                    throw new Exception("No se seleccionó ninguna Zona, verifique por favor. ");
                }
                else
                {
                    Zona z = (Zona)Session["zona"];
                    ILogicaZona lz = LFabrica.GetInstZona();
                    lz.ModificarServicios(z);
                    if (string.IsNullOrEmpty(ddlDepartamento.Text))
                    {
                        ddlDepartamento.Focus();
                        throw new Exception("El campo ID Departamento no puede estar vacío. ");
                    }
                    string idDpto = ddlDepartamento.Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(txtAcronimo.Text))
                    {
                        txtAcronimo.Focus();
                        throw new Exception("El campo Acrónimo no puede estar vacío. ");
                    }
                    string acron = txtAcronimo.Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(txtNombreOficial.Text))
                    {
                        txtNombreOficial.Focus();
                        throw new Exception("El campo Nombre Oficial no puede estar vacío. ");
                    }
                    string nomOf = txtNombreOficial.Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(txtCantHabitantes.Text))
                    {
                        txtCantHabitantes.Focus();
                        throw new Exception("El campo ID Departamento no puede estar vacío. ");
                    }
                    int habitantes = Convert.ToInt32(txtCantHabitantes.Text);
                    List<Servicio> listaservicio = new List<Servicio>();
                    Zona z1 = new Zona(idDpto, acron, nomOf, habitantes, listaservicio);

                    lz.ModificaZona(z1);
                    lblError.Text = "Se modificó la Zona " + z1.NombreOficial + " Correctamente. ";
                }
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnAltaServicio_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            List<Servicio> listaServicio;
            try
            {

                if (string.IsNullOrEmpty(txtServicios.Text))
                {
                    txtServicios.Focus();
                    throw new Exception("Ingresar el nombre del servicio para continuar. ");
                }

                string nombreservicio = txtServicios.Text.Trim().ToUpper();

                if (((Zona)Session["zona"]) == null)
                {
                    //sin zona en memoria 
                    listaServicio = ((List<Servicio>)Session["listaservicio"]);
                    Servicio nvoserv = new Servicio(nombreservicio);
                    listaServicio.Add(nvoserv);
                    Session["listaservicio"] = listaServicio;
                    gvServicios.DataSource = listaServicio;
                    gvServicios.DataBind();
                    txtServicios.Text = "";
                    txtServicios.Focus();
                }
                else
                {
                    //aca entra si tengo una zona en la memoria
                    Zona z = (Zona)Session["zona"];
                    listaServicio = z.Servicios;
                    Servicio nvoserv = new Servicio(nombreservicio);
                    listaServicio.Add(nvoserv);
                    z.Servicios = listaServicio;
                    gvServicios.DataSource = listaServicio;
                    gvServicios.DataBind();
                    txtServicios.Text = "";
                    txtServicios.Focus();
                }
                lblError.Text = "Se dio de alta el servicio " + nombreservicio + " éxitosamente. " + "\n";
                lblError.Text = lblError + "Para completar la acción clic en el botón Editar Zona o en Alta Zona si está ingresando una nueva";
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnBajaServicio_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            List<Servicio> listaservicio = ((Zona)Session["zona"]).Servicios;
            string nombreservicio;
            Servicio s = null;
            try
            {
                if (string.IsNullOrEmpty(txtServicios.Text))
                {
                    txtServicios.Focus();
                    throw new Exception("Debe ingresar el nombre del servico a eliminar. ");
                }

                nombreservicio = txtServicios.Text.Trim().ToUpper();
                s = new Servicio(nombreservicio);

                for (int i = 0; i < listaservicio.Count; i++)
                {
                    if (listaservicio[i].Nombre == s.Nombre)
                    {
                        listaservicio.RemoveAt(i);
                    }
                }

                ((Zona)Session["zona"]).Servicios = listaservicio;
                gvServicios.DataSource = listaservicio;
                gvServicios.DataBind();

                lblError.Text = "Servicio " + nombreservicio + " eliminado con éxito. " + "\n";
                lblError.Text = lblError + "Para completar la acción clic en el botón Editar Zona o en Alta Zona si está ingresando una nueva";

            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }
    }
}