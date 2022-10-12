using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_lab_2_3._2_
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        /// <summary>
        /// Корень бинарного дерева
        /// </summary>
        public BinaryTreeNode<T> RootNode { get; set; }
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }

        /*public BinaryTree(List<BinaryTreeNode<T>> list, BinaryTreeNode<T> currentNode = null)
        {
            RootNode = list.First();
            foreach (var item in list)
            {
                Add(item);  
            }
        }*/

        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }
        public void Remove(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            //если у узла нет подузлов, можно его удалить
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            //если нет левого, то правый ставим на место удаляемого 
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            //если нет правого, то левый ставим на место удаляемого 
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            //если оба дочерних присутствуют, 
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = data.CompareTo(startWithNode.Data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }
        public void Remove(T data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }
        public void PrintTree()
        {
            PrintTree(RootNode);
        }
        public string LCR()
        {

            string s = "";
            if (RootNode != null)
            {
                BinaryTreeNode<T> CurNL = RootNode.LeftNode;
                int i = 0;
                s = s + "Left side of tree:" + "\n";
                while (CurNL != null)
                {
                    i++;
                    s = s + "\t" + $" Node {i}, value = {CurNL.Data}" + "\n";
                    CurNL = CurNL.LeftNode;

                }

                s = s + "Root of tree:" + "\n";
                s = s + $"Root 0, value = {RootNode.Data}" + "\n";

                BinaryTreeNode<T> CurNR = RootNode.RightNode;
                int d = 0;
                s = s + "Right side of tree:" + "\n";
                while (CurNR != null)
                {
                    d++;
                    s = s + "\t" + $" Node {d}, value = {CurNR.Data}" + "\n";
                    CurNR = CurNR.RightNode;

                }
                return s;
            }
            else return s += "    значение отсутствует - null";
        }


        public void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }

        public List<BinaryTreeNode<T>> GetNodes(BinaryTreeNode<T>? CurN = null)
        {
            if (CurN == null)
            {
                CurN = RootNode;
                List<BinaryTreeNode<T>> _list = new List<BinaryTreeNode<T>>();
                while (CurN.HaveNext())
                {
                    _list.Add(CurN);
                    GetNodes(CurN.LeftNode);
                    GetNodes(CurN.RightNode);
                }
                return _list;
            }
            else
            {
                List<BinaryTreeNode<T>> _list = new List<BinaryTreeNode<T>>();
                while (CurN.HaveNext())
                {
                    _list.Add(CurN);
                    GetNodes(CurN.LeftNode);
                    GetNodes(CurN.RightNode);
                }
                return _list;

            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            //var ep = RootNode;
            if (RootNode != null) {

                if (RootNode.LeftNode != null) //Відвідування лівого піддерева
                {
                    
                    foreach (T item in RootNode.LeftNode)
                    {
                        yield return item;
                        
                    }

                    if (RootNode != null)
                    {
                        yield return RootNode.Data; //Відвідування корінного вузла
                    }
                    if (RootNode.RightNode != null) //Відвідування правого піддерева
                    {
                        foreach (T item in RootNode.RightNode)
                        {
                            yield return item;
                            
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Treee doesn't exist");
                }


            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
    }
