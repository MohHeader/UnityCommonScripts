using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArabicInputFieldFixer : MonoBehaviour {
	public Text FixedText;
	InputField input;

	void Awake(){
		input = GetComponent<InputField> ();
	}

	public void Fix(){
		FixedText.text = ArabicSupport.ArabicFixer.Fix (input.text);
	}
}
