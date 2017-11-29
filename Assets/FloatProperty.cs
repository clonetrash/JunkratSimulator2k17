using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class FloatProperty : ScriptableObject {

	public float value;
	public static implicit operator float (FloatProperty f) {
		return f.value;
	}
	
}
