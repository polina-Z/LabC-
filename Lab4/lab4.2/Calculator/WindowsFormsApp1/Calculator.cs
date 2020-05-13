using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    class Calculator
    {
        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Plus(double x, double y);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Minus(double x, double y);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Multiplication(double x, double y);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Devision(double x, double y);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mod(double x, double y);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double SquareRoot(double x);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Squared(double x);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MuttuallyInverse(double x);

        [DllImport(@"CalculatorDll.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string SolveQuadraticEquation(double a, double b, double c);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int binpow(int a, int n);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Sin(double x);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Cos(double x);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Tg(double x);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Ln(double x);

        [DllImport(@"CalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double BallVolume(double R);

        [DllImport(@"CalculatorDll.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string ToOpz(string str);

        [DllImport(@"CalculatorDll.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern float OPZ(string str);
    }
}
