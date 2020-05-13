using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static WindowsFormsApp1.Calculator;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string operation = "";
        public string firstNumber = "";
        public bool isEquallyPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if(isEquallyPressed)
            {
                textBox1.Text = "0";
                isEquallyPressed = false;
            }
            Button buttonsWithNumbers = (Button)sender;
            if(textBox1.Text == "0")
            {
                textBox1.Text = buttonsWithNumbers.Text;
            }
            else
            {
                textBox1.Text += buttonsWithNumbers.Text;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Button buttonWithOperation = (Button)sender;
            operation = buttonWithOperation.Text;
            firstNumber = textBox1.Text;
            textBox1.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            firstNumber = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if(textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if(!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(textBox1.Text);
            number = -number;
            textBox1.Text = number.ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            isEquallyPressed = true;
            if(firstNumber != "")
            {
                double numberOne = Convert.ToDouble(firstNumber);
                double numberTwo = Convert.ToDouble(textBox1.Text);
                double result = 0;
                if (operation == "+")
                {
                    result = Plus(numberOne, numberTwo);
                }
                if (operation == "−")
                {
                    result = Minus(numberOne, numberTwo);
                }
                if (operation == "×")
                {
                    result = Multiplication(numberOne, numberTwo);
                }
                if (operation == "÷")
                {
                    result = Devision(numberOne, numberTwo);
                }
                if (operation == "%")
                {
                    result = Mod(numberOne, numberTwo);
                }
                textBox1.Text = result.ToString();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            double result = Ln(Convert.ToDouble(textBox1.Text));
            textBox1.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double result = SquareRoot(Convert.ToDouble(textBox1.Text));
            textBox1.Text = result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double result = Squared(Convert.ToDouble(textBox1.Text));
            textBox1.Text = result.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double result = MuttuallyInverse(Convert.ToDouble(textBox1.Text));
            textBox1.Text = result.ToString();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            double result = Sin(Convert.ToDouble(textBox1.Text));
            textBox1.Text = result.ToString();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            double result = Cos(Convert.ToDouble(textBox1.Text));
            textBox1.Text = result.ToString();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            double result = Tg(Convert.ToDouble(textBox1.Text));
            textBox1.Text = result.ToString();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            double number;
            if(Double.TryParse(textBox2.Text, out number) && Double.TryParse(textBox3.Text, out number) && Double.TryParse(textBox4.Text, out number))
            {
                textBox5.Text = SolveQuadraticEquation(Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text));
            }
            else
            {
                textBox5.Text = "Введите числа";
            }            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            int numberOne, numberTwo;
            if(Int32.TryParse(textBox8.Text, out numberOne) && Int32.TryParse(textBox6.Text, out numberTwo))
            {
                long result = binpow(numberOne, numberTwo);
                textBox9.Text = result.ToString();
            }
            else
            {
                textBox9.Text = "Введите два целых числа";
            }                
        }

        private void button31_Click(object sender, EventArgs e)
        {
            double radius;
            if (Double.TryParse(textBox7.Text, out radius))
            {
                double result = BallVolume(radius);
                textBox10.Text = result.ToString();
            }
            else
            {
                textBox10.Text = "Введите число";
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox12.Text = ToOpz(textBox11.Text);
            textBox13.Text = OPZ(textBox11.Text.ToString()).ToString();
        }
    }
}
