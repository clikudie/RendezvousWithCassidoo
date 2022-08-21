namespace MatchingParenthesis
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] patterns = { ")()(()))", "(()(", "((((", "))))", "", "(())))))(()" };
            for (int i = 0; i < patterns.Length; i++)
            {
                int count = MatchingParen(patterns[i]);
                Console.WriteLine("Longest valid parenthesis count for pattern {0}: {1}", patterns[i], count);
            }
        }

        public static int MatchingParen(string paren)
        {
            char[] parenArr = paren.ToCharArray();
            Stack<char> stack = new();

            int count = 0;
            for (int i = 0; i < parenArr.Length; i++)
            {
                if (parenArr[i] == '(')
                {
                    stack.Push(parenArr[i]);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        count += 2;
                        stack.Pop();
                    }
                }
            }

            return count;
        }
    }
}
