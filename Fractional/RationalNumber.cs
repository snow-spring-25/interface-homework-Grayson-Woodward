using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractional
{
    public class RationalNumber : IEquatable<RationalNumber>, IComparable<RationalNumber>
    {
        int numerator;
        int denominator;
        public RationalNumber(int num, int denom)
        {
            if (denom == 0) throw new ArgumentException("Denominator cannot be zero.");
            numerator = num;
            denominator = denom;

            var gcd = GreatestCommonDenominator(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }
        public override string ToString()
        {
            return numerator + "/" + denominator;
        }
        static int GreatestCommonDenominator(int a, int b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }
            else
            {
                return GreatestCommonDenominator(b, a % b);
            }
        }
        public bool Equals(RationalNumber? other)
        {
            if (other == null) return false;
            return this.numerator == other.numerator && this.denominator == other.denominator;
        }
        public int CompareTo(RationalNumber? other)
        {
            if (other == null) return 1; 
            int left = this.numerator * other.denominator;
            int right = this.denominator * other.numerator;

            return left.CompareTo(right);
        }
    }
}
