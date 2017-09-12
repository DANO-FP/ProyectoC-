using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;
using Persistencia;

namespace Funcionarios
{
    public partial class ABM_LocalComercial : System.Web.UI.Page
    {
        protected void limpiar()
        {
            txtAcronimo.Text = "";
            txtBaños.Text = "";
            txtDireccion.Text = "";
            txtHabitantes.Text = "";
            txtMtEd.Text = "";
            txtPrecio.Text = "";
            txtPadron.Text = "";
            lblError.Text = "";
            chbHabilitacion.Checked = false;
            ddlAccion.SelectedIndex = 0;
            ddlDepartamento.SelectedIndex = 0;
        }

        protected void bloquear()
        {
            txtPadron.Enabled = true;
            txtAcronimo.Enabled = false;
            txtBaños.Enabled = false;
            txtDireccion.Enabled = false;
            txtHabitantes.Enabled = false;
            txtMtEd.Enabled = false;
            txtPrecio.Enabled = false;
            ddlAccion.Enabled = false;
            ddlDepartamento.Enabled = false;
            chbHabilitacion.Enabled = false;
            btnAlta.Enabled = false;
            btnBaja.Enabled = false;
            btnModificacion.Enabled = false;
            btnBuscar.Enabled = true;
        }

        protected void desbloquear()
        {
            txtPadron.Enabled = false;
            txtAcronimo.Enabled = true;
            txtBaños.Enabled = true;
            txtDireccion.Enabled = true;
            txtHabitantes.Enabled = true;
            txtMtEd.Enabled = true;
            txtPrecio.Enabled = true;
            ddlAccion.Enabled = true;
            ddlDepartamento.Enabled = true;
            chbHabilitacion.Enabled = true;
            btnAlta.Enabled = false;
            btnBaja.Enabled = true;
            btnModificacion.Enabled = true;
            btnBuscar.Enabled = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bloquear();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int padron = 0;
            lblError.Text = "";
            try
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtPadron.Text))
                    {
                        txtPadron.Focus();
                        throw new Exception("Debe ingresar un padron");
                    }
                    padron = Convert.ToInt32(txtPadron.Text.Trim());
                    if (padron < 1)
                    {
                        throw new Exception("El padron debe ser mayor a 0");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                ILPropiedad lProp = LFabrica.getLogicaPropiedad();
                Propiedad prop = lProp.BuscarPropiedad(padron);

                if (prop != null)
                {
                    if (prop is Apartamento)
                        lblError.Text = "Ese padron es de un Apartamento";
                    if (prop is Casa)
                        lblError.Text = "Ese padron pertenece a una Casa";
                    if (prop is LocalComercial)
                    {
                        LocalComercial local = (LocalComercial)prop;
                        txtAcronimo.Text = local.Departamento.Acronimo;
                        txtBaños.Text = local.CantBaños.ToString();
                        txtDireccion.Text = local.Direccion;
                        txtHabitantes.Text = local.CantHabit.ToString();
                        txtMtEd.Text = local.Mt2Ed.ToString();
                        txtPrecio.Text = local.Precio.ToString();
                        chbHabilitacion.Checked = Convert.ToBoolean(local.Habilitacion);
                        ddlAccion.SelectedValue = local.Accion.ToString();
                        ddlDepartamento.SelectedValue = local.Departamento.IDDepartamento.ToString();

                        Session["propiedad"] = local;

                        desbloquear();
                    }
                }
                else
                {
                    lblError.Text = "No existe un Local Comercial con ese padron, puede dar de alta";
                    desbloquear();
                    btnAlta.Enabled = true;
                    btnModificacion.Enabled = false;
                    btnBaja.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            int padron = 0, precio = 0, baños = 0, habitaciones = 0, mtEd = 0;
            string direccion = "", accion = "", mensaje = "", nombreUsuario = "", nombreDepto = "", acronimo = "";
            bool habilitacion = false;
            Zona depto = null;
            Funcionario usuario = null;

            direccion = txtDireccion.Text;
            acronimo = txtAcronimo.Text;
            accion = ddlAccion.Text;
            nombreUsuario = ((Funcionario)Session["Logueo"]).Nombre.ToString();
            habilitacion = Convert.ToBoolean(chbHabilitacion.Checked);
            nombreDepto = ddlDepartamento.SelectedValue;

            try
            {
                if (string.IsNullOrWhiteSpace(txtPadron.Text))
                {
                    txtPadron.Focus();
                    throw new Exception("Debe ingresar un padron");
                }
                else
                    if (string.IsNullOrEmpty(txtPrecio.Text))
                    {
                        txtPrecio.Focus();
                        throw new Exception("Debe ingresar un precio");
                    }
                    else
                        if (string.IsNullOrWhiteSpace(txtBaños.Text))
                        {
                            txtBaños.Focus();
                            throw new Exception("Debe ingresar la cantidad de baños");
                        }
                        else
                            if (string.IsNullOrWhiteSpace(txtHabitantes.Text))
                            {
                                txtHabitantes.Focus();
                                throw new Exception("Debe ingresar la cantidad de habitaciones");
                            }
                            else
                                if (string.IsNullOrWhiteSpace(txtMtEd.Text))
                                {
                                    txtMtEd.Focus();
                                    throw new Exception("Debe ingresar la cantidad de metros cuadrados edificados");
                                }
                                else
                                    if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                                    {
                                        txtDireccion.Focus();
                                        throw new Exception("Debe ingresar una direccion");
                                    }
                                    else
                                        if (string.IsNullOrWhiteSpace(txtAcronimo.Text))
                                        {
                                            txtAcronimo.Focus();
                                            throw new Exception("Debe ingresar el acronimo");
                                        }
                                            else
                                                if (acronimo.Length != 3)
                                                {
                                                    txtAcronimo.Focus();
                                                    throw new Exception("El acronimo debe tener tres letras");
                                                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                return;
            }
            try
            {
                padron = Convert.ToInt32(txtPadron.Text);
                precio = Convert.ToInt32(txtPrecio.Text);
                baños = Convert.ToInt32(txtBaños.Text);
                habitaciones = Convert.ToInt32(txtHabitantes.Text);
                mtEd = Convert.ToInt32(txtMtEd.Text);
            }
            catch
            {
                mensaje = "Verifique que Padron, Precio, Cantidad de baños, Cantidad de habitantes, Metros cuadrados edificados y Piso sean numeros";
            }
            if (mensaje != "")
            {
                lblError.Text = mensaje;
            }
            else
            {
                try
                {
                    ILFuncionario lFun = LFabrica.GetLogicaFun();
                    usuario = LFabrica.GetLogicaFun().BuscarFuncionario(nombreUsuario);

                    ILogicaZona lZon = LFabrica.GetInstZona();
                    depto = lZon.BuscarZona(nombreDepto, acronimo);

                    if (usuario == null)
                    {
                        lblError.Text = "No existe el usuario";
                        return;
                    }
                    if (depto == null)
                    {
                        lblError.Text = "No existe la zona";
                        return;
                    }

                    LocalComercial local = new LocalComercial(padron, precio, baños, habitaciones, mtEd, direccion, accion, depto, usuario, habilitacion);
                    ILPropiedad lProp = LFabrica.getLogicaPropiedad();
                    lProp.AltaPropiedad(local);

                    Session["propiedad"] = local;

                    limpiar();
                    lblError.Text = "El alta fue exitosa";
                    bloquear();
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

            try
            {
                ILPropiedad lProp = LFabrica.getLogicaPropiedad();
                Propiedad prop = (Propiedad)Session["propiedad"];
                lProp.EliminarPropiedad(prop);
                limpiar();
                lblError.Text = "La eliminacion se hizo correctamente";
                bloquear();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnModificacion_Click(object sender, EventArgs e)
        {
            LocalComercial l = ((LocalComercial)Session["propiedad"]); 
            try
            {
                int padron = Convert.ToInt32(txtPadron.Text.Trim());
                int precio = Convert.ToInt32(txtPrecio.Text.Trim());
                int baños = Convert.ToInt32(txtBaños.Text.Trim());
                int habitaciones = Convert.ToInt32(txtHabitantes.Text.Trim());
                int mtEd = Convert.ToInt32(txtMtEd.Text.Trim());
                string direccion = txtDireccion.Text.Trim();
                string accion = ddlAccion.Text;
                Funcionario Usuario = ((Funcionario)Session["Logueo"]);
                bool habilitacion = chbHabilitacion.Checked;
               
                ILogicaZona lz = LFabrica.GetInstZona();
                Zona z =  lz.BuscarZona(ddlDepartamento.SelectedValue, txtAcronimo.Text);


                LocalComercial nl = new LocalComercial(padron, precio, baños, habitaciones, mtEd, direccion, accion, z, Usuario, habilitacion);
                ILPropiedad ll = LFabrica.getLogicaPropiedad();
                ll.ModificarPropiedad(nl);

                limpiar();
                bloquear();
                lblError.Text = "modificación exitosa";
            }
            catch (Exception er)
            {
                lblError.Text = "Alguno de los datos en los campos no es correcto, verifique. " + er.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            bloquear();
        }
    }
}