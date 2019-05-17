using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVector
{
	public int X
	{
		get { return x; }
		set
		{
			x = Mathf.Clamp(value, -2, 2);
			if (x != value)
			{
				//Debug.LogWarning("Tried to set GridVector x to " + value);
			}
		}
	}
	public int Y
	{
		get { return y; }
		set
		{
			y = Mathf.Clamp(value, 0, int.MaxValue);
			if (y != value)
			{
				//Debug.LogWarning("Tried to set GridVector y to " + value);
			}
		}
	}

	private int x;
	private int y;

    public GridVector(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}

	public static GridVector operator +(GridVector a, GridVector b)
	{
		return new GridVector(a.X + b.X, a.Y + b.Y);
	}

	public static GridVector operator -(GridVector a, GridVector b)
	{
		return new GridVector(a.X - b.X, a.Y - b.Y);
	}

	public static bool operator ==(GridVector a, GridVector b)
	{
		if (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null))
		{
			return true;
		}

		if (object.ReferenceEquals(null, a) || object.ReferenceEquals(null, b))
		{
			return false;
		}
		
		return (a.X == b.X && a.Y == b.Y);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
			return false;
		if (this.GetType() != obj.GetType()) return false;

		if (object.ReferenceEquals(obj, null) && object.ReferenceEquals(this, null))
		{
			return true;
		}

		if (object.ReferenceEquals(null, obj) || object.ReferenceEquals(null, this))
		{
			return false;
		}

		GridVector vector = (GridVector)obj;
		return (vector.X == this.X && vector.Y == this.Y);
	}

	public static bool operator !=(GridVector a, GridVector b)
	{
		if (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null))
		{
			return false;
		}

		if (object.ReferenceEquals(null, a) || object.ReferenceEquals(null, b))
		{
			return true;
		}

		return (a.X != b.X || a.Y != b.Y);
	}

	public static explicit operator Vector2(GridVector gridVector)
	{
		Vector2 vector2 = new Vector2(gridVector.X, gridVector.Y);
		return vector2;
	}

	public override int GetHashCode() //no idea what this part does, lolz
	{
		unchecked
		{
			const int HashingBase = (int)2166136261;
			const int HashingMultiplier = 16777619;

			int hash = HashingBase;
			hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, X) ? X.GetHashCode() : 0);
			hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Y) ? Y.GetHashCode() : 0);
			return hash;
		}
	}
}
