using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        // Propiedades
        public int Id { get; set; } // el id es autonumerico en la base de datos 
        [DisplayName("Código")]
        public string Codigo { get; set; } // el codigo contiene numeros y letras
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public decimal Precio { get; set; }

        // Metodos
        public override string ToString()
        {
            return Descripcion;
        }
    }
}