using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Clickable))]
public abstract class Toggle : MonoBehaviour {
	private bool state;
	private ToggleGroup group;

	public event System.Action<bool> ToggleEvent;

	private Clickable clickable;
	void Awake(){
		clickable = GetComponent<Clickable> ();
		group = GetComponentInParent<ToggleGroup> ();

		clickable.ActionEvent += delegate() {
			SetToggle(!state);

			if(group != null)
				group.ToggleTo(this);
		};
	}

	public void SetToggle(bool _state){
		state = _state;
		if(ToggleEvent != null)
			ToggleEvent(state);
	}

	public abstract string GetData();
}
