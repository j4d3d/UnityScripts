using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public Vector3 spin = Vector3.up;
	
	void Update () {
        transform.Rotate(spin * Time.deltaTime);
	}
}
