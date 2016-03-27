using UnityEngine;
using System.Collections;

public static class TransformUtils {
	public static void DestroyChildren(this Transform root) {
		int childCount = root.childCount;
		for (int i=0; i<childCount; i++) {
			GameObject.Destroy(root.GetChild(i).gameObject);
		}
	}
}
