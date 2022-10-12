using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_2_3._2_
{
    internal class NonGenericList
    {
       public System.Collections.ArrayList arrayList { get; set; }
  

        public NonGenericList()
        {
            arrayList = null;
        }
        public NonGenericList(System.Collections.ArrayList list)
        {
            arrayList = list;
        }
        public NonGenericList(Trapezium obj)
        {
            arrayList.Add(obj);
        }
        public void Add(Trapezium obj)
        {
            arrayList.Add(obj);
        }
        public string Find(Trapezium obj)
        {
            string s = "Searching for object... \n";
            
            if (!arrayList.Contains(obj))
            {
                s += "Object doesn't exist in this collection";
                return s;
            }
            s += $"Object data: \n" + "\t" + obj.GetData() + "\n" + "Success!";
            return s;
        }
        public void Remove(Trapezium obj)
        {
            arrayList.Remove(obj);
        }
        public string GetAll()
        {
            string s = "\n --------------------------New List!!!-------------------------- \n";
            foreach (Trapezium item in arrayList)
            {
                s += $"Object data: \n" + "\t" + item.GetData() + "\n";
            }
            return s;
        }
        
    }
}
