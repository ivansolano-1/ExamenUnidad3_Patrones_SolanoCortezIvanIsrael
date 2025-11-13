using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEducativo
{
    public class SistemaAntiguo : ISistemaAntiguo
    {
        public void RegistrarAlumno(string datos)
        {
            Console.WriteLine($"[SISTEMA ANTIGUO] Registrando datos: {datos}");
        }
    }
}
