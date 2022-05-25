using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trun_Mirror : MonoBehaviour
{
    //
    //Drag the mouse to rotate the object
    public GameObject dragGam;
    //"dragGam" rotation angle
    public float dragRotate = 0f;
    //Turning point  Midpoint of the line
    public GameObject turnPoint;
    //End point  The end of the line
    public GameObject endPoint;
    //Generate line
    public GameObject renderLine;
    //The dark part of the objective
    public GameObject cameraDark;
    //Bright part of objective lens
    public GameObject cameraLight;
    //"cameraDark" transparency
    public float cameraDarkAlpha;
    //"cameraLight" transparency
    public float cameraLightAlpha;
    //Silde object
    public GameObject Silde;
    //Show special effects when dragging
    public GameObject dragGamUI;
    //The length of the render line
    float textureMove = 0.22f;
    //
    float moveLerp = 0.22f;

    //When the mouse is dragged
    void OnMouseDrag()
    {
       
        //Drag object and rotate this object
        GetComponent<dragRotate>().dragTo(dragGam.transform);
        //When the mirror rotates, the refraction point moves
        turnPoint.transform.localEulerAngles = new Vector3(180f+17.5f + dragGam.transform.localEulerAngles.x + dragGam.transform.localEulerAngles.x, 0,0);
        //Generate a line
        renderLine.GetComponent<DrawLine>().getLine();
        //When the mirror rotates, Show special effects also rotate together
        dragGamUI.transform.localEulerAngles = new Vector3 (0,0, dragGam.transform.localEulerAngles.x)  ;

    }
   


    private void LateUpdate()
    {
     
        //Linearly interpolates between "moveLerp" and "textureMove".
        moveLerp = Mathf.Lerp(moveLerp, textureMove,0.03f);
        //TextureOffset moves gradually
        renderLine.GetComponent<LineRenderer>().materials[0].mainTextureOffset = new Vector2(moveLerp, 0);
        //Limiting the rotation angle of the mirror
        if (dragGam.transform.localEulerAngles.x > 80)
        {
            dragRotate = 15;
            //Constrain the maximum rotation angle of the mirror
            dragGam.transform.localEulerAngles = new Vector3(80,0,0);
        }
        //Limiting the rotation angle of the mirror
        if (dragGam.transform.localEulerAngles.x <10)
        {
            dragRotate = -15;
            //Limit the minimum rotation angle of the mirror
            dragGam.transform.localEulerAngles = new Vector3(10, 0, 0);
        }

        //If refracted light enters the objective lens
        if (dragGam.transform.localEulerAngles.x > 34 && dragGam.transform.localEulerAngles.x < 39 )
        {
            //If the slide is already in place
            if (Silde.transform.localPosition.y >-0.03f)
            {
                //Make objects transparent
                cameraDarkAlpha = 0;
                //Make objects transparent
                cameraLightAlpha = 0;
            }
            //If the slide is not in place
            else
            {
                //Show picture mask
                cameraLightAlpha = 1;
                //Show picture mask
                cameraDarkAlpha = 1;
            }
        }
        //If the refracted light does not enter the objective lens
        else
        {
            //Darken the objective
            cameraDarkAlpha = 1;
            //Make objects transparent
            cameraLightAlpha = 0;
        }
        //Objective lens dimming effect  Progressive dimming bright
        cameraLight.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(cameraLight.GetComponent<CanvasGroup>().alpha, cameraLightAlpha, 0.3f);
        //Objective lens dimming effect  Progressive dimming dark
        cameraDark.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(cameraDark.GetComponent<CanvasGroup>().alpha, cameraDarkAlpha, 0.3f);

        
    }
}
