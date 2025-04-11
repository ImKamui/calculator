using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caluclator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "1";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "4";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "6";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "+" + richTextBox1.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "-";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string ourString = richTextBox1.Text;

            if (!string.IsNullOrEmpty(ourString))
            {
                ourString = ourString.Remove(ourString.Length - 1);
            }
            richTextBox1.Text = ourString;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string needText = richTextBox1.Text;
            richTextBox1.Text = Calculate(needText);
        }

        public string Calculate(string expression)
        {
            expression = expression.Replace(" ", "");
            List<int> numbers = new List<int>();
            List<char> operators = new List<char>();

            StringBuilder currentNumber = new StringBuilder();

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    currentNumber.Append(c);
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    if (currentNumber.Length > 0)
                    {
                        numbers.Add(int.Parse(currentNumber.ToString()));
                        currentNumber.Clear();
                    }
                    operators.Add(c);
                }
            }

            if (currentNumber.Length > 0)
            {
                numbers.Add(int.Parse(currentNumber.ToString()));
            }

            if (numbers.Count == 0)
                return "0";

            int result = numbers[0];

            for (int i = 0; i < operators.Count; i++)
            {
                if (i + 1 >= numbers.Count)
                    break;

                int nextNum = numbers[i + 1];

                switch (operators[i])
                {
                    case '+':
                        result += nextNum;
                        break;
                    case '-':
                        result -= nextNum;
                        break;
                    case '*':
                        result *= nextNum;
                        break;
                    case '/':
                        if (nextNum == 0)
                            return "Ошибка: На 0 делить нельзя";
                        result /= nextNum;
                        break;
                }
            }

            return result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "/";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "*";
        }
    }
}
