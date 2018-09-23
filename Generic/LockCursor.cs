using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Lock and hide cursor on Start(), 'Escape' to unlock and mouse click to re-lock */
public class LockCursor : MonoBehaviour {

    bool locked = false;
	
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
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
