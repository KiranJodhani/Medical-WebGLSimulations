using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trun_Focus : MonoBehaviour
{

    //Rotating object
    public GameObject dragGam;
    //When you rotate an object, the sprite also rotates.
    public GameObject dragGamUI;
    //Camera showing cells
    public GameObject cellCamera;
    //This object will move up and down when rotating
    public GameObject stageGam;
    //Text display height
    public GameObject numText;
    //Display low-resolution rendertexture
    public GameObject camRenderTextureLow;

    void OnMouseDrag()
    {
        //Drag object and rotate this object
        GetComponent<dragRotate>().dragTo(dragGam.transform);

        //Text display height
        numText.GetComponent<TextMesh>().text = stageGam.transform.localPosition.y.ToString("f2");

        //The effects displayed while dragging also rotate
        dragGamUI.transform.eulerAngles = new Vector3(dragGam.transform.eulerAngles.x, dragGam.transform.eulerAngles.y, -dragGam.transform.eulerAngles.z);

        //This object will move up and down when rotating
        stageGam.transform.localPosition = new Vector3(stageGam.transform.localPosition.x, stageGam.transform.localPosition.y - GetComponent<dragRotate>().rotateNum / 300, stageGam.transform.localPosition.z);
        //Set the maximum value of the move
        if (stageGam.transform.localPosition.y> 3.789f)
        {
            //Set the maximum value of the move
            stageGam.transform.localPosition = new Vector3(stageGam.transform.localPosition.x, 3.789f, stageGam.transform.localPosition.z);

        }
        // Set minimum value for movement
         if (stageGam.transform.localPosition.y <3.1f)
        {
            //Set the maximum value of the move
            stageGam.transform.localPosition = new Vector3(stageGam.transform.localPosition.x, 3.1f, stageGam.transform.localPosition.z);
        }

        //Adjust transparency to blur eyepieces
        camRenderTextureLow.GetComponent<CanvasGroup>().alpha =Mathf.Abs(3.5f - stageGam.transform.localPosition.y)*4f;

    }
   
}
