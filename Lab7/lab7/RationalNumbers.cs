using System;
using System.Collections.Generic;
using System.Text;

namespace lab7
{
    class RationalNumbers : IEquatable<RationalNumbers>, IComparable, IConvertible
    {
        private long mNumerator;
        private long mDenominator;
        public RationalNumbers(long numerator, long denominator)
        {
            this.mNumerator = numerator;
            this.mDenominator = (denominator > 0) ? denominator : throw new Exception("Знаменатель должен быть числом натуральным!");
            RationalNumbers tempNumber = FractionReduction(this);
        }

		public long Numerator
		{
			set 
			{
				mNumerator = value; 
			}
			get
			{
				return mNumerator;
			}
		}
		public long Denominator
		{
			get
			{
				return mDenominator;
			}
			set
			{
				if (value == 0L)
				{
					throw new DivideByZeroException();
				}
				if (value < 0L)
				{
					throw new Exception("Знаменатель должен быть числом натуральным!");
				}
				else
				{
					mDenominator = value;
				}
			}
		}

        private static RationalNumbers FractionReduction(RationalNumbers number)
        {
            long nod = LargestCommonFactor(number.mNumerator, number.mDenominator);
            number.mNumerator /= nod;
            number.mDenominator /= nod;
            return number;
        }


        public TypeCode GetTypeCode()
		{
			return TypeCode.Object;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return (Numerator != 0) ? true : false;
		}

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(Numerator / Denominator);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(Numerator / Denominator);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(Numerator / Denominator);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal((decimal)Numerator / Denominator);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((double)Numerator / Denominator);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(Numerator / Denominator);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(Numerator / Denominator);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(Numerator / Denominator);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(Numerator / Denominator);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(Numerator / Denominator);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return String.Format("({0}/{1})", Numerator, Denominator);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(Numerator / Denominator, conversionType);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(Numerator / Denominator);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32((int)Numerator / Denominator);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(Numerator / Denominator);
        }
      
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            RationalNumbers otherRational = obj as RationalNumbers;

