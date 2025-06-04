
namespace PokemonSimulator.Handlers
{
    public static class InputHandler
    {
        public static string ReadValidatedString(string prompt, bool lettersOnly = false)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                if (lettersOnly && !input.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.WriteLine("Input must only contain letters and spaces.");
                    continue;
                }

                return input;
            }
        }

        public static int ReadValidatedInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result >= min && result <= max)
                        return result;
                    else
                        Console.WriteLine($"Value must be between {min} and {max}.");
                }
                else
                {
                    Console.WriteLine("Invalid number. Please enter a valid integer.");
                }
            }
        }
    }
}
