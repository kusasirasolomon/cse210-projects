using System;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to end.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            if (!scripture.AllWordsHidden())
            {
                scripture.HideRandomWords(3);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }

        // Enhancement: Added ability to handle multiple-verse references and non-repeated word hiding.
    }
}
 