using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

	public Material bagMat ;
	public FloatProperty gold ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bagMat.SetFloat ("_BagFullness" , 1-(1/(1+gold.value/1000)));
	}
}
