// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

namespace HW9
{
    public class ConsoleApp
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the number summ finder! Please, insert start and end value (example: 1, 2):");
            var input = Console.ReadLine();
            if (!TryParse(input, out var interval))
            {
                Console.WriteLine("Sorry program could not handle inserted values... Bye!");
            }

            Console.WriteLine(SummInterval(interval[0], interval[1]));
        }

        static bool TryParse(string input, out int[] result)
        {
            result = new int[2];
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var arr = input.Split(',');
            if (arr.Length != 2)
            {
                return false;
            }

            var hasError = false;
            result = arr.Select(v => { if ( int.TryParse(v, out var number)) { return number; } else { hasError = true; return 0; }; }).ToArray();
            if (hasError)
            {
                return false;
            }

            if (result[0] > result[1])
            {
                return false;
            }

            return true;
        }

        static int SummInterval(int start, int end)
        {
            if (start == end)
            {
                return start;
            }

            return start + SummInterval(start + 1, end);
        }
    }
}