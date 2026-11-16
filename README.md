<div align="center">

# DesarrolloJJGL

**Ejercicios y proyectos de desarrollo con C#, WPF y .NET MAUI**

Repositorio de aprendizaje y evolución técnica de **Juan José Gamero López**.

![C#](https://img.shields.io/badge/C%23-512BD4?logo=dotnet&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8%20%2F%209-512BD4?logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-Windows-0078D4)
![MAUI](https://img.shields.io/badge/.NET%20MAUI-Multiplataforma-512BD4)

</div>

## Sobre el repositorio

Colección de trabajos académicos y ejercicios de programación que documentan el aprendizaje de C# desde la lógica básica hasta el desarrollo de aplicaciones de escritorio y multiplataforma.

El código original se conserva como **archivo de prácticas**; la carpeta [`ejercicios-modernos`](./ejercicios-modernos/) reúne nuevas implementaciones más estructuradas y comprobables.

## Contenidos

| Sección | Tecnología | Qué encontrarás |
| --- | --- | --- |
| [Tema 2 — Introducción a C#](./TEMA%202%20-%20INTRODUCCI%C3%93N%20A%20C%23/) | C#, consola | Condicionales, bucles, colecciones y lógica de programación |
| [Tema 3 — WPF](./TEMA%203%20-WPF/) | WPF, XAML | Ventanas, controles, eventos y ejemplos de conexión a MySQL |
| [Tema 7 — .NET MAUI](./TEMA%207%20-%20NETMAUI/) | .NET MAUI, XAML | Prácticas de interfaces y aplicaciones multiplataforma |
| [Ejercicios modernos](./ejercicios-modernos/) | .NET 8, C# | Lógica reutilizable, validación y comprobaciones automatizadas |

## Ejecución rápida: ejercicios modernos

Requiere el **SDK de .NET 8**.

```bash
git clone https://github.com/juanjogamero/DesarrolloJJGL.git
cd DesarrolloJJGL
dotnet run --project ejercicios-modernos/DesarrolloJJGL.Console
```

Para ejecutar las comprobaciones:

```bash
dotnet run --project ejercicios-modernos/DesarrolloJJGL.Console -- --self-test
```

El workflow [C# moderno · build y comprobaciones](./.github/workflows/modern-csharp.yml) construye el proyecto y ejecuta esas comprobaciones en cada cambio relevante.

## Abrir los proyectos originales

- **Consola:** abre el archivo `.sln` o `.csproj` del ejercicio correspondiente en Visual Studio.
- **WPF:** usa Visual Studio en Windows con soporte para desarrollo de escritorio .NET.
- **MAUI:** instala las cargas de trabajo de .NET MAUI y las herramientas de la plataforma de destino. Algunas prácticas usan .NET 9.
- Algunos ejercicios antiguos se crearon con **.NET Framework**; pueden requerir el entorno original o una migración individual. No se ha verificado la compilación completa de todas las prácticas históricas.

## Estado y mantenimiento

Este repositorio combina material histórico y mejoras nuevas. Los archivos `bin/` y `obj/` procedentes de compilaciones antiguas están presentes en el historial y en algunos directorios del repositorio. El archivo `.gitignore` añadido evita incorporar **nuevos** artefactos, pero no elimina los ya rastreados: ese saneamiento requiere una limpieza independiente y revisión de los archivos afectados.

No existe una aplicación web global que desplegar en GitHub Pages: los proyectos WPF y MAUI son aplicaciones locales/nativas. La validación automatizada se centra por ahora en los ejercicios modernos.

## Hoja de ruta

- [x] Documentación por tecnologías y requisitos.
- [x] Ejercicios adicionales con validación.
- [x] Compilación y comprobaciones automáticas para el nuevo módulo.
- [ ] Revisar y limpiar artefactos históricos rastreados por Git, sin perder fuentes.
- [ ] Revisar individualmente los proyectos antiguos y sus dependencias.
- [ ] Ampliar los ejercicios nuevos con persistencia, API y pruebas unitarias separadas.

## Autor

**Juan José Gamero López** · [GitHub](https://github.com/juanjogamero)

*Repositorio formativo. Se diferencian expresamente los ejercicios históricos de las mejoras incorporadas posteriormente.*
