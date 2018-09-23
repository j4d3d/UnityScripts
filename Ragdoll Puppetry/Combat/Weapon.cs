using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* If other is a monster (layerMask: 10) then emit a 'hit' particle */
public class Weapon : MonoBehaviour {

    public float bloodPerVelocity = 10f;
    public float noise = 10f;
    public ParticleSystem ps = null;
	
	void Start () {
        if (ps == null) ps = GetComponent<ParticleSystem>();
	}

    void OnCollisionEnter(Collision other) {
        float damage = other.relativeVelocity.magnitude;

        if (ps != null && other.gameObject.layer == 10) {
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = Color.red;
            for (int i=0; i<other.contacts.Length; i++) {
                emitParams.startSize = damage;
                emitParams.position = other.contacts[i].point;
                Vector3 velocity = (other.relativeVelocity.normalized + Vector3.up) * Mathf.Sqrt(damage);

                // emit more particles if its a HARD hit
                int count = (int)Mathf.Ceil(velocity.magnitude / bloodPerVelocity);
                for (int p = 0; p < count; p++) {
                    emitParams.velocity = velocity + Random.insideUnitSphere * (1 - 1 / count) * noise;
                    ps.Emit(emitParams, 1);
                }
            }
        }
    }
}
