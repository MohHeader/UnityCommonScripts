using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Clickable))]
public class ClickableUI : MonoBehaviour {
	public Sprite Clicked;
	public Sprite Disabled;

	private Sprite Normal;
	private SpriteRenderer spriteRenderer;
	private Clickable clickable;

	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		clickable = GetComponent<Clickable> ();
		Normal = spriteRenderer.sprite;

		clickable.StartEvent += delegate() {
			spriteRenderer.sprite = Clicked;
		};

		clickable.ActionEvent += delegate() {
			spriteRenderer.sprite = Normal;
		};

		clickable.ActivateEvent += delegate(bool _isActive) {
			spriteRenderer.sprite = _isActive ? Normal : Disabled;
		};
	}

	void Start(){
		spriteRenderer.sprite = clickable.IsActive() ? Normal : Disabled;
	}
}
