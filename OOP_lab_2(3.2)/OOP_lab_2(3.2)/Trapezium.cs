using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_2_3._2_
{
    internal class Trapezium : IComparable, IEnumerable
    {
        protected string fillColor;
        protected string borderColor;
        protected double a;
        protected double b;
        protected double h;
        protected double data;
        


        public string FillColor
        {
            get { return fillColor; }
            set { this.fillColor = value; }
        }
        public string BorderColor
        {
            get { return borderColor; }
            set { this.borderColor = value; }
        }
        public double A { 
          get { return a; }
          set { this.a = value; }
        }
        public double B
        {
            get { return b; }
            set { this.b = value; }
        }
        public double Data
        {
            get { return data; }
            set { data = value; }
        }

        public double CalcSq()
        {
            double Sq = (a + b)/2 * h;
            return Sq;
        }
        public double CalcP()
        {
            double p = this.a + this.b + 2 * (Math.Sqrt(Math.Pow(this.h, 2) + Math.Pow(Math.Abs(this.b - this.a) / 2, 2)));
            return p;
        }

        int IComparable.CompareTo(object obj)
        {
            Trapezium temp = obj as Trapezium;
            if (temp != null)
            {
                //Порівняння здійснюється за номером студентського квитка
                double id1 = this.Data;
                double id2 = temp.Data;
                if (id1 > id2)
                    return 1;
                if (id1 < id2)
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Parametr is not a Student");
        }
        public string GetData()
        {
            string s = $"A = {this.a} \n\tB = {this.b} \n\tH = {this.h} \n\tSquare = {this.CalcSq()} \n\tPerimeter = {this.CalcP()} \n\tBackground color = {FillColor} \n\tBorder color = {BorderColor}";
            return s;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)data.ToString()).GetEnumerator();
        }

        public Trapezium()
        {
            this.FillColor = "none";
            this.BorderColor = "black";
            this.a = 1;
            this.b = 2;
            this.h = 3;
            data = this.CalcSq();
        }
        public Trapezium(string fillColor, string borderColor, double a, double b, double h)
        {
            FillColor = fillColor;
            BorderColor = borderColor;
            A = a;
            B = b;
            this.h = h;
            data = this.CalcSq();
        }
    }
}
