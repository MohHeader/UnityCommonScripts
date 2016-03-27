using UnityEngine;
using System.Collections;

public class RelativePosition : MonoBehaviour {

	public float margin;

	public float VerticalMargin;
	public float HorizontaltMargin;

	public Horizontal horizontal;
	public Vertical vertical;

	private float CameraAspectRatio = 0;

	// x
	public enum Horizontal{
		Right,
		Center,
		Left
	}

	// y
	public enum Vertical{
		Top,
		Center,
		Bottom
	}

	void Awake(){
		CameraAspectRatio = Camera.main.aspect;
		RePosition ();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.update += UpdateOnChangeAspectRatio;
		#endif
	}


	void UpdateOnChangeAspectRatio(){
		if (CameraAspectRatio != Camera.main.aspect) {
			CameraAspectRatio = Camera.main.aspect;
			RePosition ();
		}
	}

	[ContextMenu("RePosition")]
	public void RePosition(){
		Vector2 SpriteSize = new Vector2(0,0);

		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if (sprite != null) {
			SpriteSize.x = sprite.bounds.size.x / transform.localScale.x;
			SpriteSize.y = sprite.bounds.size.y / transform.localScale.y;
		}

		Vector3 world = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight
			, 0));

		float x = transform.position.x;
		float y = transform.position.y;

		switch (horizontal) {
		case Horizontal.Right:
			x = world.x - (SpriteSize.x*sprite.sprite.pivot.x) - margin - HorizontaltMargin;
			break;
		case Horizontal.Left:
			x = - world.x + (SpriteSize.x*sprite.sprite.pivot.x) + margin + HorizontaltMargin;
			break;
		case Horizontal.Center:
			x = margin + HorizontaltMargin;
			break;
		default:
			break;
		}

		switch (vertical) {
		case Vertical.Top:
			y = world.y - (SpriteSize.y*sprite.sprite.pivot.y) - margin - VerticalMargin;
			break;
		case Vertical.Bottom:
			y = - world.y + (SpriteSize.y*sprite.sprite.pivot.y) + margin + VerticalMargin;
			break;
		case Vertical.Center:
			y = margin + VerticalMargin;
			break;
		default:
			break;
		}

		transform.position = new Vector3 (x, y, transform.position.z);
	}

	[ContextMenu("GetPositionFromCurrent")]
	public void GetPositionFromCurrent(){
		margin = 0;

		Vector2 SpriteSize = new Vector2(0,0);

		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if (sprite != null) {
			SpriteSize.x = sprite.bounds.size.x / transform.localScale.x;
			SpriteSize.y = sprite.bounds.size.y / transform.localScale.y;
		}

		Vector3 world = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight
			, 0));

		float x = transform.position.x;
		float y = transform.position.y;

		switch (horizontal) {
		case Horizontal.Right:
			HorizontaltMargin = world.x - (SpriteSize.x*sprite.sprite.pivot.x) - x;
			break;
		case Horizontal.Left:
			HorizontaltMargin = world.x - (SpriteSize.x*sprite.sprite.pivot.x) + x;
			break;
		case Horizontal.Center:
			HorizontaltMargin = x;
			break;
		default:
			break;
		}

		switch (vertical) {
		case Vertical.Top:
			VerticalMargin = world.y - (SpriteSize.y*sprite.sprite.pivot.y) - y;
			break;
		case Vertical.Bottom:
			VerticalMargin = world.y - (SpriteSize.y*sprite.sprite.pivot.y) + y;
			break;
		case Vertical.Center:
			VerticalMargin = y ;
			break;
		default:
			break;
		}
	}
}
