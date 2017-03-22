using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    class Program
    {
DGFgdfdfdfdffghfghfg
DGFgrerererere
            dfgd
            fgdffddfdfdf
            fgdf
            gdfdfdfdf
            gddfdffddf
            fdfdfdfdffd
            dfdfdfdfdfddfdfdfdff

        static List<Stack> indexesCurrentStep = new List<Stack>();
        static List<Stack> indexesNextStep = new List<Stack>();
        static LabWork labWork = new LabWork();
        static Avalibe[,] avalibe;
        private static List<Node> currentNodes;
        static void Main(string[] args)
        {
            
            /////////////////////////////////////
            int xEnter = 0; //coordinates of enter in labyrinth
            int yEnter = 1;

            int xExit = 9; //coordinates of exit from labyrinth
            int yExit = 0;

            Node enterNode =  new Node(){X = xEnter, Y = yEnter};

            avalibe = labWork.ReadFileAv("lab1.txt");

            indexesCurrentStep.Add(new Stack() { X = xEnter, Y = yEnter });

            currentNodes = new List<Node>(); // Nodes in a current step
            List<Node> NodesNextStep = new List<Node>();
            


            currentNodes.Add(enterNode); //initialize
            int i = 0;
            while (true)
            {
                ///////////////////////////////////
                GoStep(indexesCurrentStep[i].X + 1, indexesCurrentStep[i].Y, i); // Go Right

                GoStep(indexesCurrentStep[i].X - 1, indexesCurrentStep[i].Y, i); // Go Left

                GoStep(indexesCurrentStep[i].X, indexesCurrentStep[i].Y + 1, i); // Go Bot

                GoStep(indexesCurrentStep[i].X, indexesCurrentStep[i].Y - 1, i); // Go Top
               
                  NodesNextStep.AddRange(currentNodes[i].Nodes);
                
                i++;

                //if current step find exit of labyrinth, find way by previous nodes
                if (NodesNextStep.Any(x => x.X == xExit && x.Y == yExit))  
                {
                    var nodeFind = NodesNextStep.FirstOrDefault(x => x.X == xExit && x.Y == yExit);
                 
                    while (nodeFind.Prev != null)
                    {
                        Console.WriteLine("( {0}, {1} )", nodeFind.X, nodeFind.Y);
                        nodeFind = nodeFind.Prev;
                    }
                    break;  
                }
               
                //if nodes in current step is end go next step
                if (i == currentNodes.Count)
                {
                    currentNodes = NodesNextStep;
                    indexesCurrentStep = indexesNextStep;
                    NodesNextStep = new List<Node>();
                    indexesNextStep  = new List<Stack>();
                    i = 0;
                }
            }

            Console.ReadLine();

        }

        public static void GoStep(int xStep, int yStep, int i)
        {
            if (xStep < labWork.XCount && 
                yStep < labWork.YCount &&
                xStep >= 0 &&
                yStep >= 0 &&
                avalibe[xStep, yStep].Avlb)
            {
                currentNodes[i].Nodes.Add(new Node()
                {
                    X = xStep,
                    Y = yStep,
                    Prev = currentNodes[i]
                });
                //in every node we can go only 1 time, so true = we can go, 
                //false this node is marked as we already go there before
                avalibe[xStep, yStep].Avlb = false;


                indexesNextStep.Add(new Stack() { X = xStep, Y = yStep });

            }
        }

    }
}
