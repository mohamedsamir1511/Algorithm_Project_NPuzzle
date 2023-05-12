using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Npuzzle
{
    
    public partial class Form1 : Form
    {
        public static node firstnode;
        public static List<node> nodess;
        public int counter=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = firstnode.level.ToString();
            button1.Text = firstnode.arr[0, 0].ToString();
            button2.Text = firstnode.arr[0, 1].ToString();
            button3.Text = firstnode.arr[0, 2].ToString();
            button4.Text = firstnode.arr[1, 0].ToString();
            button5.Text = firstnode.arr[1, 1].ToString();
            button6.Text = firstnode.arr[1, 2].ToString();
            button7.Text = firstnode.arr[2, 0].ToString();
            button8.Text = firstnode.arr[2, 1].ToString();
            button9.Text = firstnode.arr[2, 2].ToString();
            if (button1.Text == "0")
            {
                button1.Text = "";
            }
            else if (button2.Text == "0")
            {
                button2.Text = "";
            }
            else if (button3.Text == "0")
            {
                button3.Text = "";
            }
            else if (button4.Text == "0")
            {
                button4.Text = "";
            }
            else if (button5.Text == "0")
            {
                button5.Text = "";
            }
            else if (button6.Text == "0")
            {
                button6.Text = "";
            }
            else if (button7.Text == "0")
            {
                button7.Text = "";
            }
            else if (button8.Text == "0")
            {
                button8.Text = "";
            }
            else if (button9.Text == "0")
            {
                button9.Text = "";
            }

        }
        public node getfirstNode(node x)
        {
            firstnode = x;
            return firstnode;
        }
        public node getSteps(node x)
        {
            if (x.par != null)
            {
                return x.par;
            }
            else
            {
                MessageBox.Show("Can't Proceed anymore");
            }

            return null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (counter < nodess.Count)
            {
                button1.Text = nodess.ElementAt(counter).arr[0, 0].ToString();
                button2.Text = nodess.ElementAt(counter).arr[0, 1].ToString();
                button3.Text = nodess.ElementAt(counter).arr[0, 2].ToString();
                button4.Text = nodess.ElementAt(counter).arr[1, 0].ToString();
                button5.Text = nodess.ElementAt(counter).arr[1, 1].ToString();
                button6.Text = nodess.ElementAt(counter).arr[1, 2].ToString();
                button7.Text = nodess.ElementAt(counter).arr[2, 0].ToString();
                button8.Text = nodess.ElementAt(counter).arr[2, 1].ToString();
                button9.Text = nodess.ElementAt(counter).arr[2, 2].ToString();
                if (button1.Text == "0")
                {
                    button1.Text = "";
                }
                else if (button2.Text == "0")
                {
                    button2.Text = "";
                }
                else if (button3.Text == "0")
                {
                    button3.Text = "";
                }
                else if (button4.Text == "0")
                {
                    button4.Text = "";
                }
                else if (button5.Text == "0")
                {
                    button5.Text = "";
                }
                else if (button6.Text == "0")
                {
                    button6.Text = "";
                }
                else if (button7.Text == "0")
                {
                    button7.Text = "";
                }
                else if (button8.Text == "0")
                {
                    button8.Text = "";
                }
                else if (button9.Text == "0")
                {
                    button9.Text = "";
                }
                counter++;
            }
            else
            {
                MessageBox.Show("Cant Proceed anymore");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (counter >0)
            {
                counter--;
                button1.Text = nodess.ElementAt(counter).arr[0, 0].ToString();
                button2.Text = nodess.ElementAt(counter).arr[0, 1].ToString();
                button3.Text = nodess.ElementAt(counter).arr[0, 2].ToString();
                button4.Text = nodess.ElementAt(counter).arr[1, 0].ToString();
                button5.Text = nodess.ElementAt(counter).arr[1, 1].ToString();
                button6.Text = nodess.ElementAt(counter).arr[1, 2].ToString();
                button7.Text = nodess.ElementAt(counter).arr[2, 0].ToString();
                button8.Text = nodess.ElementAt(counter).arr[2, 1].ToString();
                button9.Text = nodess.ElementAt(counter).arr[2, 2].ToString();
                if (button1.Text == "0")
                {
                    button1.Text = "";
                }
                else if (button2.Text == "0")
                {
                    button2.Text = "";
                }
                else if (button3.Text == "0")
                {
                    button3.Text = "";
                }
                else if (button4.Text == "0")
                {
                    button4.Text = "";
                }
                else if (button5.Text == "0")
                {
                    button5.Text = "";
                }
                else if (button6.Text == "0")
                {
                    button6.Text = "";
                }
                else if (button7.Text == "0")
                {
                    button7.Text = "";
                }
                else if (button8.Text == "0")
                {
                    button8.Text = "";
                }
                else if (button9.Text == "0")
                {
                    button9.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Cant Proceed anymore");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
