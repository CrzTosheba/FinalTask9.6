using System;
using System.Collections;
using Task2.Exceptions;

public class ReverseComparer : IComparer
{
    // Вызов CaseInsensitiveComparer.Compare с обратными параметрами.
    public int Compare(Object x, Object y)
    {
        return (new CaseInsensitiveComparer()).Compare(y, x);
    }
}

public class Example
{

    public static void Main()
    {
      
        Console.WriteLine("Введите 5 фамилий");

        String[] words = new string[5];

       
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = TryGetValue(string.Format("Введите фамилию №{0}", i + 1));

        }
        
      


        // Создаем экземпляр обратного компаратора.
        IComparer revComparer = new ReverseComparer();

        // Отображаем значения массива
        Console.WriteLine("Вы ввели:");
        DisplayValues(words);


        while (true)
            try
            {
                string? str = UserMenu();
                   

                if (str == "1")
                {
                    // Сортируем весь массив, используя компаратор по умолчанию
                    Console.WriteLine("Сортировка по умолчанию:");
                    Array.Sort(words);

                }
                else if (str == "2")
                {
                    // Сортируем весь массив с помощью обратного компаратора
                    Console.WriteLine("Сортировка в обратном порядке:");
                    Array.Sort(words, revComparer);
                } else
                    throw new InputException("Что-то вы не то выбрали");

                DisplayValues(words);
            }
            catch (ExitException e) 
            {
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
       // Console.ReadLine();

    }

    private static string? UserMenu()
    {
        Console.WriteLine("Введите тип сортировки 1 или 2");
        Console.WriteLine("Для выхода введите '-q'");
        string? str = Console.ReadLine();
        if (str == "-q")
            throw new ExitException();
        return str;
    }

    public static void DisplayValues(String[] arr)
    {
        for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0);
              i++)
        {
            Console.WriteLine("   [{0}] : {1}", i, arr[i]);
        }
        Console.WriteLine();
    }
    static string TryGetValue(string message) 
    {
        while (true)
        {
            Console.WriteLine(message);
            var result = Console.ReadLine();

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Введено не корректное значение");
                continue;
            }

            return result;
        }
    }
}
