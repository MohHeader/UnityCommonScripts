using UnityEngine;
using System.Collections;

public static class IntUtils {
	public static void Times(this int count, System.Action action)
	{
		for (int i = 0; i < count; i++)
		{
			action();
		}
	}
}
