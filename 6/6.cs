public static class six
{
    const int CHECKLENGTH = 4;
    const int MESSAGELENGTH = 14;
    public static void Main(string[] args)
    {
        var text = File.ReadAllText("input.txt");
        var counter1 = 0;
        List<char> checkBits = new List<char>();

        foreach (char c in text)
        {
            for (int i = 0; i < CHECKLENGTH; i++)
            {
                checkBits.Add(text[counter1 + i]);
            }

            if (checkBits.Distinct().Count() == CHECKLENGTH) break;
            checkBits.Clear();
            counter1++;
        }
        
        var counter2 = 0;
        List<char> messageBits = new List<char>();
        foreach (char c in text)
        {
            for (int i = 0; i < MESSAGELENGTH; i++)
            {
                messageBits.Add(text[counter2 + i]);
            }

            if (messageBits.Distinct().Count() == MESSAGELENGTH) break;
            messageBits.Clear();
            counter2++;
        }

        Console.WriteLine(counter1 + CHECKLENGTH);
        Console.WriteLine(counter2 + MESSAGELENGTH);
    }
}