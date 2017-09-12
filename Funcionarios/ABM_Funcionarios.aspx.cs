using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Funcionarios
{
    public partial class ABM_Funcionarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnBuscar.Enabled = true;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnAlta.Enabled = false;

                txtNombre.Enabled = true;
                txtPass.Enabled = false;
                txtPass0.Enabled = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                lblError.Text = "Debe ingresar un Nombre de usuario valido";
            }
            else
                try
                {
                    lblError.Text = "";
                    Entidades.Funcionario _Funcionario = null;
                    _Funcionario = Logica.LFabrica.GetLogicaFun().BuscarFuncionario(txtNombre.Text.Trim());

                    if (_Funcionario == null)
                    {
                        txtPass.Enabled = true;
                        txtPass0.Enabled = true;
                        txtNombre.Enabled = false;
                        btnAlta.Enabled = true;
                        btnBuscar.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnModificar.Enabled = false;
                    }
                    else
                    {
                        Session["Funcionario"] = _Funcionario;
                        txtNombre.Text = _Funcionario.Nombre.ToString();
                        txtPass.Text = _Funcionario.Password.ToString();
                        txtPass.Enabled = true;
                        txtPass0.Enabled = true;
                        txtNombre.Enabled = false;
                        btnAlta.Enabled = false;
                        btnBuscar.Enabled = false;
                        btnEliminar.Enabled = true;
                        btnModificar.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Funcionario _Fun = null;
                _Fun = new Entidades.Funcionario(txtNombre.Text.Trim(), txtPass.Text.Trim());
                Logica.LFabrica.GetLogicaFun().AgregarFuncionario(_Fun);
                Limpiar();
                lblError.Text = "Alta con Exito";
                Session["Funcionario"] = _Fun;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {


                Entidades.Funcionario _Fun = (Entidades.Funcionario)Session["Funcionario"];
                
                if (_Fun.Nombre != ((Entidades.Funcionario)Session["Logueo"]).Nombre)
                {
                    Logica.LFabrica.GetLogicaFun().EliminarFuncionario(_Fun);
                    Session.Remove("Funcionario");
                    Limpiar();
                    lblError.Text = "Baja con Exito";
                }
                else if(_Fun == (Entidades.Funcionario)Session["Funcionario"])
                {
                    throw new Exception("Error no es posible la autoeliminación. ");
                }
               
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void Limpiar()
        {
            txtNombre.Text = "";
            txtPass0.Text = "";
            txtPass.Text = "";
            lblError.Text = "";

            txtNombre.Enabled = true;
            txtPass.Enabled = false;
            txtPass0.Enabled = false;

            btnBuscar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnAlta.Enabled = false;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Funcionario _Fun = (Entidades.Funcionario)Session["Funcionario"];
                _Fun.Nombre = txtNombre.Text;
                _Fun.Password = txtPass.Text;
                Logica.LFabrica.GetLogicaFun().ModificarFuncionario(_Fun);
                Session["Funcionario"] = _Fun;
                Limpiar();
                lblError.Text = "Modificado con Exito";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}