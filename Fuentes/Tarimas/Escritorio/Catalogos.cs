using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class Catalogos : Form
    {

        public int opcionSeleccionada;

        public Catalogos()
        {
            InitializeComponent();
        }

        private void Catalogos_Load(object sender, EventArgs e)
        {

            if (this.opcionSeleccionada == (int)LogicaTarima.NumeracionCatalogos.Numeracion.productor)
            {
                
            }

        }

        private void CargarProductores() 
        {
            
            

        }

    }
}
