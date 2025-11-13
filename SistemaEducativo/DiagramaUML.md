# Sistema Educativo con Patrones Decorator y Adapter

Este proyecto en C# implementa los patrones **Decorator** y **Adapter** en un sistema educativo con módulos extra de evaluación.  
Permite agregar funcionalidades dinámicas a los objetos (Decorator) y adaptar sistemas antiguos a la nueva estructura (Adapter).

---

## 📊 Diagrama UML (Mermaid)

```mermaid
classDiagram
    direction LR

    class IEstudiante {
        +string Nombre
        +double Calificacion
        +void MostrarInformacion()
    }

    class EstudianteBase {
        +string Nombre
        +double Calificacion
        +MostrarInformacion()
    }

    IEstudiante <|.. EstudianteBase

    class EstudianteDecorator {
        #IEstudiante estudiante
        +EstudianteDecorator(IEstudiante estudiante)
        +MostrarInformacion()
    }

    IEstudiante <|.. EstudianteDecorator
    EstudianteDecorator <|-- EvaluacionExtraDecorator
    EstudianteDecorator <|-- ValidacionDecorator

    class EvaluacionExtraDecorator {
        -string NombreModulo
        -double CalificacionExtra
        +EvaluacionExtraDecorator(IEstudiante estudiante, string nombreModulo, double calificacionExtra)
        +double ObtenerCalificacionExtra()
        +MostrarInformacion()
    }

    class ValidacionDecorator {
        +ValidacionDecorator(IEstudiante estudiante)
        +MostrarInformacion()
    }

    class ISistemaAntiguo {
        +void RegistrarAlumno(string nombre, double calificacion)
    }

    class SistemaAntiguo {
        +RegistrarAlumno(string nombre, double calificacion)
    }

    ISistemaAntiguo <|.. SistemaAntiguo

    class SistemaAdapter {
        -ISistemaAntiguo sistemaAntiguo
        +string Nombre
        +double Calificacion
        +SistemaAdapter(ISistemaAntiguo sistemaAntiguo, string nombre, double calificacion)
        +MostrarInformacion()
    }

    IEstudiante <|.. SistemaAdapter
    ISistemaAntiguo <-- SistemaAdapter

    class Program {
        +Main(string[] args)
    }

    Program --> IEstudiante : usa
    Program --> SistemaAdapter : crea
    Program --> SistemaAntiguo : crea
    Program --> EvaluacionExtraDecorator : agrega módulo
    Program --> ValidacionDecorator : valida
