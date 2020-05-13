#include "pch.h" 
#include <utility>
#include <limits.h>
#include <wtypes.h>
#include <OleAuto.h>
#include "CalculatorDLL.h"
#include <math.h>
#include <string>

double Plus(double x, double y)
{
	return x + y;
}

double Minus(double x, double y)
{
	return x - y;
}

double Multiplication(double x, double y)
{
	return x * y;
}

double Devision(double x, double y)
{
	return x / y;
}

double Mod(double x, double y)
{
	int intX = (int)x;
	int intY = (int)y;
	if (intX > 0 && intY > 0)
	{
		return intX % intY;
	}
	else
	{
		return 0;
	}
}

double SquareRoot(double x)
{
	if (x > 0)
	{
		return sqrt(x);
	}
	else
	{
		return 0;
	}
}

double Squared(double x)
{
	return x * x;
}

double MuttuallyInverse(double x)
{
	return 1.0 / x;
}

BSTR SolveQuadraticEquation(double a, double b, double c)
{
	std::string result = "";
	if (a != 0 && b != 0 && c != 0)
	{
		double D = b * b - (4 * a * c);
		if (D < 0)
		{
			result = "No solutions";
			std::wstring wstr = std::wstring(result.begin(), result.end());
			return SysAllocString(wstr.c_str());

		}

		if (D == 0)
		{
			double x = -b / (2 * a);
			result = "x = " + std::to_string(x);
			std::wstring wstr = std::wstring(result.begin(), result.end());
			return SysAllocString(wstr.c_str());
		}

		if (D > 0)
		{
			double x1 = (-b + sqrt(D)) / (2 * a);
			double x2 = (-b - sqrt(D)) / (2 * a);
			result = "x1 = " + std::to_string(x1) + "; x2 = " + std::to_string(x1);
			std::wstring wstr = std::wstring(result.begin(), result.end());
			return SysAllocString(wstr.c_str());
		}
	}

	if (a == 0 && b != 0 && c != 0)
	{
		double x = -c / b;
		result = "x = " + std::to_string(x);
		std::wstring wstr = std::wstring(result.begin(), result.end());
		return SysAllocString(wstr.c_str());
	}

	if (a != 0 && b == 0 && c != 0)
	{
		if ((-c / a) > 0)
		{
			double x1 = sqrt(-c / a);
			double x2 = -sqrt(-c / a);
			result = "õ1 = " + std::to_string(x1) + "; x2 = " + std::to_string(x1);
			std::wstring wstr = std::wstring(result.begin(), result.end());
			return SysAllocString(wstr.c_str());
		}
		else
		{
			result = "No solutions";
			std::wstring wstr = std::wstring(result.begin(), result.end());
			return SysAllocString(wstr.c_str());
		}
	}

	if (a != 0 && b != 0 && c == 0)
	{
		double x = -b / a;
		result = "x1 = 0; x2 = " + std::to_string(x);
		std::wstring wstr = std::wstring(result.begin(), result.end());
		return SysAllocString(wstr.c_str());
	}

	if (a == 0 && b == 0 && c != 0)
	{
		result = "No solutions";
		std::wstring wstr = std::wstring(result.begin(), result.end());
		return SysAllocString(wstr.c_str());
	}

	if (a == 0 && b != 0 && c == 0)
	{
		result = "x = 0";
		std::wstring wstr = std::wstring(result.begin(), result.end());
		return SysAllocString(wstr.c_str());
	}

	if (a != 0 && b == 0 && c == 0)
	{
		result = "x = 0";
		std::wstring wstr = std::wstring(result.begin(), result.end());
		return SysAllocString(wstr.c_str());
	}

	if (a == 0 && b == 0 && c == 0)
	{
		result = "x is any number";
		std::wstring wstr = std::wstring(result.begin(), result.end());
		return SysAllocString(wstr.c_str());
	}
	result = "No solutions";
	std::wstring wstr = std::wstring(result.begin(), result.end());
	return SysAllocString(wstr.c_str());
}

int binpow(int a, int n)
{
	if (n == 0)
	{
		return 1;
	}
	if (n % 2 == 1)
	{
		return binpow(a, n - 1) * a;
	}
	else
	{
		int b = binpow(a, n / 2);
		return b * b;
	}
}

double Sin(double x)
{
	return sin(x);
}

double Cos(double x)
{
	return cos(x);
}

double Tg(double x)
{
	return tan(x);
}

double Ln(double x)
{
	if (x > 0)
	{
		return log(x);
	}
	else
	{
		return 0;
	}
}

