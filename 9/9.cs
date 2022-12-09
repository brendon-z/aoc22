public static class eight
{
    public static void Main(string[] args)
    {
        List<Position> positionsVisited = new List<Position>();
        End head = new End();
        End tail = new End();
        var lines = File.ReadLines("input.txt");
        positionsVisited.Add(new Position(0,0));

        foreach (var line in lines)
        {
            int x = head.getPosition().getX();
            int y = head.getPosition().getY();
            String[] commands = line.Split(" ");

            switch (commands[0])
            {
                case "R":
                    for (int i = 0; i <= Convert.ToInt32(commands[1]); i++) {
                        Position oldHeadPos = head.getPosition();
                        Position newPos = new Position(x + i, y);
                        head.updatePosition(newPos);

                        if (!touching(head, tail)) {
                            tail.updatePosition(oldHeadPos);
                            positionsVisited.Add(tail.getPosition());
                            Console.Write("Added: ");
                        }
                        Console.WriteLine(tail.getPosition() + ", " + newPos);
                    }
                    break;
                case "L":
                    for (int i = 0; i <= Convert.ToInt32(commands[1]); i++) {
                        Position oldHeadPos = head.getPosition();
                        Position newPos = new Position(x - i, y);
                        head.updatePosition(newPos);

                        if (!touching(head, tail)) {
                            tail.updatePosition(oldHeadPos);
                            positionsVisited.Add(tail.getPosition());
                            Console.Write("Added: ");

                        }
                        Console.WriteLine(tail.getPosition() + ", " + newPos);
                    }
                    break;
                case "U":
                    for (int i = 0; i <= Convert.ToInt32(commands[1]); i++) {
                        Position oldHeadPos = head.getPosition();
                        Position newPos = new Position(x, y + i);
                        head.updatePosition(newPos);

                        if (!touching(head, tail)) {
                            tail.updatePosition(oldHeadPos);
                            positionsVisited.Add(tail.getPosition());
                            Console.Write("Added: ");

                        }
                        Console.WriteLine(tail.getPosition() + ", " + newPos);
                    }
                    break;
                case "D":
                    for (int i = 0; i <= Convert.ToInt32(commands[1]); i++) {
                        Position oldHeadPos = head.getPosition();
                        Position newPos = new Position(x, y - i);
                        head.updatePosition(newPos);

                        if (!touching(head, tail)) {
                            tail.updatePosition(oldHeadPos);
                            positionsVisited.Add(tail.getPosition());
                            Console.Write("Added: ");

                        }
                        Console.WriteLine(tail.getPosition() + ", " + newPos);
                    }
                    break;
                default:
                    return;
            }
        }

        int distinctVisited = positionsVisited.GroupBy(e => new { V1 = e.getX(), V2 = e.getY()}).Select(g => g.First()).Count();
        Console.WriteLine("Distinct positions visited: " + distinctVisited);
    }

    private static bool touching(End head, End tail) {
        Position headPos = head.getPosition();
        Position tailPos = tail.getPosition();

        return (Math.Abs(headPos.getX() - tailPos.getX()) <= 1) && (Math.Abs(headPos.getY() - tailPos.getY()) <= 1);
    }
}
