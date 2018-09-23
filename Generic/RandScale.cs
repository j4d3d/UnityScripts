using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandScale : MonoBehaviour {

    public float min = 0.5f;
    public float range = 1f;
	
	void Start () {
        float scale = min + Random.value * range;
        transform.localScale = new Vector3(scale, scale, scale);
	}
}
