using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;

namespace Npuzzle
{
    class ProgramConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Manhattan only");
            bool succeed = ReadAndCheck("Solvable Cases/8 Puzzle (1).txt", 0);
            //bool succeed = ReadAndCheck("Unsolvable Cases/9999 Puzzle - Unsolvable Case 3.txt", 0);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        static bool ReadAndCheck(string fileName,int choice)
        {
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            string line = sr.ReadLine();
            int n = int.Parse(line);
            int[,] array = new int[n, n];
            line = sr.ReadLine();
            int indexofy = -1;
            int indexofx = -1;
            for (int i = 0; i < n; i++)
            {
                line = sr.ReadLine();
                string[] parts = line.Split(' ');
                if (indexofx==-1)
                {
                    indexofy = Array.IndexOf(parts, "0");
                    if (indexofy != -1)
                    {
                        indexofx = i;
                    }
                }
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = int.Parse(parts[j]);
                }
            }
            if (choice == 0 || choice == 2)
            {
                sr.Close();
                file.Close();
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                int resManhattan = Solve.solveNpuzzle(array, n, indexofx, indexofy, "Manhattan");
                watch.Stop();
                Console.WriteLine("res Manhattan: " + resManhattan);
                Console.WriteLine("Time Taken: " + watch.Elapsed.TotalSeconds);
            }
            if (choice == 1 || choice == 2)
            {
                var watch2 = new System.Diagnostics.Stopwatch();
                watch2.Start();
                int resHamming = Solve.solveNpuzzle(array, n, indexofx, indexofy, "Hamming");
                watch2.Stop();
                Console.WriteLine("res Hamming: " + resHamming);
                Console.WriteLine("Time Taken: " + watch2.Elapsed.TotalSeconds);
            }

            return true;
        }
    }
}
