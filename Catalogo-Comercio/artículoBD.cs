using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogo_Comercio;
using System.Xml.Linq;
using Dominio;
using System.Security.Cryptography.X509Certificates;

namespace Catalogo_Comercio
{
    internal class artículoBD
    {
        PublicKey void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Insert Into ARTICULOS (Id, Codigo, Nombre, Descripcion, Marca, Categoria, Imagen, Precio) Values ('" + nuevo.Id + "', '" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '" + nuevo.Marca + "', '" + nuevo.Categoria + "', '" + nuevo.Imagen + "', '" + nuevo.Precio + "')");
                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
