using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materialsc : MonoBehaviour
{
    //VisualizerScript visual;
    public Material img;
    public Color visualizerColor;

    private void Awake()
    {
        img = gameObject.GetComponent<Material>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //visualizerColor.a = 0.0f;

        //img.color = visualizerColor;
    }

    // Update is called once per frame
    void Update()
    {
        //visualizerColor = img.color;
    }

    public void ColorChange()
    {

        img.GetColor("black");
    }
    public void ColorBase()
    {

        img.GetColor("white");
    }
}
