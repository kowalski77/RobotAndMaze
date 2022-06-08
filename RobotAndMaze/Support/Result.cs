namespace RobotAndMaze.Support;

public class Result
{
    protected Result(
        bool success,
        string error)
    {
        this.Success = success;
        this.Error = error;
    }

    public string Error { get; }

    public bool Success { get; }

    public static Result<T> Ok<T>(T value)
    {
        return new(value, true, string.Empty);
    }

    public static Result<T> Fail<T>(string error)
    {
        return new(default!, false, error);
    }
}