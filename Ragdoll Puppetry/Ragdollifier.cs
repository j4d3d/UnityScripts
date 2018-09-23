using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdollifier : MonoBehaviour {

    public float capsuleRadius = 0.5f;
    public float jointSpring = 1f;
    public float totalMass = 1f;
	// Use this for initialization
	void Start () {
        attachChildren(transform);
        // calculate and assign mass
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody body in bodies) body.mass = totalMass / bodies.Length;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void attachChildren(Transform parent)
    {
        Rigidbody parentBody = parent.GetComponent<Rigidbody>();
        if (parentBody == null) parentBody = parent.gameObject.AddComponent<Rigidbody>();
        foreach (Transform child in parent)
        {
            Rigidbody childBody = child.gameObject.AddComponent<Rigidbody>();
            ConfigurableJoint cj = child.gameObject.AddComponent<ConfigurableJoint>();

            // setup joint
            cj.xMotion = ConfigurableJointMotion.Locked;
            cj.yMotion = ConfigurableJointMotion.Locked;
            cj.zMotion = ConfigurableJointMotion.Locked;
            JointDrive jd = cj.angularXDrive;
            jd.positionSpring = jointSpring;
            cj.angularXDrive = cj.angularYZDrive = jd;
            cj.connectedBody = parentBody;

            // if name starts with 'x', no capsule collider!
            if (!child.name.StartsWith("x"))
            {
                if (child.childCount > 0)
                {
                    float boneLength = child.GetChild(0).localPosition.magnitude;
                    CapsuleCollider cap = child.gameObject.AddComponent<CapsuleCollider>();
                    cap.direction = 0; // x axis
                    cap.center = new Vector3(boneLength / -2, 0, 0);
                    cap.height = boneLength;
                    cap.radius = capsuleRadius;
                }
            }

            // attach children's children
            if (child.childCount > 0) attachChildren(child);
        }
    }
}
