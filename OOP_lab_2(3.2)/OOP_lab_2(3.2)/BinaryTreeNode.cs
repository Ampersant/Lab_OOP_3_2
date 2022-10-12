using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_2_3._2_
{

    public enum Side
    {
        Left,
        Right
    }

    public class BinaryTreeNode<T> : IEnumerable where T : IComparable  
    {
       
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public BinaryTreeNode<T> LeftNode { get; set; }

        public BinaryTreeNode<T> RightNode { get; set; }

        public BinaryTreeNode<T> ParentNode { get; set; }
        public bool HaveNext()
        {
            if (this.RightNode != null || this.LeftNode != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;
        IEnumerator IEnumerable.GetEnumerator()
        {

            yield return this.Data;
            var er = this;
            yield return this.Data;
            if (er.LeftNode != null) //Відвідування лівого піддерева
            {
                foreach (T item in er.LeftNode)
                {
                    yield return er.LeftNode.Data;
                    er = er.LeftNode;


                }
            }
            er = this;
            if (er.RightNode != null) //Відвідування правого піддерева
            {
                foreach (T item in er.RightNode)
                {
                    yield return er.RightNode.Data;
                    er = er.RightNode;

                }
            }




        }

        

        public override string ToString() => Data.ToString();

        

    
    }
}
