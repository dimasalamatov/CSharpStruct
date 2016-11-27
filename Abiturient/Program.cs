using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Abiturient
{
    class Program
    {
        public struct Abiturient
        {
            public string Name;
            public string Gender;
            public string Spec;
            public int[] Exam;
            public void Print()
            {
               Console.Write(Name + " " + Gender + " " + Spec + " " + Exam[0] + " " + Exam[1] + " " + Exam[2] + " ");
               Console.WriteLine();
            }
            public void BadStudent(double p, int n)
            {
               
                if (SerBal(n) < p)
                {
                    Console.Write(Name + " " + Spec);
                    Console.WriteLine();
                }
            }
            public void ReadFromFile(int n)
            {
                string[] inf = File.ReadAllLines(@"list.txt");
                Exam = new int[3];
                for (int i = 0; i < inf.Length; i++)
                {
                    string[] a = inf[n].Split(' ');
                    Name = a[0] + " " + a[1];
                    Gender = a[2];
                    Spec = a[3] + " " + a[4];
                    Exam[0] = int.Parse(a[5]);
                    Exam[1] = int.Parse(a[6]);
                    Exam[2] = int.Parse(a[7]);
                }
            }
            public double SerBal(int n)
            {
                double ser_bal = 0;
                
                foreach (int x in Exam)
                {
                    ser_bal += x;
                }
                return ser_bal / 3;
            }
            public static Abiturient[] Sort(Abiturient[] a, double[] s, int n)
            {
                Array.Sort(s);
                Abiturient[] b = new Abiturient[n];
                int j = 0;
                int i = 0;
                for (; i < s.Length && j < n; i++)
                {
                    if (s[j] == Math.Round(a[i].SerBal(n),3))
                    {
                        b[j] = a[i];
                        j++;
                        i = -1;
                    }
                }
                return b;
            }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n = 10;
            Abiturient[] A = new Abiturient[n];
            for (int i = 0; i < n; i++)
            {
                A[i].ReadFromFile(i);
            }
            foreach (Abiturient a in A)
            {
                a.Print();
            }
            double[] ser_bals = new double[n];
            double[] ser_bals_copy = new double[n];
            
            for (int i = 0; i < n; i++)
            {
                ser_bals[i] = Math.Round(A[i].SerBal(n), 3);
                Console.WriteLine("-----------------------");
                Console.WriteLine("Середній бал абітурієнта {0} = {1}", A[i].Name, ser_bals[i]);
            }
            Array.Copy(ser_bals, ser_bals_copy, ser_bals.Length);
            Abiturient[] B = Abiturient.Sort(A, ser_bals_copy, n);
            Console.WriteLine("----------------------------------------------");
            foreach (Abiturient a in B)
            {
                a.Print();
            }
            Console.WriteLine("----------------------------------------------");
            Console.Write("Введіть прохідний бал - ");
            double p = double.Parse(Console.ReadLine());
            foreach (Abiturient a in A)
            {
                a.BadStudent(p,n);
            }
        }
    }
}
