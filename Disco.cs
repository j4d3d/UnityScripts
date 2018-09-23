using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Disco : MonoBehaviour {

    public PostProcessingProfile ppp;
    public AudioSource asrc;
    public float speed = 1f;
    public float amp = 1f;

    public float phase = 0f;
    public float signal = 0f;
    public float decay = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float[] data = new float[64];// asrc.GetSpectrumData(64, 0, FFTWindow.Triangle);
        asrc.GetSpectrumData(data, 0, FFTWindow.Triangle);

        float shift = 0;
        for (int i=0; i<data.Length; i++) {
            shift += Mathf.Pow(data[i], 2) * amp;
        } Debug.Log("shit: "+shift);
        if (shift > signal) signal = shift;

        ColorGradingModel.Settings settings = ppp.colorGrading.settings;
        phase += Mathf.Pow(signal, 2) * speed;
        settings.basic.saturation = 1 + signal;
        settings.basic.hueShift = phase + signal * 180;
        settings.basic.postExposure = -1 + signal * amp;// val + shift * speed;
        ppp.colorGrading.settings = settings;

        signal -= Time.deltaTime * decay * signal;
    }
}
