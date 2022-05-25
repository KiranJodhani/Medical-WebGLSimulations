using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trun_Eyepiece : MonoBehaviour
{
    //--Drag the mouse to rotate the eyepiece

    //Drag the mouse to rotate the object
    public GameObject dragGam;
    //eyepiece
    public GameObject eyepieceGam;
    //Text showing eyepiece height value
    public GameObject eyepieceText;

    //Show special effects when dragging
    public GameObject dragGamUI1;
    //Show special effects when dragging
    public GameObject dragGamUI2;

    void OnMouseDrag()
    {
        //Drag object and rotate this object
        GetComponent<dragRotate>().dragTo(dragGam.transform);
        //Display eyepiece height value
        eyepieceText.GetComponent<TextMesh>().text = ((eyepieceGam.transform.localPosition.y - 10.4f)*10).ToString("f2");
        //Move eyepiece during rotation adjustment
        eyepieceGam.transform.localPosition = new Vector3(eyepieceGam.transform.localPosition.x, eyepieceGam.transform.localPosition.y - GetComponent<dragRotate>().rotateNum / 300, eyepieceGam.transform.localPosition.z);

        //Set maximum height for eyepiece
        if (eyepieceGam.transform.localPosition.y > 10.7f)
        {
            //When the eyepiece is highest, stop rising
            eyepieceGam.transform.localPosition = new Vector3(eyepieceGam.transform.localPosition.x, 10.7f, eyepieceGam.transform.localPosition.z);
        }
        //Set the minimum height of the eyepiece
        if (eyepieceGam.transform.localPosition.y < 10.4f)
        {
            //When the eyepiece is lowest, stop descending
            eyepieceGam.transform.localPosition = new Vector3(eyepieceGam.transform.localPosition.x, 10.4f, eyepieceGam.transform.localPosition.z);
        }

        //Special effects also rotate when dragging
        dragGamUI1.transform.localEulerAngles = new Vector3(0, 270, dragGam.transform.localEulerAngles.y);
        //Special effects also rotate when dragging
        dragGamUI2.transform.localEulerAngles = new Vector3(0, 0, dragGam.transform.localEulerAngles.y);


    }
   
}
