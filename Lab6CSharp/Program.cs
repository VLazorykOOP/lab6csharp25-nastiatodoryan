using System;
using System.Collections.Generic;

// === Завдання 1 ===
interface IUser
{
    void Show();
}

interface IProduct  
{
    string Name { get; set; }
    double Price { get; set; }
}

class Toy : IUser, IProduct
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Manufacturer { get; set; }

    public void Show()
    {
        Console.WriteLine($"Іграшка: {Name}, Ціна: {Price}, Виробник: {Manufacturer}");
    }
}

class Product : IUser, IProduct
{
    public string Name { get; set; }
    public double Price { get; set; }

    public void Show()
    {
        Console.WriteLine($"Продукт: {Name}, Ціна: {Price}");
    }
}

class Goods : IUser
{
    public string Type { get; set; }

    public void Show()
    {
        Console.WriteLine($"Товар типу: {Type}");
    }
}

class DairyProduct : IUser
{
    public string Name { get; set; }
    public double FatContent { get; set; }

    public void Show()
    {
        Console.WriteLine($"Молочний продукт: {Name}, Жирність: {FatContent}%");
    }
}

// === Завдання 2 ===
interface IFigure
{
    double Area();
    double Perimeter();
    void Show();
}

class Rectangle : IFigure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
    public void Show()
    {
        Console.WriteLine($"Прямокутник: Ширина={Width}, Висота={Height}, Площа={Area()}, Периметр={Perimeter()}");
    }
}

class Circle : IFigure
{
    public double Radius { get; set; }

    public double Area() => Math.PI * Radius * Radius;
    public double Perimeter() => 2 * Math.PI * Radius;
    public void Show()
    {
        Console.WriteLine($"Коло: Радіус={Radius}, Площа={Area():F2}, Периметр={Perimeter():F2}");
    }
}

class Triangle : IFigure
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public double Perimeter() => A + B + C;
    public double Area()
    {
        double s = Perimeter() / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    public void Show()
    {
        Console.WriteLine($"Трикутник: Сторони={A}, {B}, {C}, Площа={Area():F2}, Периметр={Perimeter():F2}");
    }
}

// === Завдання 3 ===
class MyCustomException : Exception
{
    public MyCustomException(string message) : base(message) { }
}

class ErrorExample
{
    public static void Run()
    {
        Console.WriteLine("-> Обробка стандартного винятку:");
        try
        {
            string[] strings = new string[1];
            object[] objects = strings; // дозволено — масив рядків у масив об'єктів
            objects[0] = 42;            // ❌ ArrayTypeMismatchException — 42 не є рядком
        }
        catch (ArrayTypeMismatchException ex)
        {
            Console.WriteLine("Отримано ArrayTypeMismatchException:");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n-> Власний виняток:");
        try
        {
            throw new MyCustomException("Це мій власний виняток.");
        }
        catch (MyCustomException ex)
        {
            Console.WriteLine("Оброблено: " + ex.Message);
        }
    }
}

// === Головне меню ===
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nОберіть завдання:");
            Console.WriteLine("1 - Завдання 1 (Ієрархія з інтерфейсами)");
            Console.WriteLine("2 - Завдання 2 (Фігури з інтерфейсом Figure)");
            Console.WriteLine("3 - Завдання 3 (Обробка винятків)");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    RunTask1();
                    break;
                case "2":
                    RunTask2();
                    break;
                case "3":
                    ErrorExample.Run();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    static void RunTask1()
    {
        List<IUser> list = new List<IUser>
        {
            new Toy { Name = "Машинка", Price = 150, Manufacturer = "Lego" },
            new Product { Name = "Шоколад", Price = 35 },
            new Goods { Type = "Електроніка" },
            new DairyProduct { Name = "Молоко", FatContent = 3.2 }
        };

        foreach (var item in list)
            item.Show();
    }

    static void RunTask2()
    {
        IFigure[] figures = new IFigure[]
        {
            new Rectangle { Width = 5, Height = 10 },
            new Circle { Radius = 7 },
            new Triangle { A = 3, B = 4, C = 5 }
        };

        foreach (var f in figures)
            f.Show();
    }
}
