using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEducativo
{
    internal class Program
    {
        static List<IEstudiante> estudiantes = new List<IEstudiante>();
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema Educativo TecNM ===");
                Console.WriteLine("Usando patrones Decorator y Adapter\n");
                Console.WriteLine("1. Registrar estudiante nuevo");
                Console.WriteLine("2. Registrar estudiante del sistema antiguo");
                Console.WriteLine("3. Mostrar lista de estudiantes");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción (1-4): ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        RegistrarEstudianteNuevo();
                        break;

                    case "2":
                        RegistrarEstudianteAntiguo();
                        break;

                    case "3":
                        MostrarEstudiantes();
                        break;

                    case "4":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema...");
                        System.Threading.Thread.Sleep(1000);
                        break;

                    default:
                        Console.WriteLine("\nOpción inválida, presiona ENTER para intentar de nuevo...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static void RegistrarEstudianteNuevo()
        {
            Console.Clear();
            Console.WriteLine("=== Registro de nuevo estudiante ===\n");
            Console.Write("Nombre del estudiante: ");
            string nombre = LeerTextoObligatorio();
            Console.Write("Calificación base (0 - 100): ");
            double calificacion = LeerCalificacion();
            IEstudiante estudiante = new EstudianteBase(nombre, calificacion);
            if (LeerRespuestaSiNo("¿Agregar módulos extra? (s/n): "))
            {
                EvaluacionExtraDecorator extra = new EvaluacionExtraDecorator(estudiante);
                bool agregarOtro = true;
                while (agregarOtro)
                {
                    Console.Write("Nombre del módulo extra: ");
                    string nombreModulo = LeerTextoObligatorio();

                    Console.Write($"Calificación para {nombreModulo} (0 - 100): ");
                    double califModulo = LeerCalificacion();

                    extra.AgregarModulo(nombreModulo, califModulo);

                    agregarOtro = LeerRespuestaSiNo("¿Agregar otro módulo extra? (s/n): ");
                }

                estudiante = extra;
            }

            estudiante = new ValidacionDecorator(estudiante, calificacion);
            estudiantes.Add(estudiante);

            Console.WriteLine("\nEstudiante registrado exitosamente.");
            Console.WriteLine("Presiona ENTER para volver al menú...");
            Console.ReadLine();
        }

        static void RegistrarEstudianteAntiguo()
        {
            Console.Clear();
            Console.WriteLine("=== Registro de alumno del sistema antiguo ===\n");

            Console.Write("Nombre del alumno antiguo: ");
            string nombreAntiguo = LeerTextoObligatorio();

            Console.Write("Calificación registrada (0 - 100): ");
            double calificacionAntigua = LeerCalificacion();

            ISistemaAntiguo sistemaAntiguo = new SistemaAntiguo();
            IEstudiante adaptado = new SistemaAdapter(sistemaAntiguo, nombreAntiguo, calificacionAntigua);
            estudiantes.Add(adaptado);

            Console.WriteLine("\n✅ Alumno antiguo registrado exitosamente.");
            Console.WriteLine("Presiona ENTER para volver al menú...");
            Console.ReadLine();
        }
        static void MostrarEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE ESTUDIANTES REGISTRADOS ===");

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("\nNo hay estudiantes registrados aún.");
            }
            else
            {
                int contador = 1;
                foreach (var e in estudiantes)
                {
                    Console.WriteLine($"\n-- Estudiante #{contador} --");
                    e.MostrarInformacion();
                    contador++;
                }
                Console.WriteLine($"\nTotal de estudiantes: {estudiantes.Count}");
            }
            Console.WriteLine("\nPresiona ENTER para volver al menú...");
            Console.ReadLine();
        }
        static string LeerTextoObligatorio()
        {
            string texto;
            do
            {
                texto = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(texto))
                    Console.Write("Por favor ingrese un nombre: ");
            } while (string.IsNullOrEmpty(texto));
            return texto;
        }
        static double LeerCalificacion()
        {
            double valor;
            bool valido = false;
            do
            {
                string entrada = Console.ReadLine();
                if (double.TryParse(entrada, out valor) && valor >= 0 && valor <= 100)
                    valido = true;
                else
                    Console.Write("Calificación inválida. Ingrese un valor entre 0 y 100: ");
            } while (!valido);
            return valor;
        }
        static bool LeerRespuestaSiNo(string mensaje)
        {
            string respuesta;
            do
            {
                Console.Write(mensaje);
                respuesta = Console.ReadLine()?.Trim().ToLower();

                if (respuesta != "s" && respuesta != "n")
                    Console.WriteLine("Por favor, ingresa solo 's' o 'n'.");
            } while (respuesta != "s" && respuesta != "n");

            return respuesta == "s";
        }
    }
}
