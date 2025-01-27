using System;
using System.Collections.Generic;
using WindowsFormsApp1;
public class Mather
{
    public string InfixExpr { get; private set; }
    public string PostfixExpr { get; private set; }

    private readonly Dictionary<char, int> operationPriority = new() {
        {'(', 0},
        {'+', 1},
        {'-', 1},
        {'*', 2},
        {'/', 2},
        {'^', 3},
        {'~', 4},
        {',', 4}
    };

    public Mather(string expression)
    {
        InfixExpr = expression;
        PostfixExpr = ToPostfix(InfixExpr + "\r");
    }
    private string GetStringNumber(string expr, ref int pos)
    {
        string strNumber = "";

        for (; pos < expr.Length; pos++)
        {
            char num = expr[pos];


            if (Char.IsDigit(num))
                strNumber += num;
            else
            {
                pos--;
                break;
            }
        }

        return strNumber;
    }
    private string ToPostfix(string infixExpr)
    {
        string postfixExpr = "";

        Stack<char> stack = new();


        for (int i = 0; i < infixExpr.Length; i++)
        {

            char c = infixExpr[i];

            if (Char.IsLetter(c))
            {
                postfixExpr += c + " ";
            }


            if (Char.IsDigit(c))
            {

                postfixExpr += GetStringNumber(infixExpr, ref i) + " ";
            }

            else if (c == '(')
            {

                stack.Push(c);
            }

            else if (c == ')')
            {

                while (stack.Count > 0 && stack.Peek() != '(')
                    postfixExpr += stack.Pop();

                stack.Pop();
            }

            else if (operationPriority.ContainsKey(c))
            {

                char op = c;

                if (op == '-' && (i == 0 || (i > 1 && operationPriority.ContainsKey(infixExpr[i - 1]))))

                    op = '~';


                while (stack.Count > 0 && (operationPriority[stack.Peek()] >= operationPriority[op]))
                    postfixExpr += stack.Pop();

                stack.Push(op);
            }
        }

        foreach (char op in stack)
            postfixExpr += op;


        return postfixExpr;
    }
    private double Execute(char op, double first, double second) => op switch
    {
        '+' => first + second,
        '-' => first - second,
        '*' => first * second,
        '/' => first / second,
        '^' => Math.Pow(first, second),
        ',' => Double.Parse(first + "," + second),
        _ => 0
    };
    public double Calc()
    {

        Stack<double> locals = new();

        int counter = 0;


        for (int i = 0; i < PostfixExpr.Length; i++)
        {

            char c = PostfixExpr[i];

            if (char.IsLetter(c))
            {
                locals.Push(Form1.X);
            }

            if (Char.IsDigit(c))
            {

                string number = GetStringNumber(PostfixExpr, ref i);

                locals.Push(Convert.ToDouble(number));
            }

            else if (operationPriority.ContainsKey(c))
            {

                counter += 1;

                if (c == '~')
                {

                    double last = locals.Count > 0 ? locals.Pop() : 0;


                    locals.Push(Execute('-', 0, last));

                    Console.WriteLine($"{counter}) {c}{last} = {locals.Peek()}");

                    continue;
                }


                double second = locals.Count > 0 ? locals.Pop() : 0,
                first = locals.Count > 0 ? locals.Pop() : 0;


                locals.Push(Execute(c, first, second));

                Console.WriteLine($"{counter}) {first} {c} {second} = {locals.Peek()}");
            }
        }


        return locals.Pop();
    }
}