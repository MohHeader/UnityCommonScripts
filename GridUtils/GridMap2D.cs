using UnityEngine;
using System.Collections;

public class GridMap2D : GridMap {
	public Sprite block;

	// Use this for initialization
	public override void CreateGrid () {
		Map = new Vector3[size.x, size.y];
		BlockWidth = block.bounds.size.x;
		BlockHeight = block.bounds.size.y;
		for (int x = 0; x < size.x; x++) {
			for (int y = 0; y < size.y; y++) {
				InstantiateCell(x, y);
			}
		}
	}

	void InstantiateCell(int x, int y){
		Map [x, y] = new Vector3(-(BlockWidth * size.x / 2f) + (x+0.5f) * BlockWidth, -(BlockHeight * size.y / 2f) + (y+0.5f) * BlockHeight, 0);
	}

	void OnDrawGizmos() {
		float GizoBlockWidth = 1.0f;
		float GizoBlockHeight = 1.0f;
		Gizmos.color = Color.yellow;
		//Top
		Gizmos.DrawLine (transform.localPosition + new Vector3 (GizoBlockWidth * size.x / 2f, GizoBlockHeight * size.y / 2f, 0),
			transform.localPosition + new Vector3 (-GizoBlockWidth * size.x / 2f, GizoBlockHeight * size.y / 2f, 0));
		//Bottom
		Gizmos.DrawLine (transform.localPosition + new Vector3 (GizoBlockWidth * size.x / 2f, -GizoBlockHeight * size.y / 2f, 0),
			transform.localPosition + new Vector3 (-GizoBlockWidth * size.x / 2f, -GizoBlockHeight * size.y / 2f, 0));

		//Right
		Gizmos.DrawLine (transform.localPosition + new Vector3 (GizoBlockWidth * size.x / 2f, -GizoBlockHeight * size.y / 2f, 0),
			transform.localPosition + new Vector3 (GizoBlockWidth * size.x / 2f,  GizoBlockHeight * size.y / 2f, 0));

		//Left
		Gizmos.DrawLine (transform.localPosition + new Vector3 (-GizoBlockWidth * size.x / 2f, -GizoBlockHeight * size.y / 2f, 0),
			transform.localPosition + new Vector3 (-GizoBlockWidth * size.x / 2f, GizoBlockHeight * size.y / 2f, 0));
	}

}
