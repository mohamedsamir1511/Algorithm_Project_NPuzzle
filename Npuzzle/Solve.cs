using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Npuzzle
{
    public static class Solve
    {
        public static bool foundsol = false;
        public static int sol = 0;
       
        public static int getChildren(PriorityQueue<node> pq,string testMethod,HashSet<string> matrices)
        {
            foundsol = false;
            sol = 0;
            while (pq.Count != 0)
            {
                if (foundsol == true)
                {
                    return sol;
                }
                node origin = pq.top();
                pq.pop();
                node y = null;
                node y1 = null;
                node y2 = null;
                node y3 = null;
                if (origin.xzero - 1 >= 0)
                {
                    int[,] temparr = origin.arr.Clone() as int[,];
                    y = new node(temparr, origin.xzero, origin.yzero, origin, origin.size, origin.level + 1);
                    y.arr[origin.xzero, origin.yzero] = y.arr[origin.xzero - 1, origin.yzero];
                    y.arr[origin.xzero - 1, origin.yzero] = 0;
                    y.xzero = origin.xzero - 1;
                    y.yzero = origin.yzero;
                    if (!(origin.par != null && y.xzero == origin.par.xzero && y.yzero == origin.par.yzero))
                    {
                        origin.children.Add(y);
                    }
                }

                if (origin.xzero + 1 < origin.size)
                {
                    int[,] temparr = origin.arr.Clone() as int[,];
                    y1 = new node(temparr, origin.xzero, origin.yzero, origin, origin.size, origin.level + 1);
                    y1.arr[origin.xzero, origin.yzero] = origin.arr[origin.xzero + 1, origin.yzero];
                    y1.arr[origin.xzero + 1, origin.yzero] = 0;
                    y1.xzero = origin.xzero + 1;
                    y1.yzero = origin.yzero;
                    if (!(origin.par != null && y1.xzero == origin.par.xzero && y1.yzero == origin.par.yzero))
                    {
                        origin.children.Add(y1);
                    }
                }
                if (origin.yzero - 1 >= 0)
                {
                    int[,] temparr = origin.arr.Clone() as int[,];
                    y2 = new node(temparr, origin.xzero, origin.yzero, origin, origin.size, origin.level + 1);
                    y2.arr[origin.xzero, origin.yzero] = y2.arr[origin.xzero, origin.yzero - 1];
                    y2.arr[origin.xzero, origin.yzero - 1] = 0;
                    y2.xzero = origin.xzero;
                    y2.yzero = origin.yzero - 1;
                    if (!(origin.par != null && y2.xzero == origin.par.xzero && y2.yzero == origin.par.yzero))
                    {
                        origin.children.Add(y2);
                    }

                }
                if (origin.yzero + 1 < origin.size)
                {
                    int[,] temparr = origin.arr.Clone() as int[,];
                    y3 = new node(temparr, origin.xzero, origin.yzero, origin, origin.size, origin.level + 1);
                    y3.arr[origin.xzero, origin.yzero] = origin.arr[origin.xzero, origin.yzero + 1];
                    y3.arr[origin.xzero, origin.yzero + 1] = 0;
                    y3.xzero = origin.xzero;
                    y3.yzero = origin.yzero + 1;
                    if (!(origin.par != null && y3.xzero == origin.par.xzero && y3.yzero == origin.par.yzero))
                    {
                        origin.children.Add(y3);
                    }
                }
             
                for (int i = 0; i < origin.children.Count; i++)
                {
                    string z = convertMatrixToString(origin.children[i]);
                    if (!matrices.Contains(z))
                     {
                    if (testMethod == "Hamming")
                        {
                            origin.children[i].cost = calculateHamming(origin.children[i]);
                        }
                        else if (testMethod == "Manhattan")
                        {
                            origin.children[i].cost = calculateManhatten(origin.children[i]);
                        }
                    
                        
                        pq.push(origin.children[i]);
                        matrices.Add(z);
                    }
                }
                
            }
            return 0;
        }

        
        
        public static bool isSolvable(int[,] array,int n,int zero_x,int zero_y)
        {
            int inversions = 0;
            int[] onedarray = new int[n * n];
            int k=0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    onedarray[k]=array[i,j];
                    k++;
                }
            }
            for (int i = 0; i < onedarray.Length; i++)
            {
                if (onedarray[i] == 0)
                {
                    continue;
                }
                for (int j = i + 1; j < onedarray.Length; j++)
                {
                    if (onedarray[j] == 0)
                    {
                        continue;
                    }
                    else if (onedarray[j] < onedarray[i])
                    {
                        inversions++;
                    }
                }
            }
            if (n % 2 == 0)
            {
                if ((n - zero_x) % 2 == 0 && inversions % 2 == 1)
                {
                    return true;
                }
                else if ((n - zero_x) % 2 == 1 && inversions % 2 == 0)
                {
                    return true;
                }
                return false;
            }

            else
            {
                if (inversions % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            
            
        }
        
        public static int solveNpuzzle(int[,] array, int n, int zero_x, int zero_y, string testMethod)
        {
            if (isSolvable(array, n, zero_x, zero_y))
            {
                HashSet<string> matrices = new HashSet<string>();
                node origin = new node(array, zero_x, zero_y, null, n, 0);
                matrices.Add(convertMatrixToString(origin));
                PriorityQueue<node> pq = new PriorityQueue<node>();
                pq.push(origin);
                node x = pq.top();
                if (testMethod == "Hamming")
                {
                    origin.cost = calculateHamming(origin);
                }
                else if (testMethod == "Manhattan")
                {
                    origin.cost = calculateManhatten(origin);
                }
                return getChildren(pq, testMethod, matrices);
            }
            else
            {
                Console.WriteLine("Unsolvable");
                return 0;
            }
        }

        public static string convertMatrixToString(node x)
        {
            string f="";
            for(int i = 0; i < x.size; i++)
            {
                for(int j = 0; j < x.size; j++)
                {
                    f += x.arr[i, j]+" ";
                }
            }
            return f;
        }
        public static void printmatrix(node x)
        {
            if (x.size == 3)
            {
                for (int j = 0; j < x.size; j++)
                {
                    Console.WriteLine(x.arr[j, 0] + " " + x.arr[j, 1] + " " + x.arr[j, 2]);
                }
            }


        }

        public static int calculateManhatten(node x)
        {
            int manhatten = 0;
            for(int i = 0; i < x.size; i++)
            {
                for(int j = 0; j < x.size; j++)
                {
                    if (x.arr[i, j] != ((i * x.size + j)+1))
                    {
                        if ((x.arr[i, j] % x.size - 1) != -1)
                        {
                            manhatten += Math.Abs(x.arr[i, j] / x.size - i) + Math.Abs((x.arr[i, j] % x.size - 1) - j);
                        }
                        else if (x.arr[i, j] == 0)
                        {
                            continue;
                        }
                        else if((x.arr[i, j] % x.size - 1) == -1)
                        {
                            manhatten += Math.Abs(x.arr[i, j] / x.size - 1 - i) + Math.Abs((x.size - 1 - j));
                        }    
                    }           
                }
            }
            //Console.WriteLine("Manhattan: " + manhatten);
            if (manhatten == 0)
            {
                Console.WriteLine("Stop");
                Console.WriteLine(x.level);
                foundsol = true;
                sol = x.level;
                node f = x.par;
                if (x.size == 3)
                {
                    List<node> flist = new List<node>();
                    Console.WriteLine("Steps");
                    flist.Add(x);
                    while (f != null)
                    {

                        flist.Add(f);
                        f = f.par;
                    }
                    flist.Reverse();
                    int counter = 1;
                    foreach (node z in flist)
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(counter);
                        counter++;
                        printmatrix(z);
                    }
                }
                
            }
            return manhatten+x.level;
        }

        public static int calculateHamming(node x)
        {
            int hamming = 0;
            for (int i = 0; i < x.size; i++)
            {
                for (int j = 0; j < x.size; j++)
                {
                    if (i == x.size - 1 && j == x.size - 1 && x.arr[i,j]!=0)
                    {
                        hamming++;
                        continue;
                    }
                    else if (x.arr[i, j] != (i * x.size + j + 1))
                    {
                        hamming++;
                    }
                    
                }
            }
            if (hamming == 1)
            {
                foundsol = true;
                sol = x.level;
                Console.WriteLine("Stop");
                Console.WriteLine(x.level);
                printmatrix(x);
            }

            return hamming+x.level;
        }
    }



    
}

