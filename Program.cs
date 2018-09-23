using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter infix expression");

            string expression = Console.ReadLine();

        }

//implement a recursive method that divides the expression in half along an operator everytime

        static bool isOperator(char myChar)
        {
            if (myChar == '+' || myChar == '-' || myChar == '*' || myChar == '/')
            {
                return true;
            }
            return false;
        }

        static void splitExp(string expression, Node parent)
        {
            List<char> operators = new List<char>();
            List<int> place = new List<int>();
            string left;
            string right;
            Node thisNode; 

            for (int i = 0; i < expression.Length - 1; i++)
            {
                if (isOperator(expression[i]))
                {
                    operators.Add(expression[i]);
                    place.Add(i);
                }
            }

            if (operators.Count == 0)
            {
                thisNode = new Node(expression);
                thisNode.setLeaf();
                
                return;
            }


        }
    }

    class Node
    {
        private bool isLeaf;
        private bool isRoot;
        private Node left;
        private Node right;
        private Node parent;
        private string value;

        public Node(string val)
        {

            isLeaf = false;
            isRoot = false;
            value = val;

        }

        public void setRoot() { isRoot = true; }
        public void setLeaf() { isLeaf = true; }

    }
}

//Take a string and split it based on *+/-
//implement a tree 
//read the string, count how many operators there are then split by the middle one 
//the operator becomes the root, the left side is the left child and the right the right 
//continue until a pass returns no operators, set those to leaf 
//properties isleaf, isroot, left, right 