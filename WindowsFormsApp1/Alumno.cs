using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Alumno
    {
        public Alumno()
        {
            Nombre = "nombre";
            Nota = 0;
        }

        public Alumno(string nombre, int nota)
        {
            Nombre = nombre;
            Nota = nota;
        }
        private string nombre;
        public string Nombre
        {
            set
            {
                nombre = value;
                if (nombre.Length > 20)
                {
                    nombre = nombre.Substring(0, 20);
                }
            }
            get
            {
                
                return nombre;
            }
        }
        private int nota;
        public int Nota
        {
            set
            {
                nota = value;
            }
            get
            {
                return nota;
            }
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
