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
        bool Next(){
            for (int i = m; i >= 1; i--)
                if (a[i] < n - m + i) {
                    a[i]++;
                    for (int j = i + 1; j <= n; j++)
                        a[j] = a[j - 1] + 1;
                    return 1;
                }
            return 0;
        }       
        public void Generating_all_combinations_of_k_elements(int k)
        {
            List<string> list_st = new List<string>();
            int index = 0;
            Generating_all_combinations_of_k_elements(0, -1, list_st,list, n, k, ref index);
        }

        private void Generating_all_combinations_of_k_elements(int num, int last, List<string> list_st,List<string> list_st1, int n, int m, ref int index)
        {
            if (num == m)
            {
                for (int i = 0; i < 3; i++)
			    {
                    switch (i)
	                {
                        case 0:
                            for (int k = 1; k < n; k++)
                            {
                                for (int j = 0; j < 5; j++)
			                    {
                                    list_st1.Add(set[k]);
			                    }
                                list_st1[Convert.ToInt32(list_st[0])]="a";
                                list_st1[Convert.ToInt32(list_st[1])]="a";
                                SW.Write(index++ + ". ");
                                for (int l = 0; l < 5; l++)
                                {
                                    SW.Write(list_st1[l] + " ");
                                }
                                list_st1.Clear();
                                SW.WriteLine();
                            }
                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                	}
			    }
            }
            else
            {
                for (int i = last + 1; i < 5; i++)
                {
                    list_st.Add(i+"");
                    Generating_all_combinations_of_k_elements(num + 1, i, list_st,list, n, m, ref index);
                    list_st.Remove(i+""); ;
                }
            }
        }
    }
}
