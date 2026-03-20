public static class PostfixCalculator
{
    public static double Evaluate(string expression)
    {
        var stack = new Stack<double>();
        string[] tokens = expression.Split(' ');

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else if (IsOperator(token))
            {
                if (stack.Count < 2)
                    throw new InvalidOperationException("Invalid expression");

                double b = stack.Pop();
                double a = stack.Pop();
                double result = ApplyOperator(token, a, b);
                stack.Push(result);
            }
            else
            {
                throw new ArgumentException($"Unknown token: {token}");
            }
        }

        if (stack.Count != 1)
            throw new InvalidOperationException("Invalid expression");

        return stack.Pop();
    }

    private static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    private static double ApplyOperator(string op, double a, double b)
    {
        return op switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => b != 0 ? a / b : throw new DivideByZeroException(),
            _ => throw new ArgumentException($"Unknown operator: {op}")
        };
    }
}