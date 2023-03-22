using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamSample : MonoBehaviour
{
    public Renderer display;
    WebCamTexture camTexture;
    private int currentIndex = 0;

    private void Start()
    {
        if (camTexture != null)
        {
            display.material.mainTexture = null;
            camTexture.Stop();
            camTexture = null;
        }
        WebCamDevice device = WebCamTexture.devices[currentIndex];
        camTexture = new WebCamTexture(device.name);
        display.material.mainTexture = camTexture;
        camTexture.Play();
    }
}
