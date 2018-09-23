using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : MonoBehaviour {

    public float lerp;
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target.position, lerp * Time.deltaTime);
	}
}
