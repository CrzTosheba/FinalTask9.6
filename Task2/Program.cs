using System;
using System.Collections;

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



        try
        {
            Console.WriteLine("Введите тип сортировки 1 или 2");
            string? str = Console.ReadLine();
            if (str != "1" && str != "2")
            {
                throw new Exception("Что-то вы не то выбрали");
            }
            else
            {
                if (str == "1")
                {
                    // Сортируем весь массив, используя компаратор по умолчанию
                    Array.Sort(words);
                    Console.WriteLine("Сортировка по умолчанию:");
                    DisplayValues(words);
                }
                else if (str == "2")

                {
                    // Сортируем весь массив с помощью обратного компаратора
                    Array.Sort(words, revComparer);
                    Console.WriteLine("Сортировка в обратном порядке:");
                    DisplayValues(words);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
        Console.ReadLine();

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
