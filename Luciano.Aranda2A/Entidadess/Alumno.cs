using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Alumno
    {
        string _apellido;
        int _legajo;
        string _nombre;
        float _nota;

        #region propiedades
        public string Apellido { get { return this._apellido; } set { this._apellido = value; } }
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }
        public int Legajo { get { return this._legajo; } set { this._legajo = value; } }
        public float Nota { get { return this._nota; } set { this._nota = value; } }
        #endregion

        #region metodos

        public Alumno (int legajo, string nombre, string apellido)
        {
            this.Legajo = legajo;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        private string Mostrar()
        {
            return "Nombre: " + this.Nombre.PadRight(15) + " Apellido: " + this.Apellido.PadRight(15) + " Legajo: " + this.Legajo + " Nota: " + this.Nota + "\n";
        }

        public static string Mostrar(Alumno alumno)
        {
            return alumno.Mostrar();
        }

        public static bool operator ==(Alumno a1, Alumno a2)
        {
            return Object.Equals(a1.Legajo, a2.Legajo);
        }

        public static bool operator !=(Alumno a1, Alumno a2)
        {
            return !(a1 == a2);
        }

        #endregion
    }
}
