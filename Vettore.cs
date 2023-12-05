using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pianeti
{
    internal class Vettore
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vettore() { }

        public Vettore(double x, double y)
        {
            X = x;
            Y = y;
        }

        static public Vettore operator + (Vettore a, Vettore b)
        {
            return new Vettore(a.X + b.X, a.Y + b.Y);
        }

        static public Vettore operator - (Vettore a, Vettore b)
        {
            return new Vettore(a.X - b.X, a.Y - b.Y);
        }

        static public Vettore operator * (Vettore a, double b)
        {
            return new Vettore(a.X * b, a.Y * b);
        }

        static public Vettore operator / (Vettore a, double b)
        {
            return new Vettore(a.X / b, a.Y / b);
        }

        public double Modulo()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public static bool operator ==(Vettore a, Vettore b)
        {
            if (a is null)
            {
                return b is null;
            }
            else if (b is null)
            {
                return false;
            }
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Vettore a, Vettore b)
        {
            return !(a == b);
        }
    }
}
