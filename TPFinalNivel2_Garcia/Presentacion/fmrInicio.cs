using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class fmrArticulos : Form
    {
        public fmrArticulos()
        {
            InitializeComponent();
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            fmrAltaArticulo alta= new fmrAltaArticulo();

            alta.ShowDialog();
        }
    }
}
