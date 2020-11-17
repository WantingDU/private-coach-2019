using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCam : MonoBehaviour
{


    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }

        //Renderer rend = this.GetComponentInChildren<Renderer>();

        // assuming the first available WebCam is desired

        WebCamTexture tex = new WebCamTexture(devices[0].name);
        this.gameObject.GetComponent<CanvasRenderer>().SetTexture(tex);
        //this.gameObject.GetComponent<RawImage>().texture = tex;
        tex.Play();
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy1");
    }
}
