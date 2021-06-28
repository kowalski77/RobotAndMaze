namespace RobotAndMaze.Domain.Models
{
    public class Cell
    {
        public Cell(bool blocked, bool current)
        {
            this.Blocked = blocked;
            this.Current = current;
        }

        public bool Blocked { get; internal set; }

        public bool Current { get; internal set; }

        public bool Exit { get; internal set; }

        public void SetCurrent()
        {
            this.Current = true;
        }

        public void RemoveCurrent()
        {
            this.Current = false;
        }
    }
}