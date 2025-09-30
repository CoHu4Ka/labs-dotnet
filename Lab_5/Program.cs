using System;

struct Prices
{
    public int Drink;
    public int First;
    public int Second;
}

struct Order
{
    public int DrinkCount;
    public int FirstCount;
    public int SecondCount;
}

class Program
{
    static void Main()
    {
        // Цены (одни для всех клиентов)
        Prices prices = new Prices { Drink = 10, First = 20, Second = 30 };

        // Клиент 1 
        {
            Order order = new Order { DrinkCount = 2, FirstCount = 1, SecondCount = 0 };
            int total = CalculateOrder(prices, order);
            Console.WriteLine("Стоимость заказа клиента 1: " + total);
        }

        // Клиент 2 
        {
            Order order = new Order { DrinkCount = 1, FirstCount = 2, SecondCount = 1 };
            int total = CalculateOrder(prices, order);
            Console.WriteLine("Стоимость заказа клиента 2: " + total);
        }
    }

    static int CalculateOrder(Prices prices, Order order)
    {
        return order.DrinkCount * prices.Drink +
               order.FirstCount * prices.First +
               order.SecondCount * prices.Second;
    }
}


// Почему так делают (зачем?)

// Блоки { }: позволяют использовать одинаковые имена переменных для разных клиентов (у клиента1 есть order, у клиента2 тоже order, но они не мешают друг другу).

// struct/class для цен: если цены изменятся, нужно менять их только в одном месте.

// struct/class для заказа: чтобы хранить всё, что заказал клиент, в одной переменной.

// функция: чтобы не копировать один и тот же код вычисления суммы для каждого клиента.