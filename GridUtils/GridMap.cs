using UnityEngine;
using System.Collections;

public abstract class GridMap : MonoBehaviour {
	public Coord size;

	public float BlockWidth;
	public float BlockHeight;

	[HideInInspector]
	public Vector3[,] Map;

	public abstract void CreateGrid();

	public Vector3 GetPosition(Coord coord){
		return Map[coord.x, coord.y];
	}
}