double BallVolume(double R)
{
	if (R > 0)
	{
		return (4.0 / 3) * 3.14 * R * R * R;
	}
	else
	{
		return 0;
	}
}

class Stack
{
private:
	class Node
	{
	public:
		char info;
		Node* next;
		Node(char info, Node* next = nullptr)
		{
			this->info = info;
			this->next = next;
		}

	};
	Node* head;
	class NodeF
	{
	public:
		float info;
		NodeF* next;
		NodeF(float info, NodeF* next = nullptr)
		{
			this->info = info;
			this->next = next;
		}
	};
	NodeF* headf;
	friend bool operator<(const Node& item1, const char& info2);
public:
	Stack();
	void Input(char str);
	char Output();
	void InputF(float str);
	float OutputF();
	char Top();
	std::string ToOPZ(std::string as);
	float Result(std::string as);
};

int Priority(char symbol)
{
	switch (symbol)
	{
	case '^': return 3;
	case '*':
	case '/': return 2;
	case '+':
	case '-': return 1;
	default: return -1;
	}
}

bool operator<(const Stack::Node& item1, const char& info2)
{
	int data1 = Priority(item1.info);
	int data2 = Priority(info2);
	if (data1 < data2)
	{
		return true;
	}
	else
	{
		return false;
	}
}

Stack::Stack()
{
	head = NULL;
	headf = NULL;
}

void Stack::Input(char str)
{
	Node* item = new Node(str, head);
	head = item;
}

char Stack::Output()
{
	char data = head->info;
	Node* item = head;
	head = item->next;
	delete item;
	return data;
}

void Stack::InputF(float str)
{
	NodeF* item = new NodeF(str, headf);
	headf = item;
}

float Stack::OutputF()
{
	float data = headf->info;
	NodeF* item = headf;
	headf = item->next;
	delete item;
	return data;
}

char Stack::Top()
{
	return head->info;
}

std::string Stack::ToOPZ(std::string s)
{
	std::string str = "";
	for (int i = 0; i < s.length(); i++)
	{
		if ((s[i] > 47 && s[i] < 59) || s[i] == '.' || s[i] == '+' ||
			s[i] == '-' || s[i] == '/' || s[i] == '*' ||
			s[i] == '^' || s[i] == '(' || s[i] == ')')
		{
			if ((s[i] > 47 && s[i] < 59) || s[i] == '.')
			{
				while ((s[i] > 47 && s[i] < 59) || s[i] == '.')
				{
					str += s[i];
					i++;
				}
				str += " ";
				i--;
			}
			else
			{
				if (head == NULL)
				{
					Input(s[i]);
				}
				else
				{
					if (*(head) < s[i] || s[i] == '(')
					{
						Input(s[i]);
					}
					else
					{
						if (s[i] != ')')
						{
							str += Output();
							str += " ";
							Input(s[i]);
						}
						else
						{
							do
							{
								str += Output();
								str += " ";
							} while (head != NULL && Top() != '(');

							if (head != NULL)
							{
								Output();
							}
						}
					}
				}
			}
		}
	}
	while (head != NULL)
	{
		str += Output();
	}
	return str;
}

float Stack::Result(std::string s)
{
	for (int i = 0; i < s.length(); i++)
	{
		std::string str = "";
		if ((s[i] > 47 && s[i] < 59) || s[i] == '.')
		{
			while ((s[i] > 47 && s[i] < 59) || s[i] == '.')
			{
				str += s[i];
				i++;
			}
			InputF(stof(str));
		}
		float a;
		switch (s[i])
		{
		case '^':
			a = OutputF();
			InputF(powf(OutputF(), a));
			break;
		case '*':
			InputF(OutputF() * OutputF());
			break;
		case '/':
			a = OutputF();
			InputF(OutputF() / a);
			break;
		case '+':
			InputF(OutputF() + OutputF());
			break;
		case '-':
			a = OutputF();
			InputF(OutputF() - a);
			break;
		}
	}
	return OutputF();
}

Stack* stack = new Stack();

BSTR ToOpz(BSTR str)
{
	std::wstring wstr = std::wstring(str);
	std::string strString = std::string(wstr.begin(), wstr.end());
	std::string result = stack->ToOPZ(strString);
	std::wstring wresult = std::wstring(result.begin(), result.end());
	return SysAllocString(wresult.c_str());	
}

float OPZ(BSTR str)
{
	std::wstring wstr = std::wstring(str);
	std::string strString = std::string(wstr.begin(), wstr.end());
	return stack->Result(stack->ToOPZ(strString));
}
