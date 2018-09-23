using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform target;
	
	void Update () {
        transform.LookAt(target);
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
	}
}
