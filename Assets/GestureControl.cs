using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour
{

    private float rotationX;
    private float scaleRotationX = 5f;

    private float positionX;
    private float positionY;
    private float scalePosiontX = 10f;
    private float scalePosiontY = 10f;

    private float positionW;
    private float scaleModel = 30f;

    void Update()
    {
        if (Input.GetMouseButton(1))  //pressing right button of mouse to change position of model and modifying wheel to change model scale
        {
           
            positionX = Input.GetAxis("Mouse X") * scalePosiontX;
            positionY = Input.GetAxis("Mouse Y") * scalePosiontY;
            positionW = Input.GetAxis("Mouse ScrollWheel") * scaleModel;
            transform.position += new Vector3(positionX, positionY, 0f);
            transform.localScale += new Vector3(positionW, positionW, positionW);
        }
        else if (Input.GetMouseButton(2))   //pressing middle button of mouse to change rotation on Y axis of model
        {
            rotationX = -Input.GetAxis("Mouse X") * scaleRotationX;
            transform.Rotate(0f, rotationX, 0f, Space.World);
        }
    }


}
