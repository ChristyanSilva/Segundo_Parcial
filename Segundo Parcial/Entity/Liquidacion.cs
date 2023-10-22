using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Liquidacion
    {
        public int Anio { get; set; }
        public int Mes { get; set; }

        public void Periododeliquidacion(int anio, int mes)
        {
            Anio = anio;
            Mes = mes;
        }

    }
}
