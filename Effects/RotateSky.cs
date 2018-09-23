using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour {

	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Random.value*360);
    }
}
