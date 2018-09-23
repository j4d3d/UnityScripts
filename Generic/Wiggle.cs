using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour {

    public float amp = 30f;
    public float speed = 1f;

    float phase;
    Quaternion baseRot;

	// Use this for initialization
	void Start () {
        baseRot = transform.localRotation;
        phase = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = baseRot * Quaternion.Euler(
            Mathf.PerlinNoise(0, speed * Time.time + phase) * amp,
            Mathf.PerlinNoise(0.3333f, speed * Time.time + phase) * amp,
            Mathf.PerlinNoise(0.6667f, speed * Time.time + phase) * amp);
	}
}