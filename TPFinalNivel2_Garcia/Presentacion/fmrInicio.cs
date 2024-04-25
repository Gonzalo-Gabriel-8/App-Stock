using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dominio;
using Negocio;
using Helper;


namespace Presentacion
{
    public partial class fmrArticulos : Form
    {
        private List<Articulo> listaArticulo;
        public fmrArticulos()
        {
            InitializeComponent();
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            fmrAltaArticulo alta= new fmrAltaArticulo();

            alta.ShowDialog();
        }

        

        private void fmrArticulos_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            dgvArticulos.DataSource = listaArticulo;
            dgvArticulos.Columns["ImagenUrl"].Visible=false;

            /*---Carga de la imagen en el PictureBox---*/
            pbxArticulo.Load(listaArticulo[0].ImagenUrl);
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            /*---Cambiar la imagen al hacer click---*/
            Articulo artSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            CargarImagen(artSeleccionado.ImagenUrl);
        }
        public void CargarImagen(string imagen)
        {
            /*---Carga en caso de que la imagen no este disponible---*/
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception)
            {

                pbxArticulo.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }

        }
    }
}
