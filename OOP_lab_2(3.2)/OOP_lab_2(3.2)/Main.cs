using OOP_lab_2_3._2_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net.WebSockets;
using System.Collections;
using System.Diagnostics;

namespace _2c_OOP_lab_1_1
{
    internal class MainClass
    {
        static void Main(string[] args) // головна функція
        {


            
            Trapezium T1 = new Trapezium();
            Trapezium T2 = new Trapezium("yellow", "black", 3, 4, 6);
            Trapezium T3 = new Trapezium("green", "blue", 5, 6, 4);
            Trapezium T4 = new Trapezium("black", "cyan", 2, 1, 1);
            // робота з масивом
          /*  ArrayCollection ArCol = new ArrayCollection(T1, T2, T3, T4);
            Console.WriteLine(ArCol.GetAll());
            Console.WriteLine(ArCol.Add(T2));
            Console.WriteLine(ArCol.Find(T3));
            ArCol.Remove(T3);
            Console.WriteLine(ArCol.Add(T2));
            Console.WriteLine(ArCol.GetAll());
            
            // робота з нон-дженеріком
            ArrayList arl = new ArrayList();
            arl.Add(T1);
            arl.Add(T2);
            arl.Add(T3);
            arl.Add(T4);

            NonGenericList NGL = new NonGenericList(arl);
            Console.WriteLine(NGL.GetAll());
            NGL.Remove(T1);
            NGL.Add(T3);
            NGL.Add(T3);
            NGL.Add(T3);
            NGL.Add(T3);
            Console.WriteLine(NGL.GetAll());
            Console.WriteLine(NGL.Find(T4));*/
            // робота з дженеріком 
            
            
            /*List<Trapezium> list = new List<Trapezium>();
            list.Add(T1);
            list.Add(T2);
            list.Add(T3);
            list.Add(T4);
            GenericList GL = new GenericList(list);
            Console.WriteLine(GL.GetAll());
            Console.WriteLine(GL.Find(T4));
            GL.Remove(T3);
            GL.Remove(T4);
            GL.Remove(T2);
            GL.Add(T1);
            GL.Add(T1);
            GL.Add(T1);
            Console.WriteLine(GL.GetAll());*/


            BinaryTreeNode<Trapezium> Node1 = new BinaryTreeNode<Trapezium>(T1);
            BinaryTreeNode<Trapezium> Node2 = new BinaryTreeNode<Trapezium>(T2);
            BinaryTreeNode<Trapezium> Node3 = new BinaryTreeNode<Trapezium>(T3);
            BinaryTreeNode<Trapezium> Node4 = new BinaryTreeNode<Trapezium>(T4);

         /*   var genTrapz = new List<BinaryTreeNode<Trapezium>>();
            genTrapz.Add(Node1);
            genTrapz.Add(Node2);
            genTrapz.Add(Node3);
            genTrapz.Add(Node4);*/
            var bTree = new BinaryTree<Trapezium>();
            bTree.Add(T1);
            bTree.Add(T2);
            bTree.Add(T3);
            bTree.Add(T4);
           // bTree.PrintTree();
            BinaryTreeNode<Trapezium> Found = bTree.FindNode(T4);
            //Console.WriteLine("\t" + Found.Data.GetData());
            string s = bTree.LCR();
           // Console.WriteLine(s);
            Trapezium T5 = new Trapezium("black", "cyan", 4, 2, 4);
            Trapezium T6 = new Trapezium("black", "cyan", 0.2, 0.3, 1);
            Trapezium T7 = new Trapezium("black", "cyan", 7, 2, 4);
            bTree.Add(T5);
            bTree.Add(T6);
            bTree.Add(T7);
            BinaryTreeNode<Trapezium> Node5 = new BinaryTreeNode<Trapezium>(T7);
            BinaryTreeNode<Trapezium> Node6 = new BinaryTreeNode<Trapezium>(T7);
            BinaryTreeNode<Trapezium> Node7 = new BinaryTreeNode<Trapezium>(T7);
            bTree.PrintTree();

            
            foreach (Trapezium item in bTree.RootNode)
            {
                Console.WriteLine($"{item.GetData()}");
            }
/*
            genTrapz.Add(Node5);
            genTrapz.Add(Node6);
            genTrapz.Add(Node7);

            bTree = new BinaryTree<Trapezium>();

            bTree.PrintTree();
           
            Console.WriteLine(s);

            Console.WriteLine(genTrapz.ToString());

            foreach (var item in bTree)
            {
                Console.WriteLine(item.GetData());
            }*/

            /* Console.WriteLine($" {Traps.First().Data.BorderColor}");
             var bTree = new BinaryTree<Trapezium>(Traps);
             bTree.PrintTree(); 
             var Found = bTree.FindNode(T4);

             string s = bTree.LCR();
             Console.WriteLine(s);*/

            /*var binaryTree = new BinaryTree<Trapezium>();
            Trapezium T2 = new Trapezium("yellow", "black", 3, 4, 6);
            Trapezium T3 = new Trapezium("green", "blue", 5, 6, 4);
            Trapezium T4 = new Trapezium("black", "cyan", 2, 1, 1);
           // Trapezium T5 = new Trapezium("Sbb", "Case", 12);
            binaryTree.Add(T1);
            binaryTree.Add(T2);
            binaryTree.Add(T3);

            binaryTree.PrintTree();
            Console.WriteLine("-", 40);
            binaryTree.Add(T4);

            binaryTree.PrintTree();
            binaryTree.Remove(T1);

            binaryTree.PrintTree();
*/






        }
        


    }

}