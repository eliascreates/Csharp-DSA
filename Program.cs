namespace Csharp_DSA;

public class Program
{
    public static bool IsBalanced(String s)
    {
        if (string.IsNullOrEmpty(s))
            return true;

        var characterStack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(')
            {
                characterStack.Push(c);
            }
            else if (c == ')')
            {
                if (characterStack.Count == 0)
                {
                    return false;
                }
                characterStack.Pop();
            }
        }
        return true;
    }

    public static bool IsBalanced2(String s)
    {
        if (string.IsNullOrEmpty(s))
            return true;

        Stack<char> characterStack = new Stack<char>();
        Dictionary<char, char> pairs =
            new()
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
            };

        foreach (char c in s)
        {
            if (pairs.ContainsKey(c))
            {
                characterStack.Push(c);
            }
            else if (pairs.ContainsValue(c))
            {
                if (characterStack.Count == 0)
                {
                    return false;
                }
                char poppedValue = characterStack.Pop();

                if (c != pairs[poppedValue])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void Main(string[] args)
    {
        // question 1a
        String sentence1 = "3+4) *2";
        String sentence2 = "((3 + (2 * (4 - 1))) / (7 - (5 + 1)))";
        String sentence3 = "(3 + (2 * (4 - 1))) / (7 - (5 + 1)))";
        String sentence4 = "the rain in Spain stays (mainly) on the plane";
        String sentence5 = "the rain in Spain stays ((mainly) on the plane";
        String sentence6 = "the rain in Spain stays (mainly)) on the plane";
        String sentence7 = "the rain in Spain stays ((mainly))) on the plane";

        List<String> sentences = new List<String>
        {
            sentence1,
            sentence2,
            sentence3,
            sentence4,
            sentence5,
            sentence6,
            sentence7,
        };

        Console.WriteLine("\noutput for balanced:");
        sentences.ForEach(s => Console.WriteLine(IsBalanced(s) + ": " + s));

        // question 1b
        String sentence8 = "int[3] ints = { 8, 4, 3}; (does it work?) []";
        String sentence9 = "int[3] ints = { 8, 4, 3}; does it work?) []";
        String sentence10 = "{(([]))}";
        String sentence11 = "{(([])})";
        String sentence12 = "{(}[)]";

        List<String> sentences2 = new List<string>
        {
            sentence8,
            sentence9,
            sentence10,
            sentence11,
            sentence12,
        };

        Console.WriteLine("\noutput for balanced2:");
        sentences2.ForEach(s => Console.WriteLine(IsBalanced2(s) + ": " + s));
    }
}
