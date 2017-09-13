using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Logica;

namespace APP_Admin
{
    public partial class frmZona : Form
    {
        public frmZona()
        {
            
            InitializeComponent();
        }

        private void _botones()
        {
            tsbZAdd.Enabled = false;
            tsbZDel.Enabled = false;
            tsbZSave.Enabled = false;
            tsbZUpd.Enabled = false;
        }
        private bool Validar(string dato)
        {
            if (string.IsNullOrEmpty(txtDpto.Text))
            {
                errorZ.SetError(txtDpto, "Identificador del Departamento, su ingreso es obligatorio (UNA LETRA). ");
                return false;
            }
            errorZ.SetError(txtDpto, "");
            if (string.IsNullOrEmpty(txtAcron.Text))
            {
                errorZ.SetError(txtAcron, "Identificador para la Zona, su ingreso es obligatorio (TRES LETRAS). ");
                return false;
            }
            errorZ.SetError(txtAcron, "");
            if (string.IsNullOrEmpty(txtNomOficial.Text))
            {
                errorZ.SetError(txtNomOficial, "Nombre Oficial es de uso obligatorio para ingresar una nueva Zona. ");
            }
            errorZ.SetError(txtNomOficial, "");
            if (string.IsNullOrEmpty(txtHab.Text))
            {
                errorZ.SetError(txtHab, "Cantidad de Habitantes es de uso obligatorio . ");
            }
            errorZ.SetError(txtHab, "");
            return true;
        }

        private void frmZona_Load(object sender, EventArgs e)
        {
            _botones();
        }

        private void tsbZAdd_Click(object sender, EventArgs e)
        {
            if (!Validar(txtDpto.Text)) return;
            if (!Validar(txtAcron.Text)) return;

        }

        private void tsbZBuscar_Click(object sender, EventArgs e)
        {
            Zona z = null;
            List<Servicio> ls = new List<Servicio>();
            if (!Validar(txtDpto.Text)) return;
            else if (!Validar(txtAcron.Text)) return;
            else if (!Validar(txtNomOficial.Text)) return;

            ILogicaZona lz = LFabrica.GetInstZona();
            z = lz.BuscarZona(txtDpto.Text.Trim(), txtAcron.Text.Trim());

            if (z != null)
            {
                txtDpto.Text = z.IDDepartamento;
                txtAcron.Text = z.Acronimo;
                txtNomOficial.Text = z.NombreOficial;
                txtHab.Text = z.Habitantes.ToString();
                ls = z.Servicios;
                dgvServicios.DataSource = ls;
            }
            

        }
    }

    
}
