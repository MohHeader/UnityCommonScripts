using UnityEngine;
using System.Collections;

[System.Serializable]
public class Coord : System.IEquatable<Coord>{
	public int x;
	public int y;

	public Coord(int _x, int _y){
		x = _x;
		y = _y;
	}

	public static Coord up {get{return new Coord (0, 1);}}
	public static Coord down {get{return new Coord (0, -1);}}
	public static Coord left {get{return new Coord (-1, 0);}}
	public static Coord right {get{return new Coord (1, 0);}}

	public static Coord operator +(Coord c1, Coord c2){
		return new Coord(c1.x + c2.x, c1.y + c2.y);
	}

	public override string ToString()
	{
		return "X:"+x+",Y:"+y;
	}

	public bool Equals( Coord other )
	{
		if (other == null) return false;
		return this.x == other.x && 
			this.y == other.y;
	}
}
