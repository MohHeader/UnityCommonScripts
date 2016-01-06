using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof (GridMap))]
public class CellsGrid : MonoBehaviour {
	private GridMap map;
	public Cell[,] Cells;

	public GameObject CellPrefap;

	public event System.Action<Cell> InstantiateCallBack;

	void Awake(){
		map = GetComponent<GridMap> ();
	}

	public void PopulateGrid(){
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
		foreach (Cell cell in Cells) {
			if(cell != null)
				Destroy (cell.gameObject);
		}
	}

	public Cell GetCell(Coord coord){
		return Cells[coord.x, coord.y];
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
