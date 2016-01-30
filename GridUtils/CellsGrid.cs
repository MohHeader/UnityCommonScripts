using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof (GridMap))]
public class CellsGrid : MonoBehaviour {
	protected GridMap map;
	public Cell[,] Cells;

	public GameObject CellPrefap;

	public event System.Action<Cell> InstantiateCallBack;

	public virtual void Awake(){
		map = GetComponent<GridMap> ();
	}

	public virtual void PopulateGrid(){
		map.CreateGrid ();

		Cells = new Cell[map.size.x, map.size.y];

		for (int x = 0; x < map.size.x; x++) {
			for (int y = 0; y < map.size.y; y++) {
				InstantiateBlock(x, y);
			}
		}
	}

	public void InstantiateBlock(int x, int y){
		GameObject block;
		block = Instantiate(CellPrefap);
		Cells [x, y] = block.GetComponent<Cell> ();
		block.transform.parent = transform;
		block.transform.localPosition = map.Map[x,y];
		Cells [x, y].coord = new Coord (x,y);

		if (InstantiateCallBack != null)
			InstantiateCallBack (Cells [x, y]);
	}

	public void Clear(){
		if (Cells == null)
			return;

		foreach (Cell cell in Cells) {
			if(cell != null)
				Destroy (cell.gameObject);
		}
	}

	public Cell GetCell(Coord coord){
		if (Contains(coord) == false)
			return null;

		return Cells[coord.x, coord.y];
	}

	//North, East, South, West
	public List<Cell> GetDirectNeighbors(Coord coord){
		List<Cell> neighbors = new List<Cell>();
		for (int x = coord.x - 1; x <= coord.x + 1; x++) {
			for (int y = coord.y - 1; y <= coord.y + 1; y++) {
				if (x != coord.x && y != coord.y)
					continue;
				Coord otherCoord = new Coord (x,y);
				if(Contains(otherCoord) && !coord.Equals(otherCoord)){
					neighbors.Add (GetCell(otherCoord));
				}
			}
		}
		return neighbors;
	}

	// N, E, S, W, NE, NW, SE, SW
	public List<Cell> GetNeighbors(Coord coord){
		List<Cell> neighbors = new List<Cell>();
		for (int x = coord.x - 1; x <= coord.x + 1; x++) {
			for (int y = coord.y - 1; y <= coord.y + 1; y++) {
				Coord otherCoord = new Coord (x,y);
				if(Contains(otherCoord) && !coord.Equals(otherCoord)){
					neighbors.Add (GetCell(otherCoord));
				}
			}
		}
		return neighbors;
	}

	public bool Contains(Coord coord){
		if (coord.x < 0 || coord.y < 0 || coord.x >= map.size.x || coord.y >= map.size.y )
			return false;

		return true;
	}

	public GridMap GetMap(){
		return map;
	}
}
