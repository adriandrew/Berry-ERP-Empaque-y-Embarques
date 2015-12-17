using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Cargar() {
            ServiceReference1.ServicioOptativaClient s = new ServiceReference1.ServicioOptativaClient();
            dataGridView1.DataSource = s.Listado();
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServicioOptativaClient s = new ServiceReference1.ServicioOptativaClient();
            ServiceReference1.Alumno a = new ServiceReference1.Alumno();
            dataGridView1.DataSource = s.Listado();
            a.Nombre = "Omar";
            a.Correo = "omar.fevz";
            s.Agregar(a);
            Cargar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
