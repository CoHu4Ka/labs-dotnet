// 1. Пример с int (тип-значение)
void Example1()
{
    int a = 5;
    int b = 6;
    a = b;
    b = 7;
    Console.WriteLine(a);    
}

// 2. Пример с вычислением
void Example2()
{
    int a = 5;
    int b = a + 6;
    a = 7;
    Console.WriteLine(b);
}

// 3. Пример со string (ссылочный тип)
void Example3()
{
    string a = "a";
    string b = a;
    a = "b";
    Console.WriteLine(a);
}
// 4. Ошибка с string
void Example4()
{
    string a = 5;
}

