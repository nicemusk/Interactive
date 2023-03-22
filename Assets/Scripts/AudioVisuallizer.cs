using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof ( AudioSource))]

public class AudioVisuallizer : MonoBehaviour
{

    [Space(15)]
    public AudioClip audioClip;
    public bool loop = true;

    public AudioSource _audioSource;
    [Space(15), Range(64, 8192)]
    public int visualizerSimples = 64;
    [Space(15), Range(0.0f, 1.0f)]
    public float _volume = 1.0f;
    [Space(15), Range(0.0f, 1.0f)]
    public float Sensitive = 0.0f;
    [Space(15), Range(0, 100)]
    public int _intensity = 1;

    public Light spotlight;

    AudioSource audioSource;
    Rigidbody cam;
    Transform _cam;
    public int force;

    private void Awake()
    {
        cam = GetComponent<Rigidbody>();
        _cam = GetComponent<Transform>();
        //spotlight = GetComponentInChildren<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //_audioSource = GetComponent<AudioSource>();
        audioSource = new GameObject("_AudioSource").AddComponent<AudioSource>();
        audioSource.loop = loop;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }


    void GetSpectrumAudioSource()
    {
        float[] spectrumData = audioSource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Rectangular);
        for (int i = 0; i < spectrumData.Length; i++)
        {
            //_cam.Translate(Vector3.forward * _intensity * Time.deltaTime);
            if (spectrumData[i] > 0.2)
                {
                cam.AddForce(Vector3.right * spectrumData[i] * force * 2 * Time.deltaTime);
                //_cam.Translate(Vector3.forward * spectrumData[i] * force * Time.deltaTime);
                //spotlight.intensity = 1 * _intensity;
            }
                else
                {
                cam.AddForce(Vector3.right * spectrumData[i] * force * Time.deltaTime);
                //_cam.Translate(Vector3.forward * spectrumData[i] * Time.deltaTime);
                //spotlight.intensity = 1;
                }
            spotlight.intensity = spectrumData[i] * _intensity;
            
        }
    }
}
