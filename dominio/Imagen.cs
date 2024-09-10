using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string UrlImagen { get; set; }

        public Imagen() { }

        public Imagen(int Id_, int IdArticulo_, string UrlImagen_)
        {
            Id = Id_;
            IdArticulo = IdArticulo_;
            UrlImagen = UrlImagen_;
        }
    }
}
