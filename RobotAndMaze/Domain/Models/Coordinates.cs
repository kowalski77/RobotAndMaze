using System;

namespace RobotAndMaze.Domain.Models;

public readonly struct Coordinates : IEquatable<Coordinates>
{
    public int XPos { get; init; }

    public int YPos { get; init; }

    public bool Equals(Coordinates other)
    {
        return this.XPos == other.XPos && this.YPos == other.YPos;
    }

    public override bool Equals(object? obj)
    {
        return obj is Coordinates other && this.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.XPos, this.YPos);
    }

    public static bool operator ==(Coordinates left, Coordinates right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Coordinates left, Coordinates right)
    {
        return !left.Equals(right);
    }
}