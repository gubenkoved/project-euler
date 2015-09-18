using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Fraction
    {
        public BigInteger Numerator;
        public BigInteger Denomerator;

        public Fraction(BigInteger x)
        {
            Numerator = x;
            Denomerator = 1;
        }

        public Fraction(BigInteger n, BigInteger d)
        {
            Numerator = n;
            Denomerator = d;
        }

        public void Simplify()
        {
            var gcd = Basic.GCD_B(Numerator, Denomerator);

            if (gcd > 1)
            {
                Numerator /= gcd;
                Denomerator /= gcd;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denomerator);
        }

        #region Static methods
        public static Fraction CreateB(BigInteger x)
        {
            return new Fraction(x);
        }

        public static Fraction CreateB(BigInteger n, BigInteger d)
        {
            return new Fraction(n, d);
        }

        public static Fraction Create(long x)
        {
            return new Fraction(new BigInteger(x));
        }

        public static Fraction Create(long n, long d)
        {
            return new Fraction(new BigInteger(n), new BigInteger(d));
        }
        #endregion

        #region Operators
        public static Fraction operator +(Fraction a, Fraction b)
        {
            var commonDenomerator = Basic.LCM_B(a.Denomerator, b.Denomerator);

            var aMult = commonDenomerator / a.Denomerator;
            var bMult = commonDenomerator / b.Denomerator;

            var numerator = a.Numerator * aMult
                + b.Numerator * bMult;

            var r = new Fraction(numerator, commonDenomerator);

            r.Simplify();

            return r;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            var r = new Fraction(
                a.Numerator * b.Denomerator,
                a.Denomerator * b.Numerator);

            r.Simplify();

            return r;
        }

        public static explicit operator decimal(Fraction f)
        {
            return (decimal)f.Numerator / (decimal)f.Denomerator;
        }
        #endregion
    }
}
