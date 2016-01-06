using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Clickable))]
public class ClickableAnimaiton : MonoBehaviour {
	private Clickable clickable;

	// Use this for initialization
	void Awake () {
		clickable = GetComponent<Clickable> ();

		clickable.StartEvent += delegate() {
			iTween.ScaleTo(gameObject, new Vector3(1.2f,1.2f,1.2f), 0.5f);
		};

		clickable.EndEvent += delegate() {
			iTween.ScaleTo(gameObject, new Vector3(1f,1f,1f), 0.5f);
		};
	}

}
