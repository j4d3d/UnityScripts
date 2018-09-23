using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRot : MonoBehaviour {

	void Update () {
        transform.rotation = Quaternion.Euler(Random.insideUnitSphere * 360);
	}
}
