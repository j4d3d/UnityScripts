using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    public Transform target = null;
    public float speed = 5f;
    // moves at angle towards target plus Sin(time*angSpeed)*angAmp
    public float angAmp = 40f;
    public float angSpeed = 1f;

    public Rigidbody head, lfoot, rfoot;
    public float buoyancy = 420f;
    public float stepForce = 300f;
    public float footWeight = 200f;
    public float minDist = 3f;
    // leave at -1 to not set anything
    public float setDrag = -1f;
    public float setSpring = -1f;

    float phase;

    public float stepSpeed = 1;
	
	void Start () {

        phase = Random.value * Mathf.PI * 2;

        if (setDrag != -1)
        {
            Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody body in bodies)
            {
                body.drag = setDrag;
            }
        }

        if (setSpring != -1)
        {
            ConfigurableJoint[] cjs = GetComponentsInChildren<ConfigurableJoint>();
            if (cjs.Length > 0)
            {
                JointDrive drive = cjs[0].angularXDrive;
                drive.positionSpring = setSpring;
                foreach (ConfigurableJoint cj in cjs)
                {
                    cj.angularXDrive = drive;
                    cj.angularYZDrive = drive;
                }
            }
        }
    }

    
    void FixedUpdate () {
        head.AddForce(Vector3.up * Time.fixedDeltaTime * buoyancy);

        float signal = Mathf.Sin(Mathf.PI * 2 * Time.time * stepSpeed + phase);
        rfoot.AddForce(((Vector3.up * stepForce * signal) - Vector3.up * footWeight) * Time.fixedDeltaTime);
        lfoot.AddForce(((Vector3.up * stepForce * (-signal)) - Vector3.up * footWeight) * Time.fixedDeltaTime);

        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        dir.y = 0; 
        float dist = dir.magnitude;
        dir = dir.normalized;

        if (dist > minDist) head.AddForce(dir * Time.fixedDeltaTime * speed);
    }
}
