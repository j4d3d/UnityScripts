using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchMod : MonoBehaviour {

    public float min = 0;
    public float range = 5;
    public float speed = 1;

    public AudioSource src;

	// Use this for initialization
	void Start () {
        src = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        src.pitch = min + range * Mathf.PerlinNoise(Time.time * speed, 0);
	}
}
