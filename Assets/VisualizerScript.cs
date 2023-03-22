using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class VisualizerScript : MonoBehaviour
{

    public float minHeight = 10.0f;
    public float maxHeight = 50.0f;

	//public MeshRenderer cube;
	private Image[] imges = new Image[81];
	public Sprite[] sprites;
	private int j;

    public float updateSentivity = 10.0f;
	//public Color visualizerColor = Color.gray;
	[Space (15)]
	public AudioClip audioClip;
	public bool loop = true;
	[Space (15), Range (64, 8192)]
	public int visualizerSimples = 64;
	[Space(15), Range(0.0f, 1.0f)]
	public float _volume = 1.0f;
	[Space(15), Range(0.0f, 1.0f)]
	public float Sensitive = 0.0f;

	VisualizerObjectScript[] visualizerObjects;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		visualizerObjects = GetComponentsInChildren<VisualizerObjectScript> ();
		imges = GetComponentsInChildren<Image>();


		if (!audioClip)
			return;

		audioSource = new GameObject ("_AudioSource").AddComponent <AudioSource> ();
		audioSource.loop = loop;
		audioSource.clip = audioClip;
		audioSource.Play ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		audioSource.volume = _volume;

		float[] spectrumData = audioSource.GetSpectrumData (visualizerSimples, 0, FFTWindow.Rectangular);

		for (int i = 0; i < visualizerObjects.Length; i++)
        {
            Vector3 newSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;

            //newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minHeight + (spectrumData[i] * (maxHeight - minHeight) * 5.0f), updateSentivity * 0.5f), minHeight, maxHeight);
            //visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;


            //Debug.Log(spectrumData[i]);
            if (spectrumData[i] > Sensitive)
            {
				j = Random.Range(0, sprites.Length+1);

				visualizerObjects[Random.Range(0,81)].ColorChange();
				imges[Random.Range(0, 81)].sprite = sprites[j];
				
			}
            else
            {
                visualizerObjects[Random.Range(0, 81)].ColorBase();
            }
            //visualizerObjects[Random.Range(0, 81)].transform.Rotate(0, 0, Random.Range(-360, 360));
        }
        //if (Input.GetKeyDown(KeyCode.C))
        //{
			
        //}
    }

}