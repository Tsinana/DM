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
        private int n;

        public KO(StreamWriter SW)
        {
            set.Add("a"); set.Add("b"); set.Add("c"); set.Add("d"); set.Add("e"); set.Add("f");
            set.Add("a"); set.Add("a"); set.Add(" "); set.Add(" "); set.Add(" "); set.Add(" ");
            n = set.Count;
            this.SW = SW;
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
                    list_st.Add(set_test[i]);
                    Generating_all_combinations_of_k_elements(num + 1, i, list_st, n, m, ref index);
                    list_st.Remove(set_test[i]); ;
                }
            }
        }
    }
}
