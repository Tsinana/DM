using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Task_2
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

        public bool Next(List<int> poz,int k)
        {
            k -= 1;
            int m = poz.Count-1;
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
            int length_on = 5;
            List<int> pos = new List<int>();
            List<string> list_on = new List<string>();
            List<int> list_helper = new List<int>();list_helper.Add(1);
            pos.Add(0); pos.Add(1);

            do
            {
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

                //aa bb c
                list_helper[0] = 1;
                do
                {
                    int last = list_helper[0];//держит второй сим
                    list_helper[0] = 1;
                    do
                    {

                        if (list_helper[0] == last && last != n - 1)
                            Next(list_helper, n);

                        if (list_helper[0] == last && last == n - 1)
                            break;

                        int keeper_sim = list_helper[0];//держит третий сим
                        list_helper[0] = 0;
                        do
                        {

                            if (list_helper[0] == pos[0] && pos[0] != length_on - 2)
                                Next(list_helper, n);
                            if (list_helper[0] == pos[1] && pos[1] != length_on - 1)
                                Next(list_helper, n);
                            if ((list_helper[0] == pos[0] && pos[0] == length_on - 2) || (list_helper[0] == pos[1] && pos[1] == length_on - 1))
                                break;

                            for (int i = 0; i < length_on; i++)//bbbbb
                            {
                                list_on.Add(set[last]);
                            }
                            list_on[list_helper[0]] = set[keeper_sim];//bbbb c
                            list_on[pos[0]] = word_on;//a bbb c
                            list_on[pos[1]] = word_on;//aa bb c
                            Print(length_on, list_on);
                            list_on.Clear();//_ _ _ _ _


                        } while (Next(list_helper, length_on));//выбор позиции для третьего сим

                        list_helper[0] = keeper_sim;

                    } while (Next(list_helper, n));//выбор след третьего сим

                    list_helper[0] = last;

                } while (Next(list_helper, n));//выбор след второго сим

                //aa b c d 
                list_helper.Clear(); list_helper.Add(1); list_helper.Add(2); list_helper.Add(3);
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

                    list_on[index[0]] = set[list_helper[0]];
                    list_on[index[1]] = set[list_helper[1]];
                    list_on[index[2]] = set[list_helper[2]];
                    list_on[pos[0]] = word_on;
                    list_on[pos[1]] = word_on;
                    Print(length_on, list_on);

                } while (Next(list_helper, n));
                list_helper.Clear(); list_helper.Add(1);


            } while (Next(pos, length_on));//выбор поз для а а 

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
