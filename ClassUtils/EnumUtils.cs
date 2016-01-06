using System.Collections;
using System.Linq;

public static class EnumUtils {

	public static T Random<T> ()
	{
		var v = System.Enum.GetValues (typeof (T));
		return (T) v.GetValue (new System.Random ().Next(v.Length));
	}
}
