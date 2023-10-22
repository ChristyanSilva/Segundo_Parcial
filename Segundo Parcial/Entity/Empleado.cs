using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Empleado
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public double SalarioBase { get; set; }
        public bool EstadoEmpleado { get; set; }

        public Empleado() { }

        public override string ToString()
        {
            return $"{Id};{NombreEmpleado};{SalarioBase};{EstadoEmpleado}";
        }
    }
}
