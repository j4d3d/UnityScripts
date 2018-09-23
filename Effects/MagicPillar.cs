using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPillar : MonoBehaviour {

    Transform[] children;
    Vector3[] basePos;
    Quaternion[] baseRot;
    Renderer[] renderers;
    Rigidbody[] bodies;

    bool vis = false, lvis = false;

    void Start() {
        int numKids = transform.GetChildCount();
        children = new Transform[numKids];
        basePos = new Vector3[numKids];
        baseRot = new Quaternion[numKids];
        renderers = new Renderer[numKids];
        bodies = new Rigidbody[numKids];

        //  index
        for (int i = 0; i < numKids; i++) {
            children[i] = transform.GetChild(i);
            renderers[i] = children[i].GetComponent<Renderer>();
            bodies[i] = children[i].GetComponent<Rigidbody>();
            basePos[i] = children[i].position;
            baseRot[i] = children[i].rotation;
        }
	}
	
	
	void Update () {
        vis = false;
		for (int i=0; i<children.Length; i++) {
            if (renderers[i].isVisible) {
                vis = true;
                break;
            }
        }

        // be magical
        if (vis) {
            if (!lvis) setFreeze(false);
        } else {
            if (lvis) {
                setFreeze(true);
                for (int i = 0; i < children.Length; i++)
                {
                    children[i].position = basePos[i];
                    children[i].rotation = baseRot[i];
                    bodies[i].velocity = Vector3.zero;
                    bodies[i].angularVelocity = Vector3.zero;
                }
            }
        } lvis = vis;
	}

    public void setFreeze(bool froze) { // gud grammar
        if (froze) for (int i=0; i<children.Length; i++)
            bodies[i].constraints = RigidbodyConstraints.FreezeAll;
        else for (int i = 0; i < children.Length; i++)
                bodies[i].constraints = RigidbodyConstraints.None;
    }
}
