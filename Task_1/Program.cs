using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace DM_task_1
{
    class KO
    {
        StreamWriter SW;
        private List<string> set = new List<string>();
        private int n;

        public KO(StreamWriter SW)
        {
            Console.WriteLine("Начат процесс задания множества.");
            Console.WriteLine("Введите все элементы множества в одну строку через пробел.");
            string st = Console.ReadLine();
            Regex myReg = new Regex(@"[\w]+");
            MatchCollection matches = myReg.Matches(st);
            foreach (Match j in matches)
            {
                set.Add(Convert.ToString(j.Value));
            }
            Console.Write("Множество задано. Результат: A = {");
            foreach (string j in set)
            {
                Console.Write("\t" + j);
            }
            Console.Write("\t}\n");
            n = set.Count;
            this.SW = SW;
        }

        public void Generating_all_combinations_with_repetitions(int k)
        {
            List<string> list_st = new List<string>();
            int index = 0;
            Generating_all_combinations_with_repetitions(0, 0, list_st, n, k, ref index);
        }

        private void Generating_all_combinations_with_repetitions(int num, int last, List<string> list_st, int n, int k, ref int index)
        {
            if (num == k)
            {
                SW.Write(index++ + ". ");
                for (int i = 0; i < k; i++)
                {
                    SW.Write(list_st[i] + " ");
                }
                SW.WriteLine();
            }
            else
            {
                for (int i = last; i < n; i++)
                {
                    list_st.Add(set[i]);
                    Generating_all_combinations_with_repetitions(num + 1, i, list_st, n, k, ref index);
                    list_st.Remove(set[i]); ;
                }
            }
        }

        public void Generating_all_subsets()
        {
            List<string> list_st = new List<string>();
            int index = 0;
            for (int i = 0; i <= n; i++)
                Generating_all_combinations_of_k_elements(0, -1, list_st, n, i, ref index);
        }

        public void Generating_all_combinations_of_k_elements(int k)
        {
            List<string> list_st = new List<string>();
            int index = 0;
            Generating_all_combinations_of_k_elements(0, -1, list_st, n, k, ref index);
        }

        private void Generating_all_combinations_of_k_elements(int num, int last, List<string> list_st, int n, int m, ref int index)
        {
            if (num == m)
            {
                SW.Write(index++ + ". ");
                for (int i = 0; i < m; i++)
                {
                    SW.Write(list_st[i] + " ");
                }
                SW.WriteLine();
            }
            else
            {
                for (int i = last + 1; i < n; i++)
                {
                    list_st.Add(set[i]);
                    Generating_all_combinations_of_k_elements(num + 1, i, list_st, n, m, ref index);
                    list_st.Remove(set[i]); ;
                }
            }
        }

        public void Generating_all_permutations()
        {
            int index = 0;
            Generating_all_permutations(0, set, ref index);
        }

        private void Generating_all_permutations(int t, List<string> list_st, ref int index)
        {
            if (t == n - 1)
            {
                SW.Write(index++ + ". ");
                for (int i = 0; i < n; i++)
                {
                    SW.Write(list_st[i] + " ");
                }
                SW.WriteLine();
            }
            else
            {
                for (int i = t; i < n; i++)
                {
                    Swap(t, list_st, i);
                    t++;
                    Generating_all_permutations(t, list_st, ref index);
                    t--;
                    Swap(t, list_st, i);
                }
            }
        }

        private void Swap(int t, List<string> list_st, int i)
        {
            string keeper = list_st[t];
            list_st[t] = list_st[i];
            list_st[i] = keeper;
        }

        public void Generation_all_placements_by_k_elements(int k)
        {
            List<string> list_st = new List<string>();
            int[] used = new int[n];
            int index = 0;
            Generation_all_placements_by_k_elements(0, used, list_st, n, k, ref index);
        }

        private void Generation_all_placements_by_k_elements(int num, int[] used, List<string> list_st, int n, int k, ref int index)
        {
            if (num == k)
            {
                SW.Write(index++ + ". ");
                for (int i = 0; i < k; i++)
                {
                    SW.Write(list_st[i] + " ");
                }
                SW.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (used[i] != 1)
                    {
                        used[i] = 1; list_st.Add(set[i]);
                        Generation_all_placements_by_k_elements(num + 1, used, list_st, n, k, ref index);
                        used[i] = 0; list_st.Remove(set[i]);
                    }
                }
            }
        }

        public void Generation_all_placements_with_repetitions_of_k_elements(int k)
        {
            List<string> list_st = new List<string>();
            int[] used = new int[n];
            int index = 0;
            Generation_all_placements_with_repetitions_of_k_elements(0, list_st, n, k, -1, ref index);
        }

        public void Generation_all_placements_with_repetitions_of_k_elements(int num, List<string> list_st, int n, int k, int t, ref int index)
        {
            t++;
            if (num == k)
            {
                SW.Write(index++ + ". ");
                for (int i = 0; i < k; i++)
                {
                    SW.Write(list_st[i] + " ");
                }
                SW.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (num != k)
                    {
                        list_st.Add(set[i]);
                        Generation_all_placements_with_repetitions_of_k_elements(num + 1, list_st, n, k, t, ref index);
                        list_st.Remove(set[i]);
                    }
                }
            }
        }
    }
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
            Console.Clear();

            KO ko = new KO(SW);
            Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
            Console.Clear();
            int check = 1;
            do
            {
                Console.Clear();
                int k;
                Console.WriteLine("1. Построить все размещения с повторениями по k элементов.\n2. Построить все перестановки.\n3. Построить все размещения по k элементов.\n4. Построить все подмножества.\n5. Построить все сочетания по k элементов.\n6. Построить все сочетания с повторениями.\n0. Выход.");
                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите значиние k:");
                        try
                        {
                            k = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            k = 1;
                        }
                        SW.WriteLine("\nВсе размещения с повторениями по k элементов.\n");
                        ko.Generation_all_placements_with_repetitions_of_k_elements(k);
                        break;
                    case 2:
                        SW.WriteLine("\nBсе перестановки.\n");
                        ko.Generating_all_permutations();
                        break;
                    case 3:
                        Console.WriteLine("Введите значиние k:");
                        try
                        {
                            k = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            k = 1;
                        }
                        SW.WriteLine("\nВсе размещения по k элементов.\n");
                        ko.Generation_all_placements_by_k_elements(k);
                        break;
                    case 4:
                        SW.WriteLine("\nBсе подмножества.\n");
                        ko.Generating_all_subsets();
                        break;
                    case 5:
                        Console.WriteLine("Введите значиние k:");
                        try
                        {
                            k = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            k = 1;
                        }
                        SW.WriteLine("\nBсе сочетания по k элементов.\n");
                        ko.Generating_all_combinations_of_k_elements(k);
                        break;
                    case 6:
                        Console.WriteLine("Введите значиние k:");
                        try
                        {
                            k = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            k = 1;
                        }
                        SW.WriteLine("\nBсе сочетания с повторениями по k элементов.\n");
                        ko.Generating_all_combinations_with_repetitions(k);
                        break;
                    case 0:
                        check = 0;
                        break;
                }
            } while (check == 1);
            SW.Close();
        }
    }
}
//Национальный исследовательский университет «Высшая школа экономики». Факультет 
//компьютерных наук.Летняя школа по компьютерным наукам. Август. 2016. 
//Параллель С. Шуйкова И.А.
