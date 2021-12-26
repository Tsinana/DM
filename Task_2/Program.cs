using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Далее в программе весь результат мы будем сохранять в файл. Укажите путь для сохранения файла.\nВ какой каталог сохраним файл:");
            string st1 = Console.ReadLine();
            Console.WriteLine("Как будет назван файл:");
            string st2 = Console.ReadLine();
            string way = st1 + ":/" + st2 + ".txt";
            StreamWriter SW = SW = new StreamWriter(@way);
            Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
            Console.Clear();;
            KO ko = new KO(SW);
            ko.Generating_all_combinations_of_k_elements(5);








            SW.Close();
        }
    }
}
