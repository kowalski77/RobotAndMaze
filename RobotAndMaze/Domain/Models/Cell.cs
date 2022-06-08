namespace RobotAndMaze.Domain.Models;

public class Cell
{
    public Cell(bool current, bool blocked, bool last)
    {
        this.Current = current;
        this.Blocked = blocked;
        this.Last = last;
    }

    public bool Current { get; private set; }

    public bool Blocked { get; private set; }

    public bool Last { get; private set; }

    public void SetCurrent(bool value)
    {
        this.Current = value;
        this.Blocked = false;
    }

    public void SetBlocked()
    {
        this.Current = false;
        this.Blocked = true;
    }

    public void SetLast()
    {
        this.Current = false;
        this.Blocked = false;
        this.Last = true;
    }
}