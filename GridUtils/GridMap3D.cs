using UnityEngine;
using System.Collections;

public class GridMap3D : GridMap {
	// Use this for initialization
	public override void CreateGrid () {
		Map = new Vector3[size.x, size.y];
		for (int x = 0; x < size.x; x++) {
			for (int y = 0; y < size.y; y++) {
				InstantiateCell(x, y);
			}
		}
	}

	void InstantiateCell(int x, int y){
		Map [x, y] = new Vector3(-(BlockWidth * size.x / 2f) + (x+0.5f) * BlockWidth,0, -(BlockHeight * size.y / 2f) + (y+0.5f) * BlockHeight);
	}

	void OnDrawGizmos() {
		float GizoBlockWidth = BlockWidth;
		float GizoBlockHeight = BlockHeight;
		Gizmos.color = Color.yellow;
		//Top
		Gizmos.DrawLine (transform.localPosition + new Vector3 (GizoBlockWidth * size.x / 2f,0,  GizoBlockHeight * size.y / 2f),
			transform.localPosition + new Vector3 (-GizoBlockWidth * size.x / 2f,0, GizoBlockHeight * size.y / 2f));
		//Bottom
		Gizmos.DrawLine (transform.localPosition + new Vector3 (GizoBlockWidth * size.x / 2f,0, -GizoBlockHeight * size.y / 2f),
			transform.localPosition + new Vector3 (-GizoBlockWidth * size.x / 2f,0, -GizoBlockHeight * size.y / 2f));

		//Right
		Gizmos.DrawLine (transform.localPosition + new Vector3 (GizoBlockWidth * size.x / 2f,0, -GizoBlockHeight * size.y / 2f),
			transform.localPosition + new Vector3 (GizoBlockWidth * size.x / 2f,0,  GizoBlockHeight * size.y / 2f));

		//Left
		Gizmos.DrawLine (transform.localPosition + new Vector3 (-GizoBlockWidth * size.x / 2f,0, -GizoBlockHeight * size.y / 2f),
			transform.localPosition + new Vector3 (-GizoBlockWidth * size.x / 2f,0, GizoBlockHeight * size.y / 2f));
	}

}
