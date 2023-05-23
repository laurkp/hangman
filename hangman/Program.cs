namespace hangman
{
    internal class Program
    {
        const int GUESSLIMIT = 10;
        static void Main(string[] args)
        {
            //Prompting the start of the game
            Console.WriteLine("Let's play Hangman Game!!!");

            //Declaring a random variable
            Random random = new Random();

            //Declaring a list of words
            List<string> list = new List<string>() { "abruptly", "frizzled", "glyph", "icebox", "buffon", "bikini", "clown", "exodus", "vortex" };

            //Declaring a variable that takes a random word from the list
            int index = random.Next(list.Count);
            string mysteryWord = list[index];
            int guessCount = 1;
            int correctLettersGuessed = 0;
            char[] guessed = new char [mysteryWord.Length];
            for (int c = 0; c < mysteryWord.Length; c++)
            {
                guessed[c] = '_';
            }
           

            while (guessCount <= GUESSLIMIT)
            {
                //Prompting "______" instead of mystery word and each letter guessed 
                Console.Write("Mystery word: ");
                for (int i = 0; i < guessed.Length; i++)
                {
                    Console.Write(Char.ToUpper(guessed[i]));
                }
                Console.WriteLine("\nGuess a letter: ");
                char playerGuess;
                if (!char.TryParse(Console.ReadLine(), out playerGuess))
                {
                    Console.WriteLine("Invalid input. Please enter a single character.");
                    continue;
                }
                Console.Clear();

                // Check if the player has already guessed the letter
                if (guess.Contains(playerGuess))
                {
                    Console.WriteLine("You already guessed this letter. Please enter a different letter.");
                    continue;
                }
                //Check if the player guessed a letter
                bool correctGuess = false;
                for (int l = 0; l < mysteryWord.Length; l++)
                {
                    if (playerGuess == mysteryWord[l])
                    {
                        guessed[l] = playerGuess;
                        correctGuess = true;
                        correctLettersGuessed++;
                        Console.WriteLine("Correct guess!");
                    }
                }
                if (correctLettersGuessed == mysteryWord.Length) 
                {
                    //Prompting when you guess the word
                    Console.WriteLine("Congratulations, you guessed the word!");
                    break;
                }
                if (correctGuess == false)
                {
                    //Prompting how many guesses are left after a wrong guess
                    int guessLeft = GUESSLIMIT - guessCount;
                    Console.WriteLine($"Wrong guess. You have {guessLeft} guesses remaining.");

                    //Prompting when you lose and the mystery word
                    if (guessLeft == 0)
                    {
                        Console.WriteLine("You lose!");
                        Console.WriteLine($"The word was: {mysteryWord.ToUpper()}");
                        return;
                    }
                    guessCount++;
                }
            }
        }
    }
}
