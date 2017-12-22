using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]

public class ToggleMap : MonoBehaviour {

	public Image[] mapImage;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Toggle_Map"))
		{
			for (int i = 0 ; i < mapImage.Length ; i++)
				mapImage[i].enabled = !mapImage[i].enabled;
		}
	}
}