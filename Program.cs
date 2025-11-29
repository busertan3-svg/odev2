// AlgoritmaOdevleri_Odev2.cs
using System;
using System.Collections; // For ArrayList in Soru-1
using System.Collections.Generic; // For List<char> in Soru-3
using System.Linq; // For Array.Average in Soru-2 and List.Contains in Soru-3

public class AlgoritmaOdevleri_Odev2
{
    // --- Soru - 1: Asal ve Asal Olmayan Sayılar ---
    public static void Koleksiyonlar_Soru_1()
    {
        Console.WriteLine("\n--- Koleksiyonlar-Soru-1: Asal ve Asal Olmayan Sayilar ---");

        ArrayList primeNumbers = new ArrayList();
        ArrayList nonPrimeNumbers = new ArrayList();
        int inputCount = 20;

        Console.WriteLine("Please enter 20 positive numbers:");

        for (int i = 0; i < inputCount; i++)
        {
            int number;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write($"Enter number {i + 1}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    if (number > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            }

            if (IsPrime(number)) // Helper method for prime check
            {
                primeNumbers.Add(number);
            }
            else
            {
                nonPrimeNumbers.Add(number);
            }
        }

        // Sort both ArrayLists in descending order
        primeNumbers.Sort();
        primeNumbers.Reverse();
        nonPrimeNumbers.Sort();
        nonPrimeNumbers.Reverse();

        Console.WriteLine("\n--- Prime Numbers (Descending) ---");
        if (primeNumbers.Count == 0)
        {
            Console.WriteLine("No prime numbers entered.");
        }
        else
        {
            foreach (int num in primeNumbers)
            {
                Console.WriteLine(num);
            }
        }

        Console.WriteLine("\n--- Non-Prime Numbers (Descending) ---");
        if (nonPrimeNumbers.Count == 0)
        {
            Console.WriteLine("No non-prime numbers entered.");
        }
        else
        {
            foreach (int num in nonPrimeNumbers)
            {
                Console.WriteLine(num);
            }
        }

        // Calculate and print counts and averages
        Console.WriteLine("\n--- Statistics for Soru-1 ---");

        // Prime Numbers Statistics
        int primeCount = primeNumbers.Count;
        double primeSum = 0;
        foreach (int num in primeNumbers)
        {
            primeSum += num;
        }
        double primeAverage = (primeCount > 0) ? primeSum / primeCount : 0;

        Console.WriteLine($"Prime Numbers Count: {primeCount}");
        Console.WriteLine($"Prime Numbers Average: {primeAverage:F2}"); // Format to 2 decimal places

        // Non-Prime Numbers Statistics
        int nonPrimeCount = nonPrimeNumbers.Count;
        double nonPrimeSum = 0;
        foreach (int num in nonPrimeNumbers)
        {
            nonPrimeSum += num;
        }
        double nonPrimeAverage = (nonPrimeCount > 0) ? nonPrimeSum / nonPrimeCount : 0;

        Console.WriteLine($"Non-Prime Numbers Count: {nonPrimeCount}");
        Console.WriteLine($"Non-Prime Numbers Average: {nonPrimeAverage:F2}"); // Format to 2 decimal places

        Console.WriteLine("\nPress any key to continue to Soru-2...");
        Console.ReadKey();
    }

    // Helper function for Soru-1 to check if a number is prime
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    // --- Soru - 2: En Büyük 3 ve En Küçük 3 Sayı ---
    public static void Koleksiyonlar_Soru_2()
    {
        Console.WriteLine("\n--- Koleksiyonlar-Soru-2: En Buyuk 3 ve En Kucuk 3 Sayi ---");

        int[] numbers = new int[20];
        int inputCount = 20;

        Console.WriteLine("Please enter 20 numbers:");

        for (int i = 0; i < inputCount; i++)
        {
            int number;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write($"Enter number {i + 1}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            }
            numbers[i] = number;
        }

        // Sort the array to easily find smallest and largest numbers
        Array.Sort(numbers);

        Console.WriteLine("\n--- Smallest 3 Numbers ---");
        int[] smallestThree = new int[3];
        for (int i = 0; i < 3; i++)
        {
            smallestThree[i] = numbers[i];
            Console.WriteLine(smallestThree[i]);
        }

        Console.WriteLine("\n--- Largest 3 Numbers ---");
        int[] largestThree = new int[3];
        for (int i = 0; i < 3; i++)
        {
            largestThree[i] = numbers[inputCount - 3 + i];
            Console.WriteLine(largestThree[i]);
        }

        // Calculate averages
        double smallestThreeAverage = smallestThree.Average();
        double largestThreeAverage = largestThree.Average();
        double totalAverage = smallestThreeAverage + largestThreeAverage;

        Console.WriteLine("\n--- Averages for Soru-2 ---");
        Console.WriteLine($"Average of smallest 3 numbers: {smallestThreeAverage:F2}");
        Console.WriteLine($"Average of largest 3 numbers: {largestThreeAverage:F2}");
        Console.WriteLine($"Sum of both averages: {totalAverage:F2}");

        Console.WriteLine("\nPress any key to continue to Soru-3...");
        Console.ReadKey();
    }

    // --- Soru - 3: Cümledeki Sesli Harfler ---
    public static void Koleksiyonlar_Soru_3()
    {
        Console.WriteLine("\n--- Koleksiyonlar-Soru-3: Cumledeki Sesli Harfler ---");

        Console.WriteLine("Please enter a sentence:");
        string sentence = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(sentence))
        {
            Console.WriteLine("Invalid input. Please enter a non-empty sentence:");
            sentence = Console.ReadLine();
        }

        // Define vowels (both lowercase and uppercase for robust checking)
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        // Use a List to store found vowels, as the count is dynamic
        List<char> foundVowelsList = new List<char>();

        foreach (char c in sentence)
        {
            // Check if the character is a vowel
            if (vowels.Contains(c))
            {
                foundVowelsList.Add(c);
            }
        }

        // Convert List to Array (as requested by "bir dizi icerisinde saklayan")
        char[] foundVowelsArray = foundVowelsList.ToArray();

        // Sort the array of vowels
        Array.Sort(foundVowelsArray);

        Console.WriteLine("\n--- Found Vowels (Sorted) ---");
        if (foundVowelsArray.Length == 0)
        {
            Console.WriteLine("No vowels found in the sentence.");
        }
        else
        {
            foreach (char vowel in foundVowelsArray)
            {
                Console.WriteLine(vowel);
            }
        }

        Console.WriteLine("\nPress any key to finish the program...");
        Console.ReadKey();
    }

    // --- Main Method to run all solutions ---
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Starting Algoritma Odevleri - Odev 2 ---");

        Koleksiyonlar_Soru_1();
        Koleksiyonlar_Soru_2();
        Koleksiyonlar_Soru_3();

        Console.WriteLine("\n--- All Odev 2 tasks completed! ---");
    }
}