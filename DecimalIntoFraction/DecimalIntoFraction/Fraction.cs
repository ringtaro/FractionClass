using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DecimalIntoFraction
{
    public class Fraction
    {
        int numerator;
        int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static Fraction FromDecimal(decimal input_num)
        {
            Stack<int> astack = GetContinuedFraction(input_num);
            return FromContinuedFraction(astack);
        }

        private static Fraction FromContinuedFraction(Stack<int> astack)
        {
            int rn = astack.Pop();
            int rm = 1;
            while (astack.Count > 0)
            {
                int fa = astack.Pop() * rn + rm;
                rm = rn;
                rn = fa;
            }
            return new Fraction(rn, rm);
        }

        public override string ToString()
        {
            return string.Format("{0} / {1}", numerator, denominator);
        }

        struct MixedNumber
        {
            internal int Num;
            internal decimal A;
            internal decimal B;
        }

        private static Stack<int> GetContinuedFraction(decimal input_num)
        {
            Debug.Print(string.Format("{0}", input_num));
            Stack<int> astack = new Stack<int>();
            MixedNumber mx = new MixedNumber();
            mx.A = input_num;
            mx.B = 1m;
            do
            {
                mx = GetMixedNumber(mx.A, mx.B);
                Debug.Print(string.Format("{0}  {1}  {2}", mx.Num, mx.A, mx.B));
                astack.Push(mx.Num);
            } while (mx.B != 0);
            return astack;
        }

        private static MixedNumber GetMixedNumber(decimal a, decimal b)
        {
            MixedNumber result = new MixedNumber();
            int num = (int)Math.Floor(a / b);
            result.Num = num;
            result.A = b;
            result.B = a - b * num;
            return result;
        }
    }
}