            if (otherRational != null)
                return (this.mNumerator / this.mDenominator).CompareTo(otherRational.mNumerator / otherRational.mDenominator);
            else
                throw new ArgumentException("Object is not a rational number");
        }

        public bool Equals(RationalNumbers other)
        {
            if (other == null)
            {
                return false;
            }
            if ((this.mNumerator == other.mNumerator) && (this.mDenominator == other.mDenominator))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            RationalNumbers rationalObj = obj as RationalNumbers;
            if (rationalObj == null)
            {
                return false;
            }
            else
            {
                return Equals(rationalObj);
            }
        }

        public override int GetHashCode()
        {
            return (mNumerator / mDenominator).GetHashCode();
        }
        
        public static RationalNumbers operator +(RationalNumbers rationalOne, RationalNumbers rationalTwo)
        {
            long nod = LargestCommonFactor(rationalOne.mDenominator, rationalTwo.mDenominator);
            long nok = (rationalOne.mDenominator / nod) * rationalTwo.mDenominator;
            if (nok > long.MaxValue)
            {
                throw new OverflowException("The number is too large");
            }
            else
            {
                long newNumerator;
                long newDenominator;
                newDenominator = nok;
                newNumerator = (rationalOne.mNumerator * rationalTwo.mDenominator / nod) + (rationalTwo.mNumerator * rationalOne.mDenominator / nod);
                RationalNumbers result = new RationalNumbers(newNumerator, newDenominator);
                return result;
            }
        }

        public static RationalNumbers operator -(RationalNumbers rationalOne, RationalNumbers rationalTwo)
        {
            long nod = LargestCommonFactor(rationalOne.mDenominator, rationalTwo.mDenominator);
            long nok = (rationalOne.mDenominator / nod) * rationalTwo.mDenominator;
            if (nok > long.MaxValue)
            {
                throw new OverflowException("The number is too large");
            }
            else
            {
                long newNumerator;
                long newDenominator;
                newDenominator = nok;
                newNumerator = (rationalOne.mNumerator * rationalTwo.mDenominator / nod) - (rationalTwo.mNumerator * rationalOne.mDenominator / nod);
                RationalNumbers result = new RationalNumbers(newNumerator, newDenominator);
                return result;
            }
        }

        public static RationalNumbers operator *(RationalNumbers rationalOne, RationalNumbers rationalTwo)
        {
            long newNumerator;
            long newDenominator;
            newNumerator = rationalOne.mNumerator * rationalTwo.mNumerator;
            newDenominator = rationalOne.mDenominator * rationalTwo.mDenominator;
            RationalNumbers result = new RationalNumbers(newNumerator, newDenominator);
            return result;
        }

        public static RationalNumbers operator /(RationalNumbers rationalOne, RationalNumbers rationalTwo)
        {
            long newNumerator;
            long newDenominator;
            newNumerator = rationalOne.mNumerator * rationalTwo.mDenominator;
            newDenominator = rationalOne.mDenominator * rationalTwo.mNumerator;
            RationalNumbers result = new RationalNumbers(newNumerator, newDenominator);
            return result;
        }

        public static RationalNumbers operator %(RationalNumbers rationalOne, RationalNumbers rationalTwo)
        {
            long nod = LargestCommonFactor(rationalOne.mDenominator, rationalTwo.mDenominator);
            long nok = (rationalOne.mDenominator / nod) * rationalTwo.mDenominator;
            if (nok > long.MaxValue)
            {
                throw new OverflowException("The number is too large");
            }
            else
            {
                long newNumerator;
                long newDenominator;
                newDenominator = nok;
                newNumerator = (rationalOne.mNumerator * rationalTwo.mDenominator / nod) % (rationalTwo.mNumerator * rationalOne.mDenominator / nod);
                RationalNumbers result = new RationalNumbers(newNumerator, newDenominator);
                return result;
            }
        }

        public static RationalNumbers Pow(RationalNumbers number, double power)
        {
            
            long newNumerator = (long)(Math.Pow(number.mNumerator, power));
            long newDenominator = (long)(Math.Pow(number.mDenominator, power));
            return new RationalNumbers(newNumerator, newDenominator);
        }

        public static bool operator !=(RationalNumbers number, double obj)
        {
            return (Math.Abs((number.mNumerator / number.mDenominator) - obj) > 0.000001);
        }

        public static bool operator !=(RationalNumbers number, float obj)
        {
            return (Math.Abs((number.mNumerator / number.mDenominator) - obj) > 0.000001);
        }

        public static bool operator !=(RationalNumbers numberOne, RationalNumbers numberTwo)
        {
            if((numberOne.mNumerator == numberTwo.mNumerator) && (numberOne.mDenominator == numberTwo.mDenominator))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator ==(RationalNumbers number, float obj)
        {
            return (Math.Abs((number.mNumerator / number.mDenominator) - obj) <= 0.000001);
        }

        public static bool operator ==(RationalNumbers number, double obj)
        {
            return (Math.Abs((number.mNumerator / number.mDenominator) - obj) <= 0.000001);
        }

        public static bool operator ==(RationalNumbers numberOne, RationalNumbers numberTwo)
        {
            if ((numberOne.mNumerator == numberTwo.mNumerator) && (numberOne.mDenominator == numberTwo.mDenominator))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >=(RationalNumbers number, float obj)
        {
            return ((float)(number.mNumerator / number.mDenominator) >= obj);
        }

        public static bool operator >=(RationalNumbers number, double obj)
        {
            return ((double)(number.mNumerator / number.mDenominator) >= obj);
        }

        public static bool operator >=(RationalNumbers numberOne, RationalNumbers numberTwo)
        {
            long nod = LargestCommonFactor(numberOne.mDenominator, numberTwo.mDenominator);
            if((numberOne.mNumerator * numberTwo.mDenominator / nod) >= (numberTwo.mNumerator * numberOne.mDenominator / nod))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(RationalNumbers number, float obj)
        {
            return ((float)(number.mNumerator / number.mDenominator) <= obj);
        }

        public static bool operator <=(RationalNumbers number, double obj)
        {
            return ((double)(number.mNumerator / number.mDenominator) <= obj);
        }

        public static bool operator <=(RationalNumbers numberOne, RationalNumbers numberTwo)
        {
            long nod = LargestCommonFactor(numberOne.mDenominator, numberTwo.mDenominator);
            if ((numberOne.mNumerator * numberTwo.mDenominator / nod) <= (numberTwo.mNumerator * numberOne.mDenominator / nod))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(RationalNumbers number, float obj)
        {
            return ((float)(number.mNumerator / number.mDenominator) > obj);
        }

        public static bool operator >(RationalNumbers number, double obj)
        {
            return ((double)(number.mNumerator / number.mDenominator) > obj);
        }

        public static bool operator >(RationalNumbers numberOne, RationalNumbers numberTwo)
        {
            long nod = LargestCommonFactor(numberOne.mDenominator, numberTwo.mDenominator);
            if ((numberOne.mNumerator * numberTwo.mDenominator / nod) > (numberTwo.mNumerator * numberOne.mDenominator / nod))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(RationalNumbers number, float obj)
        {
            return ((float)(number.mNumerator / number.mDenominator) < obj);
        }

        public static bool operator <(RationalNumbers number, double obj)
        {
            return ((double)(number.mNumerator / number.mDenominator) < obj);
        }

        public static bool operator <(RationalNumbers numberOne, RationalNumbers numberTwo)
        {
            long nod = LargestCommonFactor(numberOne.mDenominator, numberTwo.mDenominator);
            if ((numberOne.mNumerator * numberTwo.mDenominator / nod) < (numberTwo.mNumerator * numberOne.mDenominator / nod))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static RationalNumbers operator ++(RationalNumbers number)
        {
            number.mNumerator += number.mDenominator;
            return number;
        }

        public static RationalNumbers operator --(RationalNumbers number)
        {
            number.mNumerator -= number.mDenominator;
            return number;
        }

        public static RationalNumbers operator -(RationalNumbers number)
        {
            number.mNumerator = -number.mNumerator;
            return number;
        }

        public static RationalNumbers operator +(RationalNumbers number)
        {
            return number;
        }

        public override string ToString()
        {
            return this.ToString("/");
        }

        public string ToString(string format)
        {
            if (String.IsNullOrEmpty(format)) format = "/";

            switch (format.ToUpperInvariant())
            {
                case "/":
                    return string.Format("{0} / {1}", Numerator, Denominator);
                case "\\":
                    return string.Format("{0} \\ {1}", Numerator, Denominator);
                case "|":
                    return string.Format("{0} | {1}", Numerator, Denominator);
                case ":":
                    return string.Format("{0} : {1}", Numerator, Denominator);
                case "D":
                case "d":
                    return string.Format((Numerator / Denominator).ToString());
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        public static RationalNumbers Parse(String obj)
        {
            long numerator = 0;
            long denominator;
            string number = "";
            foreach (char separator in obj)
            {
                if (separator == '/' || separator == '\\' || separator == '|' || separator == ':')
                {
                    numerator = Int64.Parse(number);
                    number = "";
                    continue;
                }
                number += separator;
            }
            denominator = Int64.Parse(number);
            RationalNumbers rational = new RationalNumbers(numerator, denominator);
            return rational;
        }

        public static bool TryParse(String obj, out RationalNumbers result)
        {
            long numerator = 0;
            long denominator;
            bool isSeparator = false;
            string number = "";
            foreach (char separator in obj)
            {
                if (separator == '/' || separator == '\\' || separator == '|' || separator == ':')
                {
                    if (Int64.TryParse(number, out numerator) == false && isSeparator == false)
                    {
                        result = new RationalNumbers(0, 1);
                        return false; 
                    }
                    number = "";
                    isSeparator = true;
                    continue;
                }
                number += separator;
            }

            if (Int64.TryParse(number, out denominator) == false)
            {
                result = new RationalNumbers(0, 1);
                return false;
            }
            else
            {
                result = new RationalNumbers(numerator, denominator);
                return true;
            }
        }

        public static long LargestCommonFactor(long denom1, long denom2)
        {
            denom1 = Math.Abs(denom1);
            denom2 = Math.Abs(denom2);
            if (denom1 != 0 && denom2 != 0)
            {
                
                if (denom1 >= (denom2))
                {
                    return LargestCommonFactor(denom2, denom1 % denom2);
                }
                else return LargestCommonFactor(denom1, denom2 % denom1);
            }
            return (denom1 != 0) ? denom1 : denom2;
        }
    }
}
