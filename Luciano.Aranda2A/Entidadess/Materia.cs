using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Materia
    {
        public enum EMateria
        {
            Laboratorio_I,
            Laboratorio_II,
            Porgramacion_I,
            Porgramacion_II
        }

        List<Alumno> _alumnos;
        EMateria _nombre;
        static Random _notaParaUnAlumno;

        #region propiedades

        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }
        public EMateria Nombre { get { return this._nombre; } set { this._nombre = value; } }

        #endregion

        #region constructores

        static Materia()
        {
            _notaParaUnAlumno = new Random();
        }

        private Materia()
        {
            this._alumnos = new List<Alumno>();
        }

        private Materia(EMateria nombre) : this()
        {
            this.Nombre = nombre;
        }

        #endregion

        #region metodos

        private string Mostrar()
        {
            string sb = "Nombre de la materia: " + this.Nombre + "\n\n";

            foreach ( Alumno alumno in this._alumnos )
            {
                sb += Alumno.Mostrar(alumno);
            }

            return sb;
        }

        public void CalificarAlumnos()
        {
            foreach ( Alumno alumno in this._alumnos )
            {
                alumno.Nota = _notaParaUnAlumno.Next(0,10);
            }
        }

        #endregion

        #region sobrecarga de operadores

        public static explicit operator string(Materia materia)
        {
            return materia.Mostrar();
        }

        public static implicit operator float(Materia m)
        {
            float acumulakevin = 0;
            float promedio = 0;

            foreach (Alumno alumno in m.Alumnos)
            {
                acumulakevin += alumno.Nota;
            }

            promedio = acumulakevin / m.Alumnos.Count;

            return promedio;
        }

        public static implicit operator Materia(EMateria nombre)
        {
            Materia materia = new Materia(nombre);
            return materia;
        }

        public static bool operator ==(Materia m, Alumno a)
        {
            foreach(Alumno alumno in m.Alumnos)
            {
                if ( alumno == a )
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Materia m, Alumno a)
        {
            return !(m == a);
        }

        public static Materia operator +(Materia m, Alumno a)
        {
            if ( !(m == a) )
            {
                m.Alumnos.Add(a);
            }

            return m;
        }

        public static Materia operator -(Materia m, Alumno a)
        {
            if (m == a)
            {
                m.Alumnos.RemoveAt(m.Alumnos.IndexOf(a));
            }

            return m;
        }


        #endregion
    }
}
