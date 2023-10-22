using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Archivo
    {
        protected string fileName;
        public Archivo(string fileName)
        {
            this.fileName = fileName;
        }
        public void Eliminar<T>(List<T> lista)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName);
                foreach (var item in lista)
                {
                    sw.WriteLine(item.ToString());
                }

                sw.Close();
                //return "datos guardados";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public String Guardar(string datos)
        {
            //try
            //{
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine(datos);
            sw.Close();
            return "datos guardados";
            //}
            //catch (Exception)
            //{

            //    return "error al guardar";
            //}
        }
    }
}
