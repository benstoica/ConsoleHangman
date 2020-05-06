using System;

namespace Spaceman
{
    class Game
    {
        public string CodeWord
        { get; private set; }

        public string CurrentWord
        { get; private set; }

        public int MaxGuesses
        { get; }

        public int WrongGuesses
        { get; private set; }

        private string[] wordBank = new string[] {
            "peace",
            "galaxy",
            "universe",
            "earth",
            "venus",
            "pluto",
            "moon",
        };

        private Ufo spaceship = new Ufo();

        public Game()
        {
            Random r = new Random();
            CodeWord = wordBank[r.Next(wordBank.Length)];
            MaxGuesses = 5;
            WrongGuesses = 0;
            for (int i = 0; i < CodeWord.Length; i++) 
            {
                CurrentWord += "_";
            }
        }

        public void Greet()
        {
            Console.WriteLine("============= UFO: The Game============");
            Console.WriteLine("Instructions: save your friend from alien abduction by guessing the letters in the codeword.");
            Console.WriteLine("You have 5 guesses.");
        }

        public void Display() 
        {
            Console.WriteLine(spaceship.Stringify());
            Console.WriteLine($"Current word: {CurrentWord}\n");
            Console.WriteLine($"Incorrect guesses:{WrongGuesses}\n");
        }

        public void Ask() {
            Console.WriteLine("Guess a letter:");
            string userGuess = Console.ReadLine();
            if (userGuess.Length != 1) 
            {
                Console.WriteLine("One letter at a time!");
                return;
            }

            char guess = userGuess.ToCharArray()[0];
            char[] guessArray = userGuess.ToCharArray();

            if (CodeWord.Contains(guess))
            {
                Console.WriteLine($"{guess} is in the word");
                for (int i = 0; i < CodeWord.Length; i++)
                {
                    if (guess == CodeWord[i])
                    {
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guess.ToString());
                    }
                }
            }

            else 
            {
                Console.WriteLine($"{guess} is not in the word. The beam pulls you up further...");
                WrongGuesses++;
                spaceship.AddPart();
            }

            for (int i = 0; i < guessArray.Length; i++)
            {
                Console.WriteLine($"Letters you have guessed so far:{guessArray[i]}");
            }
        }




    public bool DidWin() {
            if (CodeWord.Equals(CurrentWord))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool DidLose() {
            if (WrongGuesses >= MaxGuesses)
            {
                return true;
            }
            else {
                return false;
            }
        }

    }
}