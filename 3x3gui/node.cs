using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Npuzzle
{
    public class node:IComparable
    {
        public List<node> children = new List<node>();
        public node par;
        public int[,] arr;
        public int xzero;
        public int yzero;
        public int level;
        public int size;
        public int cost;

        public node(int[,] array, int x_zero, int y_zero, node parent, int n, int l)
        {
            arr = array;
            xzero = x_zero;
            yzero = y_zero;
            par = parent;
            size = n;
            level = l;
            cost = 0;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            node x = obj as node;
            if (x != null)
            {
                return x.cost.CompareTo(this.cost);
            }
            else
                throw new ArgumentException("Error in object");
            
        }

    }
}
       
