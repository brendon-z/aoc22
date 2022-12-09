public class Position
{
    private int x = 0;
    private int y = 0;

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }

    public void updatePos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override String ToString()
    {
        return x + " " + y;
    }
}