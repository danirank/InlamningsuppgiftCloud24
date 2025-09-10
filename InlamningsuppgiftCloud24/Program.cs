namespace InlamningsuppgiftCloud24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string testString = "29535123p48723487597645723645";

            // En currentNumber lista som kontrollerar
            List<char> currentNumber = new List<char>();

            // Lista för att lägga godkända tal i
            List<string> correctNumber = new List<string>();


            Console.WriteLine($"Teststräng: {testString}");

            /*
             * Planen var att loopa igenom strängen med två pekare. En startar på första index och en startar på andra. Loopa igenom till något villkor bryter loopen 
             * Villkor som bryter, siffror är lika, ingen valid siffra
             * Om vi kommer igenom loopen utan att den stannar har vi heller inte valid tal eftersom den ska stann aom de är två lika siffror
             */

            for (int i = 0; i < testString.Length - 1; i++)
            {
                int j = i + 1;
                bool validNumber1 = int.TryParse(testString[i].ToString(), out int number1);

                if (validNumber1)
                    currentNumber.Add(testString[i]);
                else
                    continue;

                while (j < testString.Length)
                {


                    bool validNumber2 = int.TryParse(testString[j].ToString(), out int number2);

                    if (!validNumber2)
                    {
                        currentNumber.Clear();
                        break;
                    }

                    if (validNumber2 && number1 != number2)
                    {
                        currentNumber.Add(testString[j]);

                    }

                    if (number1 == number2)
                    {
                        currentNumber.Add(testString[j]);
                        break;
                    }
                    j++;

                }

                string validNumberString = String.Concat(currentNumber);

                if (currentNumber.Count >= 1 && currentNumber[0] == currentNumber[^1])
                {
                    correctNumber.Add(validNumberString);

                }

                currentNumber.Clear();


            }

            /* 
             För varje godkänt tal vill jag nu skriva ut teststrängen. Och när startindexet på den matchande strängen är lika ska vi byta färg
             
             */
            double sum = 0;
            foreach (string s in correctNumber)
            {
                sum += double.Parse(s);


                int startIndexOfSubString = testString.IndexOf(s);

                int j = 0;
                int i = 0;

                while (i < testString.Length)
                {
                    while (i < startIndexOfSubString)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(testString[i]);
                        i++;
                    }

                    if (i == startIndexOfSubString)
                    {

                        while (j < s.Length)
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(testString[i]);

                            j++;
                            i++;
                        }

                    }
                    if (i < testString.Length)
                    {

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(testString[i]);
                        j++;
                        i++;
                    }

                }

                Console.ForegroundColor = ConsoleColor.Gray;


                Console.WriteLine();

            }

            Console.WriteLine("Sum: " + sum);
        }
    }
}
