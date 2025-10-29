using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    public static class OldPhonePadDecoder
    {
        /// <summary>
        /// Decodes a sequence of key presses from an old phone pad into the matching text.
        /// </summary>
        /// <param name="input">A string of keypresses, ending with '#'.</param>
        /// <returns>The decoded string, in uppercase.</returns>
        public static String OldPhonePad(string input)
        {
            Dictionary<string, char> phonePad = new()
            {
                {"2", 'a'}, {"22", 'b'}, {"222", 'c'},
                {"3", 'd'}, {"33", 'e'}, {"333", 'f'},
                {"4", 'g'}, {"44", 'h'}, {"444", 'i'},
                {"5", 'j'}, {"55", 'k'}, {"555", 'l'},
                {"6", 'm'}, {"66", 'n'}, {"666", 'o'},
                {"7", 'p'}, {"77", 'q'}, {"777", 'r'}, {"7777", 's'},
                {"8", 't'}, {"88", 'u'}, {"888", 'v'},
                {"9", 'w'}, {"99", 'x'}, {"999", 'y'}, {"9999", 'z'},
            };

            String result = "";

            // Split the array with space separator to 
            string[] parsedInputArr = input.TrimEnd('#').Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> splitKeySets = [];

            foreach (string chunk in parsedInputArr)
            {
                // Initialize current value
                string currentKeySet = "";

                foreach (char c in chunk)
                {
                    if (currentKeySet.Contains(c))
                    {
                        currentKeySet += c.ToString();
                        continue;
                    }
                    // Handle delete action
                    else if (c == '*')
                    {
                        currentKeySet = "";
                        continue;
                    }
                    // Prevent adding to list on first iteration
                    if (currentKeySet != "") splitKeySets.Add(currentKeySet);
                    currentKeySet = c.ToString();
                }
                // Catch the case where the last input is deleted
                // Ensure the last input gets added to the list
                if (currentKeySet != "") splitKeySets.Add(currentKeySet);
            }

            foreach (string keySet in splitKeySets)
            {
                // Handle key sequence inputs that doesn't match the original mapping
                if (phonePad.TryGetValue(keySet, out char mappedChar))
                {
                    result += mappedChar;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Error.WriteLine($"Warning: '{keySet}' not found in phonePad dictionary. Skipping.");
                    Console.ResetColor();
                }
            }

            return result.ToUpper();
        }
    }
}