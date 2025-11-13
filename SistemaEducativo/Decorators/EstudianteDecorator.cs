using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEducativo
{
    public abstract class EstudianteDecorator : IEstudiante
    {
        protected IEstudiante estudiante;
        public EstudianteDecorator(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }
        public virtual void MostrarInformacion()
        {
            estudiante.MostrarInformacion();
        }
    }
}
