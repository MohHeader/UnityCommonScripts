using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Draggable : MonoBehaviour {
	public Vector3 OriginalPosition;
	private Vector3 screenPoint;
	private Vector3 offset;

	[HideInInspector]
	public bool IsDraggable;
	List<DropZone> dropZones;


	void Awake(){
		dropZones = new List<DropZone> ();
		OriginalPosition = transform.position;
	}

	void Start(){
		IsDraggable = true;
	}

	void OnMouseDown()
	{
		if (!IsDraggable)
			return;
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		if (onDragStarted != null)
			onDragStarted (this);
	}

	void OnMouseDrag()
	{
		if (!IsDraggable)
			return;

		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		transform.position = curPosition;
	}

	void OnMouseUp(){
		if (!IsDraggable)
			return;
		
		if (dropZones.Count > 0 && onDragEnded != null){
			foreach (DropZone dropZone in dropZones) {
				if (onDragEnded (this, dropZone)) {
					IsDraggable = false;
					transform.position = dropZone.transform.position;
					return;
				}
			}
		}

		Reset ();
	}

	void Reset(){
		transform.position = OriginalPosition;
		if (onReset != null)
			onReset (this);
	}

	void OnTriggerEnter2D(Collider2D other) {
		DropZone dropZone = other.gameObject.GetComponent<DropZone> ();;
		if (dropZone != null)
			dropZones.Add (dropZone);
	}

	void OnTriggerExit2D(Collider2D other) {
		DropZone dropZone = other.gameObject.GetComponent<DropZone> ();;
		if (dropZone != null)
			dropZones.Remove (dropZone);
	}

	public delegate void OnDragStarted(Draggable self);
	public OnDragStarted onDragStarted;

	public delegate bool OnDragEnded(Draggable self, DropZone dropedOn);
	public OnDragEnded onDragEnded;

	public delegate void OnReset(Draggable self);
	public OnReset onReset;
}
