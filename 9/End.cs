public class End
{
    private Position pos;

    public End()
    {
        pos = new Position(0, 0);
    }

    public Position getPosition()
    {
        return pos;
    }

    public void updatePosition(int x, int y)
    {
        pos.updatePos(x, y);
    }

    public void updatePosition(Position pos)
    {
        this.pos = pos;
    }

}