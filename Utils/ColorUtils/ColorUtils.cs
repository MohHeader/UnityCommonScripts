using UnityEngine;
using System.Collections;

public class ColorUtils : MonoBehaviour {
	static Color[] colors = new Color[]{Color.blue, Color.red, Color.green, Color.yellow};

	public static Color Random(){
		return colors[UnityEngine.Random.Range(0, colors.Length)];
	}
}
