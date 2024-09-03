using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public Marca(string descripcion) // quizas agregar int id, si la base no lo hace autonumerico
        {
            Descripcion = descripcion;
        }
        public Marca() { }
        public int Id { get; } //el id es autonimerico en la base de datos no deberia de tener set, en todo caso un metodo que lo convierta en autonumerico
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
