using System;
using System.Diagnostics;

class Program
{
    // Функция, реализующая логику алгоритма (поиск двух максимумов)
    static void FindTwoMaxFor(int[] input, int[] output)
    {
        // Контракты: проверка длин массивов
        if (input == null || output == null)
            throw new ArgumentNullException("Массивы не должны быть null");
        if (output.Length < 2)
            throw new ArgumentException("Выходной массив должен содержать как минимум 2 элемента");
        if (input.Length < 2)
            throw new ArgumentException("Входной массив должен содержать как минимум 2 элемента");

        int max1 = int.MinValue;
        int max2 = int.MinValue;

        // Поиск двух наибольших элементов с помощью цикла for
        for (int i = 0; i < input.Length; i++)
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
        }

        // Записываем результат в выходной массив
        output[0] = max1;
        output[1] = max2;
    }

    static void Main()
    {
        int[] numbers = { 4, 15, 7, 22, 9, 31, 3 };
        int[] result = new int[2];

        FindTwoMaxFor(numbers, result);

        Console.WriteLine("Максимальные элементы (for):");
        Console.WriteLine($"1: {result[0]}, 2: {result[1]}");
    }
}
