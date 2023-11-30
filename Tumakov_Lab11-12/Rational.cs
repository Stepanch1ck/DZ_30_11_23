using System;

namespace Tumakov_Lab11_12
{
    internal class Rational
    {
        public int numerator;
        public int denominator;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть 0");
            }
            this.numerator = numerator;
            this.denominator = denominator;
            Normalize();
        }
        public override string ToString()
        {
            if (denominator == 1)
            {
                return $"{numerator}";
            }
            else
            {
                return $"{numerator}/{denominator}";
            }
        }
        private static int GCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            else
            {
                return GCD(b % a, a);
            }
        }
        private void Normalize()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        public static Rational Add(Rational rational1, Rational rational2)
        {
            return new Rational(rational1.numerator * rational2.denominator + rational2.numerator * rational1.denominator,
                rational1.denominator * rational2.denominator);
        }

        public static Rational Subtract(Rational rational1, Rational rational2)
        {
            return new Rational(rational1.numerator * rational2.denominator - rational2.numerator * rational1.denominator,
                rational1.denominator * rational2.denominator);
        }

        public static Rational Multiply(Rational rational1, Rational rational2)
        {
            return new Rational(rational1.numerator * rational2.numerator,
                rational1.denominator * rational2.denominator);
        }

        public static Rational Divide(Rational rational1, Rational rational2)
        {
            return new Rational(rational1.numerator * rational2.denominator,
                rational1.denominator * rational2.numerator);
        }

        public static Rational Negate(Rational rational)
        {
            return new Rational(-rational.numerator, rational.denominator);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is Rational)
            {
                Rational otherRational = (Rational)obj;
                return numerator == otherRational.numerator && denominator == otherRational.denominator;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        

        public static bool operator ==(Rational rational1, Rational rational2)
        {
            return rational1.Equals(rational2);
        }

        public static bool operator !=(Rational rational1, Rational rational2)
        {
            return !(rational1 == rational2);
        }

        public static bool operator <(Rational rational1, Rational rational2)
        {
            return rational1.numerator * rational2.denominator < rational1.denominator * rational2.numerator;
        }

        public static bool operator >(Rational rational1, Rational rational2)
        {
            return rational1.numerator * rational2.denominator > rational1.denominator * rational2.numerator;
        }

        public static bool operator <=(Rational rational1, Rational rational2)
        {
            return !(rational1 > rational2);
        }

        public static bool operator >=(Rational rational1, Rational rational2)
        {
            return !(rational1 < rational2);
        }

        public static Rational operator +(Rational rational1, Rational rational2)
        {
            return Add(rational1, rational2);
        }

        public static Rational operator -(Rational rational1, Rational rational2)
        {
            return Subtract(rational1, rational2);
        }

        public static Rational operator *(Rational rational1, Rational rational2)
        {
            return Multiply(rational1, rational2);
        }

        public static Rational operator /(Rational rational1, Rational rational2)
        {
            return Divide(rational1, rational2);
        }
        public static Rational operator %(Rational rational1, Rational rational2)
        {
            return new Rational(rational1.numerator * rational2.denominator % rational1.denominator * rational2.numerator,
                rational1.denominator * rational2.denominator);
        }

        public static float ToFloat(Rational rational)
        {
            if (rational.denominator == 0)
            {
                throw new ArithmeticException("Деление на ноль");
            }

            return (float)rational.numerator / rational.denominator;
        }

        public static int ToInt(Rational rational)
        {
            if (rational.denominator == 0)
            {
                throw new ArithmeticException("Деление на ноль");
            }

            return rational.numerator / rational.denominator;
        }


        public static Rational operator ++(Rational rational)
        {
            rational.numerator++;
            return rational;
        }

        public static Rational operator --(Rational rational)
        {
            rational.numerator--;
            return rational;
        }
    }
}
