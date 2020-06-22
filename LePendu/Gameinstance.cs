using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LePendu
{
    public class Gameinstance
    {
        private int maxErrors { get; set; }
        public List<char> Guesses { get; }
        public List<char> Misses { get; }
        public List<Word> Words { get; }

        public Word WordToGuess { get; }

        private Random rnd;
        private bool isWin { get; set; }
        private string currentWordGuessed;

        public Gameinstance(int maxErrors = 10)
        {
            rnd = new Random();
            this.maxErrors = maxErrors;

            Words = new List<Word>
            {
                new Word("Programmation"),
                new Word("Soleil"),
                new Word("Immeuble"),
                new Word("Canapé"),
                new Word("Jedi"),
                new Word("Raquette")
            };

            Guesses = new List<char>();
            Misses = new List<char>();

            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine($"Le mot à deviner contient {WordToGuess.Lenght} lettres.");

            currentWordGuessed = PrintWordToGuess();
        }

        public Gameinstance(List<Word> words, int maxErrors = 10)
        {
            rnd = new Random();
            this.maxErrors = maxErrors;

            Words = words;

            Guesses = new List<char>();
            Misses = new List<char>();

            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine($"Le mot à deviner contient {WordToGuess.Lenght} lettres.");

            currentWordGuessed = PrintWordToGuess();
        }

        public void Play()
        {
            while(!isWin)
            {
                Console.WriteLine("Donnez moi une lettre :");
                char letter = char.ToUpper(Console.ReadKey(true).KeyChar);
                int letterIndex = WordToGuess.GetIndexOf(letter);

                Console.WriteLine();


                if (letterIndex != -1)
                {

                    Console.WriteLine($"Bravo, vous avez trouvé la lettre : {letter}");
                    Guesses.Add(letter);
                }
                else
                {
                    Console.WriteLine($"La lettre {letter} ne se trouve pas dans le mot à deviner !");
                    Misses.Add(letter);
                }
                if (Misses.Count > 0)
                {
                    Console.WriteLine($"Erreurs ({Misses.Count}) : {string.Join(", ", Misses)}");
                }

                currentWordGuessed = PrintWordToGuess();

                if(currentWordGuessed.IndexOf('_') == -1)
                {
                    isWin = true;
                    Console.WriteLine("Félicitations, c'est gagné !");
                    Console.ReadKey();
                }

                if(Misses.Count >= maxErrors)
                {
                    Console.WriteLine("C'est perdu !");
                    Console.ReadKey();
                    break;
                }
            }
        }

        private string PrintWordToGuess()
        {
            string currentWordGuessed = "";

            for (int i = 0; i < WordToGuess.Lenght; i++)
            {
                if (Guesses.Contains(WordToGuess.Text[i]))
                {
                    currentWordGuessed += WordToGuess.Text[i];
                }
                else
                {
                    currentWordGuessed += "_";
                }
            }

            Console.WriteLine(currentWordGuessed);
            Console.WriteLine();

            return currentWordGuessed;
        }
    }
}
