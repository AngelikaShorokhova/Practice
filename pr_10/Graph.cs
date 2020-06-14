using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace pr_10
{
    public class Graph
    {
        private int[,] vertices;
        private int[,] matrix;

        public int[,] Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }
        public int[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        public Graph()
        {
            Vertices = null;
            Matrix = null;
        }
        public Graph(int[,] v, int[,] m)
        {
            Vertices = v;
            Matrix = m;
        }
        public Graph(int count)
        {
            Vertices = MakeVertices(count);
            Matrix = MakeMatrix(count);
        }

        [ExcludeFromCodeCoverage]
        public void ShowGraph()
        {
            if (Vertices.GetLength(0) == 0)
                Console.WriteLine("");
            else 
            {
                for (int i = 0; i < Vertices.GetLength(0); i++)
                {
                    Console.Write("Вершина №" + Vertices[i, 0] + ", значение:" + Vertices[i, 1] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Матрица смежности:");
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                        Console.Write(String.Format("{0,3}", Matrix[i, j]));
                    Console.WriteLine();
                }
            }            
        }
        public int[,] MakeVertices(int n)
        {
            Random random = new Random();
            int[,] mas = new int[n, 2];
            for (int j = 0; j < mas.GetLength(0); j++)
                mas[j, 0] = j + 1;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                mas[i, 1] = random.Next(0,11);
            }
            return mas;
        }
        public int[,] MakeMatrix(int n)
        {
            Random random = new Random();
            int[,] mas = new int[n + 1, n + 1];
            for (int i = 0; i < mas.GetLength(0); i++)
                mas[i, 0] = i;
            for (int j = 0; j < mas.GetLength(1); j++)
                mas[0, j] = j;
            for (int i = 1; i < mas.GetLength(0); i++)
            {
                for (int j = 1; j < mas.GetLength(1); j++)
                    mas[i, j] = mas[j, i] = random.Next(0, 2);
            }

            return mas;
        }
        public int[] Delete(int data)
        {
            List<int> deleteItems = new List<int>();
            for (int i = 0; i < Vertices.GetLength(0); i++)
            {
                if (Vertices[i, 1] == data)
                    deleteItems.Add(i);
            }
            DeleteInMatrix(deleteItems.ToArray());
            return deleteItems.ToArray();
        }
        public void DeleteInMatrix(int[] number)
        {
            int l = 1;
            for (int k = 0; k < number.Length; k++)
            {
                DeleteMas(ref matrix, number[k] + l);
                l--;
            }
            Matrix = matrix;
            l = 1;
            int[,] masDop = new int[Matrix.GetLength(1), Matrix.GetLength(0)];
            for (int i = 0; i < masDop.GetLength(0); i++)
            {
                for (int j = 0; j < masDop.GetLength(1); j++)
                {
                    masDop[i, j] = Matrix[j, i];
                }
            }
            Matrix = new int[masDop.GetLength(0), masDop.GetLength(1)];
            Array.Copy(masDop, Matrix, Matrix.GetLength(0) * Matrix.GetLength(1));
            for (int k = 0; k < number.Length; k++)
            {
                DeleteMas(ref matrix, number[k] + l);
                l--;
            }
            Matrix = matrix;
            masDop = new int[Matrix.GetLength(1), Matrix.GetLength(0)];
            for (int i = 0; i < masDop.GetLength(0); i++)
            {
                for (int j = 0; j < masDop.GetLength(1); j++)
                {
                    masDop[i, j] = Matrix[j, i];
                }
            }
            Matrix = new int[masDop.GetLength(0), masDop.GetLength(1)];
            Array.Copy(masDop, Matrix, Matrix.GetLength(0) * Matrix.GetLength(1));
            l = 0;
            for (int k = 0; k < number.Length; k++)
            {
                DeleteMas(ref vertices, number[k] + l);
                l--;
            }
            Vertices = vertices;
        }
        public static void DeleteMas(ref int[,] mas, int number)
        {
            int[,] masDop = new int[mas.GetLength(0) - 1, mas.GetLength(1)];
            Array.Copy(mas, masDop, number * mas.GetLength(1));
            Array.Copy(mas, (number + 1) * mas.GetLength(1), masDop, number * mas.GetLength(1), mas.GetLength(1) * (masDop.GetLength(0) - number));
            mas = new int[mas.GetLength(0) - 1, mas.GetLength(1)];
            Array.Copy(masDop, mas, masDop.GetLength(0) * masDop.GetLength(1));
        }
        public override bool Equals(object obj)
        {
            Graph graph = (Graph)obj;
            if(this.Vertices.GetLength(0)!= graph.Vertices.GetLength(0)|| this.Vertices.GetLength(1) != graph.Vertices.GetLength(1)||
                this.Matrix.GetLength(0) != graph.Matrix.GetLength(0)|| this.Matrix.GetLength(1) != graph.Matrix.GetLength(1))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        if (this.Matrix[i, j] != graph.Matrix[i, j])
                        {
                            return false;
                        }
                    }
                }
                for (int i = 0; i < Vertices.GetLength(0); i++)
                {
                    for (int j = 0; j < Vertices.GetLength(1); j++)
                    {
                        if (this.Matrix[i, j] != graph.Matrix[i, j])
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }
    }
}
