using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monster : MonoBehaviour {

    public static int killCount = 0;
    public float maxHealth = 666;
    public float health;
    public float pitchMin = 0.3f;
    public float pitchRange = 0.7f;
    public bool invertPitch = false;

    public AudioSource hitASrc = null; // plays when hit
    public Transform deathSplosion = null;
    public Transform splosionOrigin = null;
    public ParticleSystem hitParticle = null;

    Schwing schwing;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        schwing = GameObject.Find("Schwing").GetComponent<Schwing>();

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
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void OnHit(Collision other) {
        float damage = other.relativeVelocity.magnitude;
        health -= damage;

        // die
        if (health < 0) {
            killCount++;
            GameObject.Find("KillCount").GetComponent<Text>().text = ""+killCount;
            if (deathSplosion != null) {
                Transform splosion = Instantiate(deathSplosion, splosionOrigin.position, Quaternion.identity) as Transform;
                splosion.localScale = transform.localScale;
                schwing.wbody.AddExplosionForce(1690f, transform.position, 10f);
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

            //if (!hitASrc.isPlaying)
                hitASrc.Play();

            /*if (hitParticle != null) {
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.startColor = Color.red;
                for (int i = 0; i < other.contacts.Length; i++) {
                    emitParams.startSize = Mathf.Sqrt(damage) / 10f;
                    emitParams.position = other.contacts[i].point;
                    for (int j=0; j<3; j++) hitParticle.Emit(emitParams, 10);
                }
            }*/
        }
        
    }
}