using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_Inventario_lista_circular_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Ruta ruta1 = new Ruta();

        private void btnAgregarBase_Click(object sender, EventArgs e)
        {
            Base base1 = new Base(txtNombreBase.Text, Convert.ToInt32(txtMinutosBase.Text));

            ruta1.agregarBase(base1);
            //txtReporte.Text = ruta1.reporteDeBases();
        }
        
        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = ruta1.reporteDeBases();
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            Base base1 = new Base(txtNombreBase.Text, Convert.ToInt32(txtMinutosBase.Text));

            ruta1.agregarBaseInicio(base1);
        }

        private void btnInsertarDespues_Click(object sender, EventArgs e)
        {
            Base base1 = new Base(txtNombreBase.Text, Convert.ToInt32(txtMinutosBase.Text));

            ruta1.insertarDespuesDe(txtBaseDespues.Text, base1);
        }

        private void btnBuscarXNombre_Click(object sender, EventArgs e)
        {
            txtReporte.Text = ruta1.buscarPorNombre(txtBaseDespues.Text).ToString();
        }

        private void btnEliminarXNombre_Click(object sender, EventArgs e)
        {
            ruta1.eliminarPorNombre(txtBaseDespues.Text);
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            //txtReporte.Text = dtpHoraInicio.Value.AddMinutes(+60).ToString();
            DateTime inicio = dtpHoraInicio.Value;
            DateTime fin = dtpHoraFin.Value;

            txtReporte.Text = ruta1.recorrido(txtNombreRecorrido.Text, inicio, fin);
        }
    }
}
