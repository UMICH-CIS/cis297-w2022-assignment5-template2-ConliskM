using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculatorGUI
{
   public partial class CalculatorGUIForm : Form
   {
        public CalculatorGUIForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += " ^ ";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            char[] charArray = textBox1.Text.ToCharArray();
            Array.Reverse(charArray);
            string s = new string(charArray);
            textBox1.Text = s;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(" ", "");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += " * ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "log";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text += " M ";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "quad(";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            s = s.Replace(" ", "");

            // Quadratic Formula
            if (s.StartsWith("quad"))
            {
                string a, b, c;
                int x, y, z;

                // Parse arguments into separate strings
                a = s.Substring(5);
                b = a.Substring(a.IndexOf('/') + 1);
                c = b.Substring(b.IndexOf('/') + 1);
                a = a.Remove(a.IndexOf('/'));
                b = b.Remove(b.IndexOf('/'));
                if (c.IndexOf(')') != -1)
                {
                    c = c.Remove(c.Length - 1);
                }

                // Parse arguments into ints
                // If format is wrong, display error message
                if (!int.TryParse(a, out x))
                {
                    textBox1.Text = "Format error: arguments must be integers";
                    return;
                }
                if(!int.TryParse(b, out y))
                {
                    textBox1.Text = "Format error: arguments must be integers";
                    return;
                }
                if(!int.TryParse(c, out z))
                {
                    textBox1.Text = "Format error: arguments must be integers";
                    return;
                }

                QuadraticEquation quad = new QuadraticEquation(x, y, z);
                quad.ComputeDisc();
                quad.ComputeSolution();
                textBox1.Text = quad.DisplaySolution();
                return;
            }

            // Log function
            else if (s.StartsWith("log"))
            {
                double num;
                int logBase;
                string numStr;

                if (s.StartsWith("log("))
                {
                    s = s.Substring(4);
                    if (s.EndsWith(")")) 
                    {
                        s = s.Remove(s.Length - 1);
                    }
                    if (!double.TryParse(s, out num))
                    {
                        textBox1.Text = "Format error: number must numeral";
                        return;
                    }
                    num = Math.Log10(num);
                    num = Math.Round(num, 3);
                }
                else
                {
                    s = s.Substring(3);
                    numStr = s.Substring(s.IndexOf('(') + 1);
                    s = s.Remove(s.IndexOf('('));
                    if (numStr.EndsWith(")"))
                    {
                        numStr = numStr.Remove(numStr.Length - 1); 
                    }
                    if (!int.TryParse(s, out logBase))
                    {
                        textBox1.Text = "Format error: base must be an integer";
                        return;
                    }
                    if (!double.TryParse(numStr, out num))
                    {
                        textBox1.Text = "Format error: number must be numeral";
                        return;
                    }
                    num = Math.Log(num, logBase);
                    num = Math.Round(num, 3);

                }
                textBox1.Text = num.ToString();
                return;
            }

            // Handles all other operators
            else
            {
                string leftOperandStr, rightOperandStr;
                int opIndex;
                int leftOperand, rightOperand;
                double answer;
                if ((opIndex = s.IndexOf('/')) != -1)
                {
                    leftOperandStr = s.Substring(0, opIndex);
                    rightOperandStr = s.Substring(opIndex + 1);
                    if (!int.TryParse(leftOperandStr, out leftOperand))
                    {
                        textBox1.Text = "Format Error: left operand must be an integer";
                        return;
                    }
                    if (!int.TryParse(rightOperandStr, out rightOperand))
                    {
                        textBox1.Text = "Format Error: right operand must be an integer";
                        return;
                    }
                    answer = leftOperand / rightOperand;
                    int r = leftOperand % rightOperand;
                    s = $"Q: {answer}, R: {r}";
                    textBox1.Text = s;
                    return;
                }
                else if ((opIndex = s.IndexOf('^')) != -1)
                {
                    leftOperandStr = s.Substring(0, opIndex);
                    rightOperandStr = s.Substring(opIndex + 1);
                    if (!int.TryParse(leftOperandStr, out leftOperand))
                    {
                        textBox1.Text = "Format Error: left operand must be an integer";
                        return;
                    }
                    if (!int.TryParse(rightOperandStr, out rightOperand))
                    {
                        textBox1.Text = "Format Error: right operand must be an integer";
                        return;
                    }
                    answer = Math.Pow((double)leftOperand, (double)rightOperand);
                    textBox1.Text = answer.ToString();
                }
                else if ((opIndex = s.IndexOf('M')) != -1)
                {
                    leftOperandStr = s.Substring(0, opIndex);
                    rightOperandStr = s.Substring(opIndex + 1);
                    if (!int.TryParse(leftOperandStr, out leftOperand))
                    {
                        textBox1.Text = "Format Error: left operand must be an integer";
                        return;
                    }
                    if (!int.TryParse(rightOperandStr, out rightOperand))
                    {
                        textBox1.Text = "Format Error: right operand must be an integer";
                        return;
                    }
                    answer = Math.Min(leftOperand, rightOperand);
                    double answer2 = Math.Max(leftOperand, rightOperand);
                    textBox1.Text = $"Min: {answer}, Max {answer2}";
                    return;
                }
                else
                {
                    textBox1.Text = "Format error: invalid operand";
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += " / ";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }
    }
}

/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/