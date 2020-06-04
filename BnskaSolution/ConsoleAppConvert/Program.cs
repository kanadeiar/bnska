using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение вставка данных");

            Converter.Convert("Control5.csv", @"d:\Насос 5.xlsx");

            Console.WriteLine("Вставка завершена");
            Console.ReadKey();
        }
    }
}
