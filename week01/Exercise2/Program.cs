using System;

class Program
{
    static void Main(string[] args)
    {
         // Get input from user
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string letter = "";
        string sign = "";

        // Determine letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine + or - sign (Stretch Challenge)
        int lastDigit = grade % 10;

        if (letter != "F") // F has no + or -
        {
            if (lastDigit >= 7 && grade < 90)  // No A+
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Handle no A+ case
        if (letter == "A" && sign == "+")
        {
            sign = ""; // Remove +
        }

        // Display final grade
        Console.WriteLine($"\nYour letter grade is: {letter}{sign}");

        // Display pass/fail message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up. Keep trying, you'll get it next time!");
        }
    


    }
}