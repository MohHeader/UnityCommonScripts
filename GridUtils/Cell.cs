using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Cell : MonoBehaviour {
	public Coord coord;
	private GridMaker.CellData data;

	public GridMaker.CellData Data{
		get{ return data; }
		set{ data = value; }
	}
}
