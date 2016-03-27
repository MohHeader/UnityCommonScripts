using UnityEngine;
using UnityEngine.UI;

public class AutoFixArabic : MonoBehaviour {
	void Awake(){
		Text text = GetComponent<Text> ();
		text.text = ArabicSupport.ArabicFixer.Fix (text.text);
	}
}
