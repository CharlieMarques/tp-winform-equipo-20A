using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        // Propiedades
        public int Id { get; set; } // el id es autonumerico en la base de datos 
        public string Codigo { get; set; } // el codigo contiene numeros y letras
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public Imagen Imagen { get; set; }
        public float Precio { get; set; }

        // Metodos
        public override string ToString()
        {
            return Descripcion;
        }
    }
}