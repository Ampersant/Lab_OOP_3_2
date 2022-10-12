using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_2_3._2_
{
    internal class ArrayCollection
    {
        static Trapezium[] arr = new Trapezium[4];
        public Trapezium this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }
        public string Add(Trapezium value)
        {
            string s = "";
            if (arr.Length < 4)
            {
                List<Trapezium> List = new List<Trapezium>(arr);
                List.Add(value);
                arr = List.ToArray();
                return s = "Add successfully";
            }
            else
            {
                return s = "Add is impossible!";
            }
           
        }
        public ArrayCollection(Trapezium T1, Trapezium T2, Trapezium T3, Trapezium T4)
        {
            arr[0] = T1;
            arr[1] = T2;
            arr[2] = T3;
            arr[3] = T4;
        }
        public void Remove(Trapezium obj)
        {
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == obj)
                {

                    List<Trapezium> List = new List<Trapezium>(arr);
                    List.Remove(arr[i]);
                    arr = List.ToArray(); 
                }
            }
        }
        public string Find(Trapezium obj)
        {
            string s = "Searching for object... \n";
            List<Trapezium> List = new List<Trapezium>(arr);
            if (!List.Contains(obj))
            {
                s += "Object doesn't exist in this collection";
                return s;
            }
            s += $"Object data: \n" + "\t" + obj.GetData() + "\n" + "Success!";
            return s;
        }
        public string GetAll()
        {
            string s = "\n --------------------------New List!!!-------------------------- \n";
            foreach (Trapezium item in arr)
            {
                s += $"Object data: \n" + "\t" + item.GetData() + "\n";
            }
            return s;
        }
    }
}
