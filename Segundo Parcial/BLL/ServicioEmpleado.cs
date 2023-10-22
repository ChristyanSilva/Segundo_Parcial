using DLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioEmpleado
    {
        private string fileName = "Empleados.txt";
        RepositorioEmpleado repositorioEmpleado;
        private List<Empleado> empleados;

        public ServicioEmpleado()
        {
            repositorioEmpleado = new RepositorioEmpleado(fileName);
            RefrescarLista();
        }

        public void RefrescarLista()
        {
            empleados = repositorioEmpleado.ConsultarTodos();
        }

        public string Guardar(Empleado empleado)
        {
            var msg = repositorioEmpleado.Guardar(empleado.ToString());
            RefrescarLista();
            return msg;
        }

        public void Eliminar(List<Empleado> ListaEmpleados)
        {
            repositorioEmpleado.Eliminar(ListaEmpleados);
            RefrescarLista();
        }

        public Empleado BuscarporEstado(bool estado)
        {
            foreach (var item in empleados)
            {
                if (item.EstadoEmpleado == estado)
                {
                    return item;
                }
            }
            return null;
        }

        public Empleado BuscarporNombre(string nombre)
        {
            foreach (var item in empleados)
            {
                if (item.NombreEmpleado == nombre)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Empleado> Consultar()
        {
            return empleados;
        }


    }
}
