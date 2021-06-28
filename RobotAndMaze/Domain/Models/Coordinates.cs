namespace RobotAndMaze.Domain.Models
{
    public class Coordinates
    {
        public Coordinates(int xPosition, int yPosition, 
            bool blocked, bool current)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
            this.Blocked = blocked;
            this.Current = current;
        }

        public int XPosition { get; }

        public int YPosition { get; }

        public bool Blocked { get; internal set; }

        public bool Current { get; internal set; }

        public void SetCurrent()
        {
            this.Current = true;
        }
    }
}