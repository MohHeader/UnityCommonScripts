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
		float GizmoBlockWidth = BlockWidth;
		float GizmoBlockHeight = BlockHeight;
		Gizmos.color = Color.yellow;
		for (int i = 0; i <= size.x; i++) {
			Gizmos.DrawLine (transform.localPosition + new Vector3 (-GizmoBlockWidth * size.x / 2f + GizmoBlockWidth * i, -GizmoBlockHeight * size.y / 2f, 0),
				transform.localPosition + new Vector3 (-GizmoBlockWidth * size.x / 2f + GizmoBlockWidth * i, GizmoBlockHeight * size.y / 2f, 0));
		}

		for (int i = 0; i <= size.y; i++) {
			Gizmos.DrawLine (transform.localPosition + new Vector3 (GizmoBlockWidth * size.x / 2f, -GizmoBlockHeight * size.y / 2f + GizmoBlockWidth * i, 0),
				transform.localPosition + new Vector3 (-GizmoBlockWidth * size.x / 2f, -GizmoBlockHeight * size.y / 2f + GizmoBlockWidth * i, 0));
		}
	}

	public override Coord WorldToLocal(Vector3 _worldPosition){
		float GizmoBlockWidth = BlockWidth;
		float GizmoBlockHeight = BlockHeight;
		if (_worldPosition.x <  GizmoBlockWidth * size.x / 2f && _worldPosition.x > -GizmoBlockWidth * size.x / 2f &&
			_worldPosition.y < GizmoBlockHeight * size.y / 2f && _worldPosition.y > -GizmoBlockHeight * size.y / 2f)
		{

			int x = Mathf.RoundToInt( (_worldPosition.x + (GizmoBlockWidth * size.x / 2f) - (0.5f* GizmoBlockWidth) )/ GizmoBlockWidth);
			int y = Mathf.RoundToInt( (_worldPosition.y + (GizmoBlockHeight * size.y / 2f) - (0.5f* GizmoBlockHeight) )/ GizmoBlockHeight);

			return new Coord (x, y);
		}
		return null;
	}

}
