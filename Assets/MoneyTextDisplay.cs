using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextDisplay : MonoBehaviour {

	public FloatProperty gold;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gold.value > 0)
		text.text=Mathf.Round(gold.value)+"$";
		else text.text = "";
	}
}
