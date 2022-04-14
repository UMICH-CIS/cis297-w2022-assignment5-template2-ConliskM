using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorGUI
{
    class QuadraticEquation
    {
        int A;
        int B;
        int C;
        double Discriminant;
        double X1;
        double X2;
        Boolean status = true;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public QuadraticEquation(int a, int b, int c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        /// <summary>
        /// This function calculates the discriminant of the quadratic equation
        /// </summary>
        /// <returns></returns>
        public double ComputeDisc()
        {
            Discriminant = Math.Pow(B, 2) - 4 * A * C;
            return Discriminant;
        }

        /// <summary>
        /// After the ComputeDisc() has been called, this function will use the Discriminant
        /// field to calculate the roots of the equation, if there are any
        /// </summary>
        public void ComputeSolution()
        {
            if (Discriminant == 0)
            {
                X1 = -B / (2 * A);
                X2 = X1;
            }
            else if (Discriminant > 0)
            {
                X1 = (-B + Math.Sqrt(Discriminant)) / (2 * A);
                X2 = (-B - Math.Sqrt(Discriminant)) / (2 * A);
            }
            else
            {
                status = false;
            }
        }

        /// <summary>
        /// After ComputeSolution() has been called, this function will display the 
        /// roots of the equation, or tell the user there are no real roots
        /// </summary>
        public string DisplaySolution()
        {
            //Console.WriteLine($"Quadratic Equation with  A: {0}   B: {1}  C: {2}", A, B, C);
            if (status)
            {
                if (X1 == X2)
                {
                    X1 = (Math.Round(X1, 3));
                    return $"The equation has one root: {X1}";
                }
                else
                {
                    X1 = (Math.Round(X1, 3));
                    X2 = (Math.Round(X2, 3));
                    return $"Root X1 = {X1}, Root X2 = {X2}";
                }
            }
            else
            {
                return "Equation has no real roots!";
            }

        }
    }
}
