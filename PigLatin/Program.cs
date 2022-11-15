using System;
namespace PigLatin {
    /*
A program that translates a text to Pig Latin and back. 
English is translated to Pig Latin by taking the first letter of every word, 
moving it to the end of the word and adding ‘ay’. 
“The quick brown fox” becomes “Hetay uickqay rownbay oxfay
*/
    public class PigLatinSolution
    {
        public static void Run()
        {
            Console.WriteLine("===== PIG LATIN TRANSLATOR =====");
            Console.Write("Enter a sentence to translate: ");
            string sentence = Console.ReadLine()!;
            Console.WriteLine();
            string translated = ToPigLatin(sentence!); // It'll have value during runtime
            Console.WriteLine("Translated Sentence: " + translated);
            Console.WriteLine("Translated PigLatin back: " + FromPigLatin(translated!));
        }

        private static string ToPigLatin(string sentence) // class that converts the entered sentence to piglatin
        {
            // Checking if the input sentence is null or empty
            if (string.IsNullOrEmpty(sentence))
            {
                return sentence;
            }
            string[] words = sentence.ToLower().Split(' '); // converting the string to string array
            List<string> translatedWords = new List<string>();
            // Looping through the string array to get each word
            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word))
                {
                    translatedWords.Add(word);
                }
                else
                {
                    string res = "";
                    if (word.Length < 2)
                    {
                        res = word + "ay";
                    }
                    else
                    {
                        res = word.Substring(1); // Assigning the characters of a word to res excluding the first 
                        res += word[0] + "ay";  // Adding the first character at end of the word and adding "ay" string
                        translatedWords.Add(res);
                    }

                }
            }
            string result = string.Join(" ", translatedWords); // Converting the string array to string
            result = result.Substring(0, 1).ToUpper() + result.Substring(1); // Making the first letters of each words capital letter
            return result;
        }

        private static string FromPigLatin(string sentence) //class that converts the translated piglatin to English
        {
            if (string.IsNullOrEmpty(sentence))
            {
                return sentence;
            }
            string[] words = sentence.ToLower().Split(' ');
            List<string> translatedWords = new List<string>();
            foreach (string word in words)
            {
                // Checking whether the entered string arrays are piglatin 
                if (string.IsNullOrEmpty(word) || word.Length < 2 || !word.EndsWith("ay"))
                {
                    translatedWords.Add(word);
                }
                else
                {
                    // Removing the "ay" characters of the piglatin
                    string res = word.Substring(0, word.Length - 2);
                    //Checking if the character is more than one and then make last letter first letter
                    if (res.Length > 1)
                    {
                        res = res[res.Length - 1] + res.Substring(0, res.Length - 1);
                    }
                    translatedWords.Add(res);
                }
            }
            string result = string.Join(" ", translatedWords);
            result = result.Substring(0, 1).ToUpper() + result.Substring(1);
            return result;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            PigLatinSolution.Run();
        }
    }
}

