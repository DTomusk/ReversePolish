using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish
{
    class Program
    {
        

        static void Main(string[] args)
        {

            Stack<string> calcStack = new Stack<string>();

            Console.WriteLine("Enter expression");

            Node myNode = new Node(Console.ReadLine());
            myNode.isRoot = true; 
            Tree(myNode);

            traverse(myNode, calcStack);

            Console.WriteLine(calcStack.Pop());

            Console.ReadKey();
        }

        static void traverse(Node entryNode, Stack<string> myStack)
        {
            if(!entryNode.isLeaf )
            {
                traverse(entryNode.Left, myStack);
                traverse(entryNode.Right, myStack);

                int val1 = Int32.Parse(myStack.Pop());
                int val2 = Int32.Parse(myStack.Pop());

                int result = 0;

                if (entryNode.value == "+") { result = val1 + val2; }
                if (entryNode.value == "-") { result = val1 - val2; }
                if (entryNode.value == "*") { result = val1 * val2; }
                if (entryNode.value == "/") { result = val1 / val2; }

                myStack.Push(result.ToString());
            }
            else
            {
                myStack.Push(entryNode.value);
            }
            
        }

        static void Tree(Node parent)
        {

            Console.WriteLine("Tree Called, val: " + parent.value);

            string expression = parent.value;
            List<char> opList = new List<char>();
            List<int> placeList = new List<int>();
            int middleIndex;
            string leftExp;
            string rightExp;
            Node left;
            Node right;

            for (int i = 0; i < expression.Length; i++)
            {
                if (isOperator(expression[i]))
                {
                    opList.Add(expression[i]);
                    placeList.Add(i);
                }
            }

            if (opList.Count() == 0)    //if there were no operators in the expression then the node is a leaf
            {
                parent.isLeaf = true;
                return; 
            }

            middleIndex = (opList.Count() - 1) / 2;

            parent.value = opList[middleIndex].ToString();

            leftExp = expression.Substring(0, placeList[middleIndex]);
            rightExp = expression.Substring(placeList[middleIndex] + 1);

            left = new Node(leftExp);
            right = new Node(rightExp);

            parent.Left = left;
            parent.Right = right;
            left.Parent = parent;
            right.Parent = parent;

            Tree(left);
            Tree(right);

        }

        static bool isOperator(char testChar)
        {
            if ((testChar == '+') || (testChar == '-' ) || (testChar == '*') || (testChar == '/')) { return true; }
            return false;
        }
    }

    class Node
    {
        public bool isLeaf { get; set; }
        public bool isRoot { get; set; }
        public string value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }

        public Node(string exp)
        {
            value = exp;
        }
    }
}
