using UnityEngine;
using System.Collections;

public static class BoolUtils {
	public static bool Random(){
		return (UnityEngine.Random.value > 0.5f);
	}
}
