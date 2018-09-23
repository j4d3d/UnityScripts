using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour {

    public static int killCount = 0;
    public float maxHealth = 666;
    public float health;
    // settings for the "ouch" sound effect
    public float pitchMin = 0.3f;
    public float pitchRange = 0.7f;
    public bool invertPitch = false;

    public AudioSource hitASrc = null; // plays when hit
    public Transform deathSplosion = null; // explosion prefab to spawn on death
    public Transform splosionOrigin = null; // which part of ragdoll for explosion to emanate from
    public ParticleSystem hitParticle = null;
	
	void Start () {
        health = maxHealth;

        if (hitParticle == null) hitParticle = GetComponent<ParticleSystem>();
        // add hittable to all children with colliders
        Component[] bods = GetComponentsInChildren<Rigidbody>();
        GameObject[] objs = new GameObject[bods.Length];
        for (int i=0; i<bods.Length; i++) {
            Debug.Log(bods.Length);

            Rigidbody bod = (Rigidbody)bods[i];
            objs[i] = bod.gameObject;

            Hittable hit = objs[i].AddComponent<Hittable>() as Hittable;
            hit.monster = this;
        }
    }

    public virtual void OnHit(Collision other) {
        float damage = other.relativeVelocity.magnitude;
        health -= damage;

        // die
        if (health < 0) {
            killCount++;
            if (deathSplosion != null) {
                Transform splosion = Instantiate(deathSplosion, splosionOrigin.position, Quaternion.identity) as Transform;
                splosion.localScale = transform.localScale;
                Destroy(gameObject);
            }
            return;
        }

        // adjust aSrc pitch and play ouch sound
        if (hitASrc != null) {
            // set pitch
            float pitch = (pitchRange * health / maxHealth);
            if (invertPitch) pitch = (pitchMin + pitchRange) - pitch;
            hitASrc.pitch = pitch;

            hitASrc.Play();
        }
    }
}