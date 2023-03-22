using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizerObjectScript : MonoBehaviour
{
    VisualizerScript visual;
    public Image img;
    public Color visualizerColor;

    private void Awake()
    {
        img = this.gameObject.GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        visualizerColor.a = 0.0f;

        //img.color = visualizerColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorChange()
    {
        
        img.color = new Vector4(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0.7f);
    }
    public void ColorBase()
    {

        img.color = new Vector4(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0.0f);
    }
}
