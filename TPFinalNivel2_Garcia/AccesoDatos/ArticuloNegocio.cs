using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select Codigo, Nombre, ImagenUrl, Precio, A.Descripcion , C.Descripcion Categoria, M.Descripcion Marcas  from ARTICULOS A, CATEGORIAS C, MARCAS M  where A.Id = C.Id and M.Id= A.Id");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    //aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = Convert.ToString(datos.Lector["Precio"]);
                    aux.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);

                    /*---Traer Categoria---*/
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    /*---Traer Marca---*/
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marcas"];

                    lista.Add(aux);
                }
                datos.CerrarConexion();
                return lista;

            }
            catch (Exception)
            {

                throw;
            }


        }

        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into ARTICULOS(codigo, nombre, IdMarca, IdCategoria, ImagenUrl,Precio) values (@Codigo, @Nombre,@IdMarca,@IdCategoria,@UrlImagen,@Precio)");
                datos.SetearParametros("@Codigo", nuevo.Codigo);
                datos.SetearParametros("@Nombre", nuevo.Nombre);
                datos.SetearParametros("@IdMarca", nuevo.Marca.Id);
                datos.SetearParametros("@IdCategoria", nuevo.Categoria.Id);
                datos.SetearParametros("@UrlImagen", nuevo.ImagenUrl);
                datos.SetearParametros("@Precio", nuevo.Precio);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(Articulo modificar)
        {

        }
    }
}
