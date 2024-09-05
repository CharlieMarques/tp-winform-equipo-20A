using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo_Comercio
{
    public class CategoriaBD
    {
        List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setConsulta("Select Id, Descripcion from CATEGORIAS");
                data.Leer();
                while(data.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)data.Lector["Id"];
                    aux.Descripcion = (string)data.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }

        }
    }
}
