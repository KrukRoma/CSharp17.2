using System.Text.RegularExpressions;

namespace CSharp17._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");

            if (!File.Exists(filePath))
            {
                string defaultText = "Examples of numbers: 12348768214762187, 12, 34, 56, 78, 90, 123, 45, 67, 89, 10, 11.";
                File.WriteAllText(filePath, defaultText);
            }

            string text = File.ReadAllText(filePath);

            string pattern = @"\b\d+\b";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            List<int> numbers = new List<int>();

            foreach (Match match in matches)
            {
                if (int.TryParse(match.Value, out int number))
                {
                    numbers.Add(number);
                }
            }

            Console.WriteLine("Found integers:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
