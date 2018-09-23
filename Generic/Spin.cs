using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public Vector3 spin = Vector3.up;
	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
        transform.Rotate(spin * Time.deltaTime);
	}
}
