using UnityEngine;
using System.Collections;

public abstract class GridMap : MonoBehaviour {
	public Coord size;

	public float BlockWidth;
	public float BlockHeight;

	[HideInInspector]
	public Vector3[,] Map;

	public abstract void CreateGrid();
	public abstract Coord WorldToLocal(Vector3 _worldPosition);

	public Vector3 GetPosition(Coord coord){
		return Map[coord.x, coord.y];
	}

	public bool Contains(Coord coord){
		if (coord.x < 0 || coord.y < 0 || coord.x >= size.x || coord.y >= size.y )
			return false;

		return true;
	}
}
