using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAngle : MonoBehaviour {

    public float lerp = 1f;
    public Transform target;
    
    void Update() {
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, lerp * Time.deltaTime);
    }
}
