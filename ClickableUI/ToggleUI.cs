using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Toggle))]
[RequireComponent(typeof(SpriteRenderer))]
public class ToggleUI : MonoBehaviour {
	public Sprite On;
	public Sprite Off;

	private Toggle toggle;
	private SpriteRenderer spR;
	void Awake(){
		spR = GetComponent<SpriteRenderer> ();
		toggle = GetComponent<Toggle> ();
		toggle.ToggleEvent += delegate(bool state) {
			spR.sprite = state ? On : Off;
		};
	}
}
