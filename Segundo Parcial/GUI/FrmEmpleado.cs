using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmEmpleado : Form
    {
        public FrmEmpleado()
        {
            InitializeComponent();
        }
        ServicioEmpleado servicioEmpleado= new ServicioEmpleado();
        private List<Empleado> Listadeempleados;

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            
            this.Close();
            frmPrincipal.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            bool confirmacion = true;
            if (int.Parse(txtId.Text)!= null)
            {
                empleado.Id = int.Parse(txtId.Text);
            }
            else
            {
                MessageBox.Show("El campo de IDENTIFICACION no puede estar vacio");
                confirmacion=false;
            }
            if (txtNombreEmpleado.Text!= null)
            {
                empleado.NombreEmpleado = txtNombreEmpleado.Text;
            }
            else
            {
                MessageBox.Show("El campo de NOMBRES no puede estar vacio");
                confirmacion = false;
            }
            if (double.Parse(txtSalarioBase.Text) != null)
            {
                empleado.SalarioBase = double.Parse(txtSalarioBase.Text);
            }
            else
            {
                MessageBox.Show("El campo de SALARIO no puede estar vacio");
                confirmacion = false;
            }
            if (cbEstado.Text=="Activo")
            {
                empleado.EstadoEmpleado = true;
            }
            else
            {
                if (cbEstado.Text == "Inactivo")
                {
                    empleado.EstadoEmpleado = false;
                }
                else
                {
                    MessageBox.Show("El campo de ESTADO del EMPLEADO no debe estar vacio...");
                    confirmacion = false;
                }
            }
            if (confirmacion == true)
            {
                Guardar(empleado);
            }else
            {
                MessageBox.Show("No se pudo crear el EMPLEADO");
            }            
            CargarGrilla(servicioEmpleado.Consultar());
            CargarEmpleados();
        }

        void Guardar(Empleado empleado)
        {
            var msg = servicioEmpleado.Guardar(empleado);
            MessageBox.Show(msg);
        }

        void CargarGrilla(List<Empleado> listadeEmpleados)
        {
            dgvEmpleados.Rows.Clear();

            foreach (var item in listadeEmpleados)
            {
                dgvEmpleados.Rows.Add(item.Id, item.NombreEmpleado, item.SalarioBase);
            }

        }

        private void listaEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = listaEmpleados.SelectedIndex.ToString();

            string codigo = listaEmpleados.SelectedValue.ToString();
            Buscar(codigo);
        }

        private void Buscar(string codigo)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar(servicioEmpleado.BuscarporNombre(listaEmpleados.SelectedValue.ToString()));
            CargarGrilla(servicioEmpleado.Consultar());
            CargarEmpleados();
        }

        void Eliminar(Empleado empleado)
        {
            var lista = servicioEmpleado.Consultar();
            lista.Remove(empleado);

            servicioEmpleado.Eliminar(lista);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            var filtro = txtFiltro.Text;
            var lista = servicioEmpleado.BuscarporNombre(filtro);
            //CargarGrilla(lista);
        }

        void CargarDatos()
        {
            cbEstado.DataSource = servicioEmpleado.Consultar();
            cbEstado.ValueMember = "Id";
            cbEstado.DisplayMember = "NombreEmpleado";
        }

        private void txtNombreEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {                
                e.Handled = true;
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtSalarioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            CargarGrilla(servicioEmpleado.Consultar());
            CargarEmpleados();
        }
        void CargarEmpleados()
        {
            listaEmpleados.DataSource = servicioEmpleado.Consultar();
            listaEmpleados.ValueMember = "Id";
            listaEmpleados.DisplayMember = "NombreEmpleado";
        }

    }
}
