using UnityEngine;
using System.Collections;

namespace GridMaker{
	public abstract class LevelMaker<T,Z> : MonoBehaviour where T : Cell where Z : GridMaker.CellData {
		public CellsGrid grid;
		public GridMap map;

		protected abstract GameObject PrepareCell (Z data);
		protected abstract Z GetBrushData ();

		public void InstateBlock(Coord coord){
			if(grid.Cells[coord.x, coord.y]!= null){
				DestroyImmediate (grid.Cells[coord.x, coord.y].gameObject);
			}

			Z data = GetBrushData ();
			GameObject block = PrepareCell (data);

			block.transform.parent = transform;
			block.transform.localPosition = map.Map[coord.x, coord.y];

			T cell = block.GetComponent<T> ();

			cell.coord = coord;
			cell.Data = data;

			grid.Cells [coord.x, coord.y] = cell;
		}

		public Level<Z> SaveLevel(Level<Z> level){
			level.data = new Z[map.size.x*map.size.y];
			level.rows = map.size.y;
			level.columns = map.size.x;
			for (int x = 0; x < map.size.x; x++) {
				for (int y = 0; y < map.size.y; y++) {
					level.data [(x * map.size.y) + y] = (Z) grid.Cells[x,y].Data;
				}
			}
			return level;
		}
	}
}