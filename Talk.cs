using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {

    public AudioSource asrc;

    public Vector3 baseRot;
    public Vector3 talkRot = new Vector3(30, 0, 0);
    public float lerp = 1f;
    public float min = 10f;

    float lvol = 0;


	void Start () {
        baseRot = transform.localRotation.eulerAngles;
	}
	
	void Update () {
        float[] data = new float[64];
        asrc.GetSpectrumData(data, 0, FFTWindow.Triangle);
        float vol = 0;
        for (int i = 0; i < data.Length; i++) vol += data[i];
        vol /= 64;
        //lerp
        vol = (lvol * lerp + vol) / (lerp + 1);
        lvol = vol;
        //go
        transform.localRotation = Quaternion.Euler(baseRot + talkRot * vol * 30);
	}
}
