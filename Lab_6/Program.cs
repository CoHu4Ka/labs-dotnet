// Алгоритм 
// Завести список result такой же длины.
// Для каждого индекса i:
// взять элемент из первого списка a[i];
// взять элемент из второго списка b[i];
// сложить их и записать в result[i].
// Вывести result.


int[] list1 = { 1, 2, 3 };
int[] list2 = { 4, 5, 6 };

int[] result = new int[list1.Length];

for (int i = 0; i < list1.Length; i++)
{
    result[i] = list1[i] + list2[i];
}

Console.WriteLine("Результат:");
for (int i = 0; i < result.Length; i++)
{
    Console.Write(result[i] + " ");
}

