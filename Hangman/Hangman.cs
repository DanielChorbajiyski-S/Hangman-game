namespace Hangman
{
    internal class Hangman
    {
        
        
        const string Win = @"
        ┌───────────────────────────┐
        │                           │
        │ WW       WW  **  NN   N   │
        │ WW       WW  ii  NNN  N   │
        │  WW  WW WW   ii  N NN N   │
        │   WWWWWWW    ii  N  NNN   │
        │    WW  W     ii  N   NN   │
        │                           │
        │         Good job!         │
        │    You guessed the word!  │
        └───────────────────────────┘
        ";

        const string Loss = @"
        ┌────────────────────────────────────┐
        │ LLL          OOOO     SSSS    SSSS │
        │ LLL         OO  OO   SS  SS  SS  SS│
        │ LLL        OO    OO  SS      SS    │
        │ LLL        OO    OO   SSSS    SSSS │
        │ LLL        OO    OO      SS      SS│
        │ LLLLLLLLLL  OO  OO   SS  SS  SS  SS│
        │  LLLLLLLLL   OOOO     SSSS    SSSS │
        │                                    |
        │        You were so close.          │
        │ Next time you will guess the word! │
        └────────────────────────────────────┘
        ";

        static string[] wrongGuessFrames =
        {
         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"          ║   " + '\n' +
         @"          ║   " + '\n' +
         @"     ███  ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"          ║   " + '\n' +
         @"     ███  ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"     ███  ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      |\  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"     ███  ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"     ███  ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"       \  ║   " + '\n' +
         @"     ███  ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"     / \  ║   " + '\n' +
         @"     ███  ║   " + '\n' +
         @"    ══════╩═══"
        };

        static string[] deathAnimationFrames =
        {
         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"     / \  ║   " + '\n' +
         @"     ███  ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"     / \  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o>  ║   " + '\n' +
         @"     /|   ║   " + '\n' +
         @"      >\  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"     / \  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"     <o   ║   " + '\n' +
         @"      |\  ║   " + '\n' +
         @"     /<   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"     / \  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o>  ║   " + '\n' +
         @"     /|   ║   " + '\n' +
         @"      >\  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o>  ║   " + '\n' +
         @"     /|   ║   " + '\n' +
         @"      >\  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"     / \  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"     <o   ║   " + '\n' +
         @"      |\  ║   " + '\n' +
         @"     /<   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"     <o   ║   " + '\n' +
         @"      |\  ║   " + '\n' +
         @"     /<   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"     <o   ║   " + '\n' +
         @"      |\  ║   " + '\n' +
         @"     /<   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"     /|\  ║   " + '\n' +
         @"     / \  ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      o   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      |   ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      /   ║   " + '\n' +
         @"      \   ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    |__   ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      .   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    \__   ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @"   ____   ║   " + '\n' +
         @"    ══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @"      .   ║   " + '\n' +
         @"    __    ║   " + '\n' +
         @"   /══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      .   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"    _ '   ║   " + '\n' +
         @"  _/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @"      _   ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @"      .   ║   " + '\n' +
         @"          ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      .   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @"      _   ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @"      .   ║   " + '\n' +
         @"          ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"      .   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @"      _   ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      .   ║   " + '\n' +
         @"          ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      '   ║   " + '\n' +
         @" __/══════╩═══",

         @"      ╔═══╗   " + '\n' +
         @"      |   ║   " + '\n' +
         @"      O   ║   " + '\n' +
         @"          ║   " + '\n' +
         @"          ║   " + '\n' +
         @"      _   ║   " + '\n' +
         @" __/══════╩═══"
        };

        const char Underscore = '_';

        static void Main(string[] args)
        {
            Console.CursorVisible= false;
            string[] words = ReadWordsFromFile();
            while (true)
            {
                
                string word = GetRandomWord(words);
                string wordToGuess = new(Underscore, word.Length);
                int incorrectGuessCount = 0;
                List<char> playerUsedLetters = new List<char>();
                DrawCurrentGameState(false, incorrectGuessCount, wordToGuess, playerUsedLetters);
                Console.ReadLine();
            }
        }

        static string GetRandomWord(string[] words)
        {
            Random random= new Random();
            string word = words[random.Next(words.Length)];
            return word.ToLower();
        }

        static void DrawCurrentGameState(bool inputIsInvalid, int incorrectGuesses, string guessedWord, List<char> playerUsedLetters)
        {
            Console.Clear();
            Console.WriteLine(wrongGuessFrames[incorrectGuesses]);
            Console.WriteLine($"Guess: {guessedWord}");
            Console.WriteLine($"You have to guess {guessedWord.Length} symbols.");
            Console.WriteLine($"The following letters are used: {String.Join(", ", playerUsedLetters)}");

            if (inputIsInvalid )
            {
                Console.WriteLine("You should type only a single charecter!")
            }
            Console.WriteLine("Your symbol: ");
        }

        static void PlayGame(string word, string wordToGuess, int incorrectGuessCount, List<char> playerUsedLetters)
        {
            while (true)
            {
                string playerInput = Console.ReadLine().ToLower();
                if (playerInput.Length != 1)
                {
                    DrawCurrentGameState(true, incorrectGuessCount, wordToGuess, playerUsedLetters);
                    continue;
                }
                char playerLetter = char.Parse(playerInput);
                playerUsedLetters.Add(playerLetter);
            }
        }

        static bool CheckIfSymbolIsContained(string word, char playerLetter)
        {

        }

        static string AddLetterToGuessWord(string word, char playerLetter, string wordToGuess)
        {

        }

        static bool CheckIfPlayerWins(string wordToGuessChar)
        {

        }

        static bool CheckIfPlayerLoses(int incorrectGuessCount)
        {

        }

        static void DrawDeathAnimation(string[] deathAnimation)
        {

        }

        static string[] ReadWordsFromFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            const string WordsFileName = "words.txt";
            string path = $@"{projectDirectory}\{WordsFileName}";
            string[] words = File.ReadAllLines(path);
            return words;
        }
    }
}