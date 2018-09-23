using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour {

    public Monster monster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.layer == 9) monster.OnHit(other);
        
    }
}
