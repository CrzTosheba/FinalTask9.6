public class Program
{
    static int Division(int a, int b)
    {
        return a / b;
    }
  

    static void Main(string[] args)
    {
        Exception exception = new Exception();
        
        try
        {
            int result = Division(7, 0);

            Console.WriteLine(result);
        }

        catch (System.DivideByZeroException)
        {
            Console.WriteLine("На ноль делить нельзя!");
        }
        try
        {
            int result = Division(7, 0);

            Console.WriteLine(result);
        }

        catch (Exception)
        {
            Console.WriteLine("Сработало мое исключение");
        }


        try
        {
            FutureFeature();
        }
        catch (NotImplementedException) //Это исключение выбрасывается, когда запрошенный метод или операция не реализованы.
        {
            Console.WriteLine("Метод не реализован");
        }
        try
        {

            string dir = @"c:\XYZ";// пытаемя обратиться к директории

            Directory.SetCurrentDirectory(dir);
        }
        catch (DirectoryNotFoundException dirEx) // путь не найден, ну или директория
        {
          Console.WriteLine("А ни чего и нету: " + dirEx.Message);
        }
        int value = 780000000;
        checked
        {
            try
            {
               
                int square = value * value;
                Console.WriteLine("{0} ^ 2 = {1}", value, square);
            }
            catch (OverflowException) // выход за диапозон значений, в данном случае выход за int тоесть 2 147 483 647, при умножении должно быть 608 400 000 000 000 000, но мы не сможем вывести это число.
            {
                double square = Math.Pow(value, 2);
                Console.WriteLine("Exception: {0} > {1:E}.",
                                  square, Int32.MaxValue);
            }
        }

    }
    static void FutureFeature()
    {
       
        throw new NotImplementedException();
    }



    
    
}