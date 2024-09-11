using System;
using System.Linq;

class Program
{
    static void Main()
    {
       
        Console.Write("Ingresa una oración: ");
        string sentence = Console.ReadLine();
       
        Console.WriteLine("Largo de la oración: " + sentence.Length);

        Console.Write("Ingresa una letra: ");
        char letter = Console.ReadLine()[0];
        
        int letterCount = sentence.Count(c => c == letter);
        Console.WriteLine($"Cantidad de veces que se repite la letra '{letter}': {letterCount}");
      
        int vocalsCount = sentence.Count(c => "aeiouAEIOU".Contains(c));
        Console.WriteLine("Cantidad de vocales: " + vocalsCount);

        var wordsLength = string.Join(" - ", sentence.Split(' ').Select(p => p.Length));
        Console.WriteLine("Largo de cada palabra: " + wordsLength);
       
        string reverseSentence = new string(sentence.Reverse().ToArray());
        Console.WriteLine("Oración al revés: " + reverseSentence);
       
        string reverseWords = string.Join(" ", sentence.Split(' ').Select(p => new string(p.Reverse().ToArray())));
        Console.WriteLine("Palabras al revés: " + reverseWords);
      
        string noVocals = new string(sentence.Where(c => !"aeiouAEIOU".Contains(c)).ToArray());
        Console.WriteLine("Oración sin vocales: " + noVocals);

        Console.WriteLine("Oración en mayúsculas: " + sentence.ToUpper());

        Console.Write("Ingresa el desplazamiento para el cifrado César: ");
        int displacement = int.Parse(Console.ReadLine());
        string cesar = CesarCode(sentence, displacement);
        Console.WriteLine("Oración cifrada con César: " + cesar);

        string codeSustitution = Sustitution(sentence);
        Console.WriteLine("Oración cifrada con sustitución: " + codeSustitution);
    }

    static string CesarCode(string text, int displacement)
    {
        return new string(text.Select(c =>
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                return (char)((((c - offset) + displacement) % 26 + 26) % 26 + offset);
            }
            return c;
        }).ToArray());
    }

    static string Sustitution(string text)
    {
        string original = "abcdefghijklmnopqrstuvwxyz";
        string sustitution = "zyxwvutsrqponmlkjihgfedcba";
        var map = original.Zip(sustitution, (o, s) => new { o, s }).ToDictionary(x => x.o, x => x.s);

        return new string(text.Select(c => map.ContainsKey(c) ? map[c] : c).ToArray());
    }
}