using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEducativo
{
    public class SistemaAdapter : IEstudiante
    {
        private readonly ISistemaAntiguo _sistemaAntiguo;
        private readonly string _nombre;
        private readonly double _calificacion;

        public SistemaAdapter(ISistemaAntiguo sistemaAntiguo, string nombre, double calificacion)
        {
            _sistemaAntiguo = sistemaAntiguo;
            _nombre = nombre;
            _calificacion = calificacion;
        }

        public void MostrarInformacion()
        {
            string datos = $"{_nombre} | Calificación: {_calificacion}";
            _sistemaAntiguo.RegistrarAlumno(datos);
        }
    }
}
