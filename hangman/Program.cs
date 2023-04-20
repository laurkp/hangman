﻿namespace hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Prompting the start of the game
            Console.WriteLine("Let's play Hangman Game!!!");

            //Declaring a random variable
            var random = new Random();

            //Declaring a list of words
            var list = new List<string>() { "abruptly", "frizzled", "glyph", "icebox", "buffon", "bikini", "clown", "exodus", "vortex" };

            //Declaring a variable that takes a random word from the list
            int index = random.Next(list.Count);
            string mysteryWord = list[index];
            int guessCount = 1;
            int guessLimit = 10;
            int correctLettersGuessed = 0;
            char[] guess = mysteryWord.Select(c => '_').ToArray();

            //Prompting "______" instead of mystery word
            Console.WriteLine($"Mystery word: {string.Join("", mysteryWord.Select(c => "_"))}");

            while (correctLettersGuessed < mysteryWord.Length && guessCount <= guessLimit)
            {
                Console.WriteLine("Guess a letter: ");
                char playerGuess = char.Parse(Console.ReadLine());
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
                        guess[l] = playerGuess;
                        correctGuess = true;
                        correctLettersGuessed++;
                    }
                }
                //Prompting if he guessed a letter
                if (correctGuess)
                {
                    Console.WriteLine("Correct guess!");
                }
                //Prompting how many guesses are left after a wrong guess
                else
                {
                    int guessLeft = guessLimit - guessCount;
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
               //Prompting each letter guessed in the mystery word
               Console.WriteLine($"Mystery word: {string.Join("", guess.Select(c => Char.ToUpper(c)))}");
                
            }
            //Prompting when you guess the word
            Console.WriteLine("Congratulations, you guessed the word!");
        }
    }
}