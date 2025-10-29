using System;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Optional CLI version with user input
            // Console.WriteLine("Enter input: ");
            // string? input = Console.ReadLine();
            // String output = "";
            // if (input != null) output = OldPhonePadDecoder.OldPhonePad(input);
            // Console.WriteLine("output: " + output);
            Console.WriteLine("output: " + OldPhonePadDecoder.OldPhonePad("33#"));
            Console.WriteLine("output: " + OldPhonePadDecoder.OldPhonePad("227*#"));
            Console.WriteLine("output: " + OldPhonePadDecoder.OldPhonePad("4433555 555666#"));
            Console.WriteLine("output: " + OldPhonePadDecoder.OldPhonePad("3333 344366#"));
            Console.WriteLine("output: " + OldPhonePadDecoder.OldPhonePad("33333333#"));
        }
    }
}