namespace BT1
{
    internal class Program
    {
        static void Main(string[] arrs)
        {
            Random rd = new Random();
            int Numrd = rd.Next(100, 999);
            string targetString = Numrd.ToString();                                                                               
            int maxGuess= 7; // số lần đoán tối đa
            int attemp = 1; // số lần đoán của người chơi
            string feedback = "",guess;  
            Console.WriteLine("    " + Numrd);
            Console.WriteLine("--------------");
            while (feedback != "+++" && attemp <= maxGuess)
            {
                Console.Write("Player [{0}]: " ,attemp);
                guess = Console.ReadLine();
                feedback = getFeedBack(targetString,guess);
                Console.WriteLine("Computer: " + feedback);
                attemp++;   
            }
            Console.WriteLine("Player has guessed {0} times. End Game. ", attemp - 1);
            if (attemp > maxGuess)
                Console.WriteLine("You Lose !!!. Number to predict: " + Numrd);
            else
                Console.WriteLine("You Winnn !!!",attemp);
            Console.ReadKey();  
        }

        private static string getFeedBack(string targetString, string guess)
        {
           string feedback = "";
            for (int i = 0; i < targetString.Length; i++)
            {
                if (targetString[i] == guess[i])
                    feedback += "+";
                else if (targetString.Contains(guess[i].ToString()))
                    feedback += "?";
            }
            return feedback;
        }
    }
}
