using System;
using System.Diagnostics;

class Program
{
    static void FindTwoMaxWhile(int[] input, int[] output)
    {
        if (input == null || output == null)
            throw new ArgumentNullException("Массивы не должны быть null");
        if (output.Length < 2)
            throw new ArgumentException("Выходной массив должен содержать как минимум 2 элемента");
        if (input.Length < 2)
            throw new ArgumentException("Входной массив должен содержать как минимум 2 элемента");

        int max1 = int.MinValue;
        int max2 = int.MinValue;
        int i = 0;

        // Поиск через цикл while
        while (i < input.Length)
        {
            if (input[i] > max1)
            {
                max2 = max1;
                max1 = input[i];
            }
            else if (input[i] > max2)
            {
                max2 = input[i];
            }
            i++;
        }

        output[0] = max1;
        output[1] = max2;
    }

    static void Main()
    {
        int[] numbers = { 4, 15, 7, 22, 9, 31, 3 };
        int[] result = new int[2];

        FindTwoMaxWhile(numbers, result);

        Console.WriteLine("Максимальные элементы (while):");
        Console.WriteLine($"1: {result[0]}, 2: {result[1]}");
    }
}
