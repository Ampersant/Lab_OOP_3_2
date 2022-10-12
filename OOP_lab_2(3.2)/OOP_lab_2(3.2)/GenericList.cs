using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_2_3._2_
{
    internal class GenericList
    {
        
        protected List<Trapezium> _list { get; set; }

        public GenericList()
        {
            _list = null;
        }
        public GenericList(List<Trapezium> list)
        {
            _list = list;
        }
        public GenericList(Trapezium obj)
        {
            _list.Add(obj);
        }
        public void Add(Trapezium obj)
        {
            _list.Add(obj);
        }
        public void Remove(Trapezium obj)
        {
            _list.Remove(obj);
        }
        public string Find(Trapezium obj)
        {
            string s = "Searching for object... \n";
            ;
            if (!_list.Contains(obj))
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
            foreach (var item in _list)
            {
                s += $"Object data: \n" + "\t" + item.GetData() + "\n";
            }
            return s;
        }
    }
}
