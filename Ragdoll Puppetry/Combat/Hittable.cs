using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Tells a monster when a part of it has been hit by the weapon (layerMask: 9) */
public class Hittable : MonoBehaviour {

    public Monster monster; // set by the monster script itself

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == 9) monster.OnHit(other);
    }
}
