using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEducativo
{
    public class EstudianteBase : IEstudiante
    {
        private string nombre;
        private double calificacion;

        public EstudianteBase(string nombre, double calificacion)
        {
            this.nombre = nombre;
            this.calificacion = calificacion;
        }
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Estudiante: {nombre}");
            Console.WriteLine($"Calificación base: {calificacion}");
        }
        public double ObtenerCalificacionBase()
        {
            return calificacion;
        }
    }
}
