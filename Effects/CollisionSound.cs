using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {

    AudioSource asrc;
    Rigidbody body;

    public float minPitch = 0f;
    public float minVol = 0f;
    public float pitchMod = 1f;
    public float volMod = 1f;
    public float pitchRange = 5f;

    public float finalPitchMod = 1f;

    float lmag = 0;
    float signal = 0;
    public float signalDecay = 0.9f;

    public ParticleSystem ps = null;

    void Start()
    {
        asrc = GetComponent(typeof(AudioSource)) as AudioSource;
        body = GetComponent<Rigidbody>();

        ps = GetComponent<ParticleSystem>();
    }

    void Update() {
        signal -= Time.deltaTime * signalDecay * signal;    
    }

    void OnCollisionEnter(Collision other)
    {
        lmag = other.relativeVelocity.magnitude;

        if (asrc != null)
        {
            float hitvol = minVol + 1 - 1/(1 + (lmag * volMod));
            if (hitvol > signal) {
                signal = hitvol;
                asrc.pitch = minPitch + (1 - 1 / (1 + (lmag * pitchMod))) * pitchRange;
                asrc.Play();
            }
            asrc.volume = signal;

        }
    }
}
