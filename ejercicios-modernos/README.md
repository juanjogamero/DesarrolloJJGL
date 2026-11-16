# Ejercicios modernos de C# (.NET 8)

Esta carpeta **complementa** las prácticas académicas del repositorio. Son ejercicios nuevos, independientes de los proyectos históricos, con validación de entradas, separación de funciones y comprobaciones automatizadas sin paquetes externos.

| Ejercicio | Conceptos |
| --- | --- |
| Número primo | Bucles, divisibilidad, casos límite |
| Estadísticas de una lista | Colecciones, validación, tipos numéricos, cálculos |
| Detector de palíndromos | Cadenas, normalización Unicode, condiciones |

## Requisitos

- SDK de .NET 8 o superior compatible con el proyecto.
- Windows, macOS o Linux.

## Ejecución

Desde la raíz del repositorio:

```bash
dotnet run --project ejercicios-modernos/DesarrolloJJGL.Console
```

## Comprobaciones automáticas

```bash
dotnet run --project ejercicios-modernos/DesarrolloJJGL.Console -- --self-test
```

Las comprobaciones se ejecutan en GitHub Actions y devuelven un código de error si alguna falla. No sustituyen a una suite de pruebas unitarias profesional; son una primera base sin dependencias externas.

## Decisiones de diseño

- Se usa `TryParse` para evitar excepciones ante entradas inválidas.
- Se contemplan valores negativos, colecciones vacías y texto con tildes.
- Se emplea `long` para acumular enteros y evitar desbordamientos intermedios habituales.
- El código histórico permanece sin alteraciones en las carpetas `TEMA ...`.

## Próximos ejercicios propuestos

- Gestión de contactos con búsqueda y persistencia JSON.
- Inventario con clases, interfaces e inyección de dependencias.
- Consumo de API REST mediante `HttpClient` con cancelación.
- Pruebas unitarias con un proyecto separado y cobertura.
