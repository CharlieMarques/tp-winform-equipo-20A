﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Catalogo_Comercio
{
    public class MarcaBD
    {
        public List<Marca> listar()
        {
            List<Marca>lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Select Id, Descripcion From MARCAS");
                datos.Leer();

                while(datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id =(int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
                datos.cerrarConexion();
            }
        }
    }
}
