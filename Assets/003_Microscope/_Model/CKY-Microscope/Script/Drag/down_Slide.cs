using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down_Slide : MonoBehaviour
{
    //Add a camera
    public GameObject moveCamera;
    public GameObject moveCameraLow;

    void OnMouseDown()
    {
        //Generate a random coordinate for the camera
        moveCamera.transform.localPosition = new Vector3(Random.Range(-10.0f, 10.0f), 8.1f, Random.Range(-10.0f, 10.0f));
        moveCameraLow.transform.localPosition = moveCamera.transform.localPosition;
    }
    
}
