using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour {
	public event System.Action HoldEvent;
	public event System.Action ActionEvent;
	public event System.Action StartEvent;
	public event System.Action EndEvent;

	public event System.Action<bool> ActivateEvent;
	public bool isActive;
	private bool isMouseOver;

	void OnMouseDown(){
		if (!isActive)
			return;
		
		if (StartEvent != null)
			StartEvent ();
	}

	void OnMouseDrag(){
		if (!isActive)
			return;
		
		if (HoldEvent != null)
			HoldEvent ();
	}

	void OnMouseUp(){
		if (!isActive)
			return;

		if (EndEvent != null)
			EndEvent ();
		
		if (ActionEvent != null && isMouseOver)
			ActionEvent ();
	}

	public void SetCliackable(bool _isActive){
		isActive = _isActive;

		if (ActivateEvent != null)
			ActivateEvent (isActive);
	}

	public bool IsActive(){
		return isActive;
	}

	void OnMouseEnter() {
		isMouseOver = true;
	}

	void OnMouseExit() {
		isMouseOver = false;
	}
}
