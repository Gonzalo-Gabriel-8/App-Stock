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
                datos.SetearConsulta("SELECT A.Codigo, A.Nombre, A.ImagenUrl, A.Precio, A.Descripcion, COALESCE(C.Descripcion, 'Sin categoría') AS Categoria, COALESCE(M.Descripcion, 'Sin marca') AS Marcas, A.IdCategoria, A.IdMarca, A.Id FROM ARTICULOS A LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN MARCAS M ON A.IdMarca = M.Id;");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("ImagenUrl")));
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = Convert.ToString(datos.Lector["Precio"]);
                    aux.Descripcion = Convert.ToString(datos.Lector["Descripcion"]);

                    /*---Traer Categoria---*/
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    /*---Traer Marca---*/
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
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

        public void Modificar(Articulo mod)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(" update ARTICULOS set Codigo= @cod, Nombre= @nombre, Descripcion= @descripcion, IdMarca= @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @imagenUrl, Precio = @precio where Id = @Id");
                datos.SetearParametros("@cod", mod.Codigo);
                datos.SetearParametros("@nombre", mod.Nombre);
                datos.SetearParametros("@descripcion", mod.Descripcion);
                datos.SetearParametros("@IdMarca", mod.Marca.Id);
                datos.SetearParametros("IdCategoria", mod.Categoria.Id);
                datos.SetearParametros("@imagenUrl", mod.ImagenUrl);
                datos.SetearParametros("@precio", mod.Precio);
                datos.SetearParametros("@Id", mod.Id);
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

        public void Eliminar( int id)
        {
            try
            {
                AccesoDatos eDatos = new AccesoDatos();
                eDatos.SetearConsulta("delete from ARTICULOS where id = @id");
                eDatos.SetearParametros("@id", id);
                eDatos.EjecutarAccion();
            }
            catch (Exception ex) 
            {

                throw ex;
            }
        }
    }
}
