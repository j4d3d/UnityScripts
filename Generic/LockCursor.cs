using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour {

    bool locked = false;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Cancel")) {
            Cursor.lockState = CursorLockMode.None;
            locked = false;
        }

        if (!locked && Input.GetMouseButtonDown(0)) {
            Cursor.lockState = CursorLockMode.Locked;
            locked = true;
        }
	}
}
