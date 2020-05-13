#pragma once
#ifdef Calculator_EXPORTS
#define Calculator_API __declspec(dllimport)
#else
#define Calculator_API __declspec(dllexport)
#endif

extern "C" Calculator_API double Plus(double x, double y);
extern "C" Calculator_API double Minus(double x, double y);
extern "C" Calculator_API double Multiplication(double x, double y);
extern "C" Calculator_API double Devision(double x, double y);
extern "C" Calculator_API double Mod(double x, double y);
extern "C" Calculator_API double  SquareRoot(double x);
extern "C" Calculator_API double Squared(double x);
extern "C" Calculator_API double MuttuallyInverse(double x);
extern "C" Calculator_API BSTR SolveQuadraticEquation(double a, double b, double c);
extern "C" Calculator_API int binpow(int a, int n);
extern "C" Calculator_API double Sin(double x);
extern "C" Calculator_API double Cos(double x);
extern "C" Calculator_API double Tg(double x);
extern "C" Calculator_API double Ln(double x);
extern "C" Calculator_API double BallVolume(double R);
extern "C" Calculator_API BSTR ToOpz(BSTR str);
extern "C" Calculator_API float OPZ(BSTR str);