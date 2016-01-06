using UnityEngine;
using System.Collections;

public class ToggleGroup : MonoBehaviour {
	private Toggle[] toggles;
	private Toggle Current;

	void Awake () {
		toggles = GetComponentsInChildren<Toggle> ();
	}

	public void ToggleTo(Toggle toggle){
		Current = toggle;
		foreach (Toggle t in toggles) {
			if (t != Current)
				t.SetToggle (false);
		}

		Current.SetToggle (true);
	}

	public string GetCurrentToggleData(){
		return Current.GetData ();
	}
}
