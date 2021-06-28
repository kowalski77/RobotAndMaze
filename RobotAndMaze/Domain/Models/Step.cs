namespace RobotAndMaze.Domain.Models
{
    public class Step
    {
        private Step(int value)
        {
            this.Value = value;
        }

        public int Value { get; }

        public static Step CreateInstance(int value)
        {
            return new(value);
        }
    }
}