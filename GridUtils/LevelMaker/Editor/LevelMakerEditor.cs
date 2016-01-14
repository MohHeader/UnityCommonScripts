using UnityEngine;
using UnityEditor;
using System.Collections;

namespace GridMaker{
	public abstract class LevelMakerEditor<T,Z> : Editor where T : Cell where Z : GridMaker.CellData {
		public enum BrushType
		{
			Single,
			HLine,
			VLine
		}
		protected LevelMaker<T,Z> levelMaker;

		public void OnEnable()
		{
			levelMaker = (LevelMaker<T,Z>) target;

			SceneView.onSceneGUIDelegate += GridUpdate;
		}

		public BrushType brushType;

		public override void OnInspectorGUI(){
			DrawDefaultInspector ();

			brushType = (BrushType) EditorGUILayout.EnumPopup ("Brush Type", brushType);

			if(GUILayout.Button("Clear"))
			{
				if(levelMaker.grid.Cells != null){
					foreach (T block in levelMaker.grid.Cells) {
						if(block != null)
							DestroyImmediate (block.gameObject);
					}
				}
				levelMaker.grid.Cells = new T[levelMaker.map.size.x, levelMaker.map.size.y];
				levelMaker.map.CreateGrid ();
			}

			if (GUILayout.Button ("Fill")) {
				for (int x = 0; x < levelMaker.map.size.x; x++) {
					for (int y = 0; y < levelMaker.map.size.y; y++) {
						levelMaker.InstateBlock (new Coord(x,y));
					}
				}
			}

			if(GUILayout.Button("Save"))
			{
				SaveLevel ();
			}
		}

		protected abstract void SaveLevel ();

		void GridUpdate(SceneView sceneview)
		{
			Event e = Event.current;

			if(e.isMouse && e.clickCount > 0){
				Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
				Vector3 mousePos = r.origin;

				Coord coord = levelMaker.map.WorldToLocal (mousePos);

				if (coord == null)
					return;

				switch (brushType) {
				case BrushType.HLine:
					levelMaker.InstateBlockLine (coord, true);
					break;
				case BrushType.VLine:
					levelMaker.InstateBlockLine (coord, false);
					break;
				case BrushType.Single:
				default:
					levelMaker.InstateBlock (coord);
					break;
				}


			}
		}
	}
}