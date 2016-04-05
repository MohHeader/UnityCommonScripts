using UnityEngine;
using System.Collections;
public class CameraShake : MonoBehaviour {
	public float shake_decay;
	public float shake_intensity;

	private bool shaking;
	private Vector3 originPosition;
	private Quaternion originRotation;

	void Update (){
		if(!shaking)
			return;
		if (shake_intensity > 0f){
			transform.localPosition = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.localRotation = new Quaternion(
				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		} else {
			shaking = false;
			transform.localPosition = originPosition;
			transform.localRotation = originRotation;
		}
	}

	public void Shake(){
		if(!shaking) {
			originPosition = transform.localPosition;
			originRotation = transform.localRotation;
		}
		shaking = true;
		shake_intensity = .07f;
		shake_decay = 0.004f;
	}
}