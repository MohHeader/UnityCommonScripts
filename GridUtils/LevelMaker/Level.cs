using UnityEngine;
using System.Collections;

namespace GridMaker
{
	public class Level<C>: ScriptableObject where C : GridMaker.CellData
	{
		public int columns;
		public int rows;
		public C[] data;
	}
}
