using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // This stores scripture references and texts in a list
        List<(string reference, string text)> scriptures = new List<(string, string)>
        {
            ("Proverbs 3:5-6", "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            ("John 3:16", "For God so loved the world, that he gave his only begotten Son that whosoever believeth will not perish but shall have everlasting life"),
            ("Mosiah 2:17", "When ye are in the service of your fellow beings ye are only in the service of your God."),
            ("Matthew 11:28-30", "Come unto me, all ye that labour and are heavy laden, and I will give you rest.Take my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls.For my yoke is easy, and my burden is light.")
        };

        Random rand = new Random();
        bool keepMemorizing = true;

        while (keepMemorizing)
        {
            var chosen = scriptures[rand.Next(scriptures.Count)];
            string referenceText = chosen.reference;
            string scriptureText = chosen.text;

            int lastSpace = referenceText.LastIndexOf(' ');
            string book = referenceText.Substring(0, lastSpace);
            string chapterVersePart = referenceText.Substring(lastSpace + 1);

            string[] chapterVerse = chapterVersePart.Split(':');
            int chapter = int.Parse(chapterVerse[0]);
            string versePart = chapterVerse[1].Trim();

            Reference reference;
            if (versePart.Contains("-"))
            {
                string[] verses = versePart.Split('-');
                reference = new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
            }
            else
            {
                reference = new Reference(book, chapter, int.Parse(versePart));
            }

            Scripture scripture = new Scripture(reference, scriptureText);
            bool firstRound = true;

            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(reference.GetDisplayText());
                Console.WriteLine();

                if (firstRound)
                {
                    Console.WriteLine(scriptureText);
                    firstRound = false;
                }
                else
                {
                    Console.WriteLine(scripture.GetDisplayText());
                }

                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    keepMemorizing = false;
                    break;
                }
                else
                {
                    /*To exceed assignment requirements I made this code to ask user how many words
                    they would like to hide each time to allow users manage their phase in hidin words
                    while they memorize */
                    int remaining = scripture.VisibleWordCount();
                    if (remaining == 0) break;
                    // This manage user input for number of words to hide
                    int wordsToHide = 0;
                    bool validInput = false;

                    while (!validInput)
                    {
                        Console.Write($"How many words would you like to hide? (1 to {remaining}): ");
                        string inputCount = Console.ReadLine();

                        if (int.TryParse(inputCount, out wordsToHide) && wordsToHide >= 1 && wordsToHide <= remaining)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid number. Please enter a value between 1 and " + remaining + ".");
                        }
                    }

                    scripture.HideRandomWords(wordsToHide, rand);

                    if (scripture.IsCompletelyHidden())
                    {
                        Console.Clear();
                        keepMemorizing = false;
                        break;
                    }
                }
            }

            if (!keepMemorizing)
            {
                Console.Clear();
                Console.WriteLine("Well Done Thou Good and Faithful Servant. Keep learning & memorizing!");
            }
        }
    }
}
