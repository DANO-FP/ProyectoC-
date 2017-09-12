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
    public partial class ABMZona : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                habilitarBotones(false);
            }
        }


        //procedimientos y operaciones
        protected void CamposZona(bool estado)
        {
            txtNomDep.Enabled = estado;
            txtHabitantes.Enabled = estado;
            txtNomDep.Visible = estado;
            txtHabitantes.Visible = estado;
            lblNomDep.Visible = estado;
            lblHabitantes.Visible = estado;
            lblAgregarServ.Visible = estado;
        }

       

        protected void CargaZona(Zona z)
        {
            CamposZona(true);
            btnAlta.Enabled = false;
            habilitarBotones(true);
            List<Servicio> servicios = new List<Servicio>();
            ddlDpto.Enabled = false;
            txtAcron.ReadOnly = true;
            txtNomDep.ReadOnly = true;
            txtNomDep.Text = z.NombreOficial;
            ddlDpto.Text = z.IDDepartamento;
            txtAcron.Text = z.Acronimo;
            txtNomOf.Text = z.NombreOficial.ToString();
            txtHabitantes.Text = z.Habitantes.ToString();
            if (z.Servicios.Count != 0)
            {
                habilitarServicios(true);
                servicios = z.Servicios;
                gvServicios.DataSource = servicios;
                gvServicios.DataBind();
            }
            else if (z.Servicios.Count <= 0)
            {
                txtServicio.Visible = true;
                btnAgregaServ.Visible = true;
                lblError.Text = "La Zona seleccionada no tiene servicios asociados. ";
            }
        }

        
        //deja visible el txt de dpto, acron y nombre oficial, botones de buscar y agregar zona 
        protected void habilitarBotones(bool estado)
        {
            btnAlta.Visible = estado;
            btnBaja.Visible = estado;
            btnModificar.Visible = estado;
            txtNomDep.Visible = estado;
            lblNomDep.Visible = estado;
            txtHabitantes.Visible = estado;
            lblHabitantes.Visible = estado;
            habilitarServicios(estado);
            btnNvaConsulta.Visible = estado;
            txtNomOf.Visible = estado;
            lblNomOf.Visible = estado;

        }

        protected void habilitarServicios(bool estado)
        {
            txtServicio.Visible = estado;
            btnAgregaServ.Visible = estado;
            btnEliminarServ.Visible = estado;
            lblAgregarServ.Visible = estado;
        }

        protected void CargoServicios(List<Servicio> s)
        {
            habilitarServicios(true);
            gvServicios.DataSource = s;
            gvServicios.DataBind();
        }

        protected void LimpiarCampos()
        {
            txtAcron.Text = "";
            ddlDpto.Text = "";
            txtHabitantes.Text = "";
            txtNomOf.Text = "";
            txtServicio.Text = "";
            lblError.Text = "";
            lblInfoServ.Text = "";
            txtAcron.ReadOnly = false;
            ddlDpto.Enabled = false;

        }

        protected void habilitarAlta()
        {
            
            if (((Zona)Session["zona"]) != null)
                Session.Remove("zona");
           
                List<Servicio> listaServicio = new List<Servicio>();
                Session["listaservicio"] = listaServicio;
                habilitarBotones(true);
                btnModificar.Visible = false;
                btnBaja.Visible = false;
                txtNomOf.Enabled = true;
                txtHabitantes.Enabled = true;
                lblNomDep.Visible = false;
                txtNomDep.Visible = false;
        }

        //botones
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblInfo.Text = "";
            string dpto, acron;
            Zona z = null;
            try
            {
                if ((string.IsNullOrEmpty(ddlDpto.Text.Trim())) || (ddlDpto.Text.Length > 1))
                {
                    ddlDpto.Focus();
                    throw new Exception("ERROR! Se ingresó de forma incorrecta el ID Departamento, ingrese una letra. ");
                }
                else if ((string.IsNullOrEmpty(txtAcron.Text.Trim())) || (txtAcron.Text.Length != 3))
                {
                    txtAcron.Focus();
                    throw new Exception("ERROR! Se ingresó de forma incorrecta el Acrónimo que identifica la zona, ingrese tres letras. ");
                }
                else
                {
                    dpto = ddlDpto.Text.Trim().ToUpper();
                    acron = txtAcron.Text.Trim().ToUpper();
                }
                ILogicaZona lz = LFabrica.GetInstZona();
                z = lz.BuscarZona(dpto, acron);
                if (z != null)
                {

                    btnAlta.Visible = false;
                    lblInfo.Text = "";
                    lblError.Text = "";
                    txtHabitantes.Enabled = true;
                    txtNomOf.Enabled = true;
                    btnBuscar.Visible = false;
                    CargaZona(z);
                    Session["zona"] = z;
                }
                else
                {
                    ddlDpto.Enabled = false;
                    txtAcron.ReadOnly = true;
                    btnBuscar.Visible = false;
                    habilitarAlta();
                    lblInfo.Text = "No se encontraron datos en el sistema que concuerden con los datos ingresados";
                }
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnAgregarZona_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            lblError.Text = "";
            btnBuscar.Visible = false;
            CamposZona(true);
            habilitarAlta();
            txtNomDep.Visible = false;
            lblNomDep.Visible = false;
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            string depto, acron, nombOf;
            int habitantes;
            lblInfo.Text = "";
            
            Zona z = null;
            try
            {
                if (string.IsNullOrEmpty(txtAcron.Text))
                {
                    txtAcron.Focus();
                    throw new Exception("Debe ingresar el acronimo. ");
                }
                else if (string.IsNullOrEmpty(txtNomOf.Text))
                {
                    txtNomOf.Focus();
                    throw new Exception("Debe ingresar el Nombre Oficial. ");
                }
                else if (string.IsNullOrEmpty(txtHabitantes.Text))
                {
                    txtHabitantes.Focus();
                    throw new Exception("Debe ingresar la cantidad de habitantes. ");
                }
                else
                {
                    depto = ddlDpto.SelectedValue.ToString();
                    acron = txtAcron.Text.Trim().ToUpper();
                    nombOf = txtNomOf.Text.Trim().ToUpper();
                    habitantes = Convert.ToInt32(txtHabitantes.Text.Trim());
                }
                List<Servicio> listaservicio = (List<Servicio>)Session["listaservicio"];
                z = new Zona(depto, acron, nombOf, habitantes, listaservicio);

                ILogicaZona lz = LFabrica.GetInstZona();
                lz.AltaZona(z);
                LimpiarCampos();
                ddlDpto.Enabled = true;
                txtAcron.Enabled = true;
                lblInfo.Text = "El alta se realizó con exito. " + z.NombreOficial.ToString();
                habilitarBotones(false);
                gvServicios.Visible = false;
                btnBuscar.Visible = true;

            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
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
                    if (string.IsNullOrEmpty(ddlDpto.Text))
                    {
                        ddlDpto.Focus();
                        throw new Exception("El campo ID Departamento no puede estar vacío. ");
                    }
                    string idDpto = ddlDpto.Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(txtAcron.Text))
                    {
                        txtAcron.Focus();
                        throw new Exception("El campo Acrónimo no puede estar vacío. ");
                    }
                    string acron = txtAcron.Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(txtNomOf.Text))
                    {
                        txtNomOf.Focus();
                        throw new Exception("El campo Nombre Oficial no puede estar vacío. ");
                    }
                    string nomOf = txtNomOf.Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(txtHabitantes.Text))
                    {
                        txtHabitantes.Focus();
                        throw new Exception("El campo ID Departamento no puede estar vacío. ");
                    }
                    int habitantes = Convert.ToInt32(txtHabitantes.Text);
                    List<Servicio> listaservicio = new List<Servicio>();
                    Zona z1 = new Zona(idDpto, acron, nomOf, habitantes, listaservicio);

                    lz.ModificaZona(z1);
                    lblInfo.Text = "Se modificó la Zona " + z1.NombreOficial + " Correctamente. ";
                }
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            lblError.Text = "";
            Zona z = (Zona)Session["zona"];
            try
            {
                ILogicaZona lz = LFabrica.GetInstZona();
                lz.BajaZona(z);
                LimpiarCampos();
                habilitarServicios(false);
                txtNomDep.Visible = false;
                lblNomDep.Visible = false;
                lblInfo.Text = "Baja con éxito";
                habilitarBotones(false);
                gvServicios.Visible = false;
                btnBuscar.Visible = true;
                ddlDpto.Enabled = true;
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnAgregaServ_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblInfo.Text = "";
            List<Servicio> listaServicio;
            try
            {

                if (string.IsNullOrEmpty(txtServicio.Text))
                {
                    txtServicio.Focus();
                    throw new Exception("Ingresar el nombre del servicio para continuar. ");
                }

                string nombreservicio = txtServicio.Text.Trim().ToUpper();

                if (((Zona)Session["zona"]) == null)
                {
                    //sin zona en memoria 
                    listaServicio = ((List<Servicio>)Session["listaservicio"]);
                    Servicio nvoserv = new Servicio(nombreservicio);
                    listaServicio.Add(nvoserv);
                    Session["listaservicio"] = listaServicio;
                    CargoServicios(listaServicio);
                    txtServicio.Text = "";
                    txtServicio.Focus();
                }
                else
                {
                    //aca entra si tengo una zona en la memoria
                    Zona z = (Zona)Session["zona"];
                    listaServicio = z.Servicios;
                    Servicio nvoserv = new Servicio(nombreservicio);
                    listaServicio.Add(nvoserv);
                    z.Servicios = listaServicio;
                    CargoServicios(listaServicio);
                    txtServicio.Text = "";
                    txtServicio.Focus();
                }
                lblInfo.Text = "Se dio de alta el servicio " + nombreservicio + " éxitosamente. ";
             lblInfoServ.Text =  "Para completar la acción clic en el botón Editar Zona o en Alta Zona si está ingresando una nueva";
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }


        }

        protected void btnEliminarServ_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            lblError.Text = "";
            List<Servicio> listaservicio = ((Zona)Session["zona"]).Servicios;
            string nombreservicio;
            Servicio s = null;
            try
            {
                if (string.IsNullOrEmpty(txtServicio.Text))
                {
                    txtServicio.Focus();
                    throw new Exception("Debe ingresar el nombre del servico a eliminar. ");
                }

                nombreservicio = txtServicio.Text.Trim().ToUpper();
                s = new Servicio(nombreservicio);

                for (int i = 0; i < listaservicio.Count; i++)
                {
                    if (listaservicio[i].Nombre == s.Nombre)
                    {
                        listaservicio.RemoveAt(i);
                    }
                }

                ((Zona)Session["zona"]).Servicios = listaservicio;
                CargoServicios(listaservicio);

                lblInfo.Text = "Servicio " + nombreservicio + " eliminado con éxito. ";
                lblInfoServ.Text = "Para completar la acción clic en el botón Editar Zona o en Alta Zona si está ingresando una nueva";
               
            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
            }
        }

        protected void btnNvaConsulta_Click(object sender, EventArgs e)
        {
            if (((Zona)Session["zona"]) != null)
            {
                Session.Remove("zona");
            }
            Response.Redirect("~/ABMZona.aspx");
        }
    }
}