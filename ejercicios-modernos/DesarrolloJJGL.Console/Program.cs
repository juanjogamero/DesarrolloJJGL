using System.Globalization;
using System.Text;

namespace DesarrolloJJGL.ConsoleApp;

public static class Program
{
    public static int Main(string[] args)
    {
        if (args.Contains("--self-test", StringComparer.OrdinalIgnoreCase))
        {
            return RunSelfTests();
        }

        while (true)
        {
            Console.WriteLine("\n=== Laboratorio de C# ===");
            Console.WriteLine("1. Comprobar número primo");
            Console.WriteLine("2. Analizar una lista de números");
            Console.WriteLine("3. Comprobar palíndromo");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    Console.Write("Introduce un número entero: ");
                    if (int.TryParse(Console.ReadLine(), out int number))
                        Console.WriteLine(Exercises.IsPrime(number) ? "Es primo." : "No es primo.");
                    else
                        Console.WriteLine("Entrada no válida: introduce un número entero.");
                    break;
                case "2":
                    Console.Write("Números separados por comas (ej. 1, 2, 3): ");
                    if (!Exercises.TryParseNumbers(Console.ReadLine(), out var values))
                    {
                        Console.WriteLine("Entrada incorrecta: usa números enteros separados por comas.");
                        break;
                    }
                    var stats = Exercises.CalculateStatistics(values);
                    Console.WriteLine($"Cantidad: {stats.Count}; mínimo: {stats.Minimum}; máximo: {stats.Maximum}; media: {stats.Average:F2}");
                    break;
                case "3":
                    Console.Write("Introduce un texto: ");
                    Console.WriteLine(Exercises.IsPalindrome(Console.ReadLine() ?? "")
                        ? "Es un palíndromo." : "No es un palíndromo.");
                    break;
                case "0":
                    return 0;
                default:
                    Console.WriteLine("Opción desconocida. Selecciona 0, 1, 2 o 3.");
                    break;
            }
        }
    }

    private static int RunSelfTests()
    {
        var tests = new (string Name, bool Passed)[]
        {
            ("Prime: 2", Exercises.IsPrime(2)),
            ("Prime: 97", Exercises.IsPrime(97)),
            ("Prime: 1 is not prime", !Exercises.IsPrime(1)),
            ("Prime: negatives are not prime", !Exercises.IsPrime(-7)),
            ("Prime: 100 is not prime", !Exercises.IsPrime(100)),
            ("Numbers: accepts CSV", Exercises.TryParseNumbers("1, 2, -3", out var nums) && nums.SequenceEqual(new[] { 1, 2, -3 })),
            ("Numbers: rejects empty input", !Exercises.TryParseNumbers("", out _)),
            ("Numbers: rejects invalid values", !Exercises.TryParseNumbers("1, abc", out _)),
            ("Statistics: one element", Exercises.CalculateStatistics(new[] { 5 }).Average == 5),
            ("Statistics: average and range", CheckStats()),
            ("Palindrome: normalized phrase", Exercises.IsPalindrome("Anita lava la tina")),
            ("Palindrome: case and punctuation", Exercises.IsPalindrome("¿Acaso hubo búhos acá?")),
            ("Palindrome: not a palindrome", !Exercises.IsPalindrome("C# es genial")),
            ("Palindrome: empty string is not accepted", !Exercises.IsPalindrome("  "))
        };

        foreach (var test in tests)
            Console.WriteLine($"{(test.Passed ? "PASS" : "FAIL")} - {test.Name}");

        int failed = tests.Count(test => !test.Passed);
        Console.WriteLine($"Resultados: {tests.Length - failed}/{tests.Length} correctos");
        return failed == 0 ? 0 : 1;
    }

    private static bool CheckStats()
    {
        var result = Exercises.CalculateStatistics(new[] { 2, 4, 6 });
        return result.Count == 3 && result.Minimum == 2 &&
               result.Maximum == 6 && Math.Abs(result.Average - 4) < 0.0001;
    }
}

public readonly record struct Statistics(int Count, int Minimum, int Maximum, double Average);

public static class Exercises
{
    public static bool IsPrime(int value)
    {
        if (value < 2) return false;
        if (value == 2) return true;
        if (value % 2 == 0) return false;

        for (int divisor = 3; divisor <= value / divisor; divisor += 2)
            if (value % divisor == 0) return false;

        return true;
    }

    public static bool TryParseNumbers(string? input, out int[] values)
    {
        values = Array.Empty<int>();
        if (string.IsNullOrWhiteSpace(input)) return false;

        string[] parts = input.Split(',');
        var numbers = new List<int>(parts.Length);
        foreach (string part in parts)
        {
            if (!int.TryParse(part.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int number))
                return false;
            numbers.Add(number);
        }

        values = numbers.ToArray();
        return values.Length > 0;
    }

    public static Statistics CalculateStatistics(IReadOnlyList<int> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        if (values.Count == 0)
            throw new ArgumentException("La colección no puede estar vacía.", nameof(values));

        long total = 0;
        int min = values[0], max = values[0];
        foreach (int value in values)
        {
            total += value;
            if (value < min) min = value;
            if (value > max) max = value;
        }

        return new Statistics(values.Count, min, max, (double)total / values.Count);
    }

    public static bool IsPalindrome(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        string decomposed = input.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder(decomposed.Length);
        foreach (char c in decomposed)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
                continue;
            if (char.IsLetterOrDigit(c))
                builder.Append(char.ToLowerInvariant(c));
        }

        string normalized = builder.ToString();
        if (normalized.Length == 0) return false;
        for (int left = 0, right = normalized.Length - 1; left < right; left++, right--)
            if (normalized[left] != normalized[right]) return false;
        return true;
    }
}
