#nullable disable

using System.Text.RegularExpressions;

public static class five
{
    private static int stackNumber;
    private static List<Stack<String>> stacks = new List<Stack<string>>();

    public static void Main(string[] args)
    {
        
        Console.WriteLine("How many stacks? ");
        stackNumber = Convert.ToInt32(Console.ReadLine());
        createStacks();

        Console.WriteLine("Multiple at once? If so, type \"y\" please ");
        String input = Console.ReadLine();
        Boolean multiple = input.Equals("y") || input.Equals("Y");

        String[] instructions = File.ReadAllLines("input.txt");
        moveAround(instructions, multiple);
        Console.WriteLine(getMessage());
    }

    public static void createStacks()
    {
        for (int i = 0; i < stackNumber; i++)
        {
            Console.WriteLine("Input contents of stack, bottom - up, separated by commas:");
            String stackContents = Console.ReadLine();
            Stack<String> newStack = new Stack<String>();

            for (int j = 0; j < stackContents.Split(",").Length; j++)
            {
                newStack.Push(stackContents.Split(",")[j]);
            }

            stacks.Add(newStack);
        }
    }

    public static void moveAround(String[] instructions, Boolean multiple) {
        for (int i = 0; i < instructions.Count(); i++)
        {
            String[] numbers = Regex.Split(instructions[i], @"\D+");

            if (multiple)
            {
                Stack<String> crates = new Stack<String>();
                for (int j = 0; j < Convert.ToInt32(numbers[1]); j++)
                {
                    crates.Push(stacks[Convert.ToInt32(numbers[2]) - 1].Pop());
                }

                for (int j = 0; j < Convert.ToInt32(numbers[1]); j++)
                {
                    stacks[Convert.ToInt32(numbers[3]) - 1].Push(crates.Pop());
                }
            } else {
                for (int j = 0; j < Convert.ToInt32(numbers[1]); j++)
                {
                    String crate = stacks[Convert.ToInt32(numbers[2]) - 1].Pop();
                    stacks[Convert.ToInt32(numbers[3]) - 1].Push(crate);
                }
            }
        }
    }

    public static String getMessage() {
        return stacks.Select(stack => stack.Pop()).Aggregate("", (curr, next) => curr + next);
    }
}