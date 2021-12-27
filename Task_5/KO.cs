using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Task_5
{
    class KO
    {
        StreamWriter SW;
        private List<string> set = new List<string>();
        private List<string> set_test = new List<string>();
        private List<string> list = new List<string>();
        private int n;

        public KO(StreamWriter SW)
        {
            set.Add("a"); set.Add("b"); set.Add("c"); set.Add("d"); set.Add("e"); set.Add("f");

            n = set.Count;
            this.SW = SW;
        }

        public bool NextSet(List<int> a, int n)
        {
            int j = n - 2;
            while (j != -1 && a[j] >= a[j + 1])
                j--;
            if (j == -1)
                return false; // больше перестановок нет
            int k = n - 1;
            while (a[j] >= a[k])
                k--;
            swap(a, j, k);
            int l = j + 1, r = n - 1; // сортируем оставшуюся часть последовательности
            while (l < r)
                swap(a, l++, r--);
            return true;
        }
        void swap(List<int> a, int i, int j)
        {
            int keeper = a[i];
            a[i] = a[j];
            a[j] = keeper;
        }

        public bool Next(List<int> poz, int k)
        {
            k -= 1;
            int m = poz.Count - 1;
            for (int i = m; i >= 0; i--)
                if (poz[i] < k - m + i)
                {
                    poz[i]++;
                    for (int j = i + 1; j <= m; j++)
                        poz[j] = poz[j - 1] + 1;
                    return true;
                }
            return false;
        }

        public void JustDoIt()
        {
            string word_on = "a";
            int length_on=0;

            for (int z = 0; z < 2; z++)
            {
                if (z == 0)
                    length_on = 4;
                else
                    length_on = 7;
                List<int> pos = new List<int>();
                List<string> list_on = new List<string>();
                List<int> list_helper = new List<int>(); list_helper.Add(1);
                pos.Add(0); pos.Add(1);

                do
                {
                    list_on.Clear();
                        // aa bbb
                    list_helper[0] = 1;//сим не а
                    do
                    {
                        for (int i = 0; i < length_on; i++)
                        {
                            list_on.Add(set[list_helper[0]]);//bbbbb
                        }
                        list_on[pos[0]] = word_on;
                        list_on[pos[1]] = word_on;
                        Print(length_on, list_on);
                        list_on.Clear();//_ _ _ _ _
                    } while (Next(list_helper, n));//выбор след символа
                
                    //aa b c d 
                    list_helper.Clear();
                    if (z == 0)
                    {
                        list_helper.Add(1); list_helper.Add(2);
                    }
                    else
                    { list_helper.Add(1); list_helper.Add(2); list_helper.Add(3); list_helper.Add(4); list_helper.Add(5); }

                    for (int i = 0; i < length_on; i++)
                    {
                        list_on.Add("");
                    }

                    do
                    {
                        List<int> index = new List<int>();
                        for (int i = 0; i < length_on; i++)
                        {
                            index.Add(i);
                        }
                        index.Remove(pos[0]); index.Remove(pos[1]);

                        do
	                    {
                            for (int i = 0; i < 2+3*z; i++)
                        {
                            list_on[index[i]] = set[list_helper[i]];
                        }

                        list_on[pos[0]] = word_on;
                        list_on[pos[1]] = word_on;
                        Print(length_on, list_on);
	                    } while (NextSet(index,2+3*z));
                        
                    } while (Next(list_helper, n));
                    list_helper.Clear(); list_helper.Add(1);
                   

                } while (Next(pos, length_on));//выбор поз для а а 

            }
        }

        private void Print(int length_on, List<string> list_on)
        {
            for (int i = 0; i < length_on; i++)
            {
                SW.Write(list_on[i] + " ");
            }
            SW.WriteLine();
        }
    }
}
