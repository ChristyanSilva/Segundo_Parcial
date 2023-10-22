using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class RepositorioEmpleado : Archivo
    {
        public RepositorioEmpleado(string fileName) : base(fileName)
        {
        }

        public List<Empleado> ConsultarTodos()
        {
            try
            {
                List<Empleado> listadeEmpleado = new List<Empleado>();

                StreamReader sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                {
                    listadeEmpleado.Add(Mapeo(sr.ReadLine()));
                }
                sr.Close();
                return listadeEmpleado;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private Empleado Mapeo(string datos)
        {
            if (datos == "" || datos == null)
            {
                return null;
            }
            var linea = datos.Split(';');
            Empleado empleado = new Empleado
            {
                Id = int.Parse(linea[0]),
                NombreEmpleado= linea[1],
                SalarioBase = double.Parse(linea[2]),
                EstadoEmpleado= bool.Parse(linea[3])
            };
            return empleado;
        }
    }
}
