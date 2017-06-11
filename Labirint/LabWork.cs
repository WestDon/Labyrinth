using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    public class LabWork
    { 
        public int XCount { get; set; }
        public int YCount { get; set; }
        public int[,] ReadFile()
        {
            //read file////
            //new2222/
            StreamReader stRead = new StreamReader("lab.txt");
            int[,] lab = new int[11, 5];
            int index = 0;
            while (stRead.Peek() != -1)
            {
                int j = 0;
                string str = stRead.ReadLine();
                List<Char> lst = str.ToCharArray().ToList();
                foreach (var ch in lst)
                {
                    lab[j, index] = int.Parse(ch.ToString());
                    j++;
                }
                XCount = j;
                index++;
            }
            YCount = index;
            stRead.Close();
            return lab;
        }
        public Avalibe[,] ReadFileAv(string filePath)
        {
            //read file
            StreamReader stRead = new StreamReader(filePath);

            Avalibe[,] lab;
            List<string> strLabyrinth = new List<string>();
            int index = 0;
            int maxWidth = 0;
            int maxHeight = 0;
            while (stRead.Peek() != -1)
            {
                string row = stRead.ReadLine();
                strLabyrinth.Add(row);
                maxWidth = maxWidth < row.Count() ? row.Count() : maxWidth;
            }
            maxHeight = strLabyrinth.Count;
            lab = new Avalibe[maxWidth, maxHeight];
            foreach (var rowLab in strLabyrinth)
            {
                int j = 0;
                List<Char> lst = rowLab.ToCharArray().ToList();
                foreach (var ch in lst)
                {
                    lab[j, index] = new Avalibe();
                    lab[j, index].Avlb =  int.Parse(ch.ToString())== 1;
                    j++;
                }
                XCount = j;
                index++;
            }
            YCount = index;
            stRead.Close();
            return lab;
        }
        
    }
    public class Node
    {
        public Node()
        {
            Nodes = new List<Node>();
        }
        public Node Prev { get; set; }
        public List<Node> Nodes { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

    }
    public class Stack
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Avalibe
    {
        public Avalibe()
        {
            Avlb = false;
        }
        public bool Avlb { get; set; }
    }

}
