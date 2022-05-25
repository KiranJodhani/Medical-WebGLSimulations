using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragRotate : MonoBehaviour
{
    //--Drag object and rotate this object

    //spinning speed
    public float speed = 6f; 

    //Mouse X axis increment
    private float mIncrement_x;
    //Mouse Y axis increment
    private float mIncrement_y;

    //Mouse position on screen, X axis
    private float mScreenPosition_x;
    //Mouse Y axis increment
    private float mScreenPosition_y;


    //Mouse X axis position
    private float mPosition_x;
    //Mouse Y axis position
    private float mPosition_y;

    //Select rotation axis
    public bool X = false;
    public bool Y = false;
    public bool Z = false;

    //rotation angle value
    public float rotateNum;

    //Show sprite animation when rotating object
    //The sprite that will play the animation
    public GameObject[] animSprites;
  
    //Show when turning left
    public GameObject[] spriteL;
    //Show when turning right
    public GameObject[] spriteR;

    int i = 0;

    public void dragTo( Transform trunGam)
    {
        //Mouse X axis position
        mPosition_x = Input.mousePosition.x;
        //Mouse Y axis position
        mPosition_y = Input.mousePosition.y;

        //Mouse position on screen, X axis
        mScreenPosition_x = Camera.main.WorldToScreenPoint(transform.position).x;
        //Mouse position on screen, Y axis
        mScreenPosition_y = Camera.main.WorldToScreenPoint(transform.position).y;

        //Mouse X axis increment
        mIncrement_x = -Input.GetAxis("Mouse X");
        //Mouse Y axis increment
        mIncrement_y = Input.GetAxis("Mouse Y");


        //---Determine which quadrant the mouse is in.
        //---With mPosition as the origin, which quadrant is the point mScreenPosition.
        if (mScreenPosition_x > mPosition_x)
        {
            //Second quadrant
            if (mScreenPosition_y < mPosition_y)
            {
                //Get a rotation angle value
                rotateNum = -mIncrement_x + mIncrement_y;
            }
            //First quadrant
            if (mScreenPosition_y > mPosition_y)
            {
                //Get a rotation angle value
                rotateNum = mIncrement_x + mIncrement_y;
            }
        }
        if (mScreenPosition_x < mPosition_x)
        {
            //Fourth quadrant
            if (mScreenPosition_y < mPosition_y)
            {
                //Get a rotation angle value
                rotateNum = -mIncrement_x - mIncrement_y;
            }
            //Third quadrant
            if (mScreenPosition_y > mPosition_y)
            {
                //Get a rotation angle value
                rotateNum = mIncrement_x - mIncrement_y;
            }
        }
        //Select the axis of rotation
        if (X)
        {
            //Rotate the X axis to the calculated value
            trunGam.Rotate(new Vector3(-rotateNum* speed, 0, 0), Space.Self);
        }
        if (Y)
        {
            //Rotate the Y axis to the calculated value
            trunGam.Rotate(new Vector3(0, -rotateNum * speed, 0), Space.Self);
        }
        if (Z)
        {
            //Rotate the Z axis to the calculated value
            trunGam.Rotate(new Vector3(0, 0, -rotateNum * speed), Space.Self);
        }

        //The sprite displayed when dragging
        showSprite();

    }

    //Mouse click
    private void OnMouseDown()
    {
        //Loop through all animated objects
        for (i=0;i< animSprites.Length;i++)
        {
            //If the object is not active
            if (animSprites[i].gameObject.activeSelf==false)
            {
                //Activate the object
                animSprites[i].gameObject.SetActive(true);
            }
            //Play animation
            animSprites[i].GetComponent<Animator>().SetInteger("Go",0);
        }
    }

    //Mouse up
    private void OnMouseUp()
    {
        //Loop through all animated objects
        for (i = 0; i < animSprites.Length; i++)
        {
            //Play animation
            animSprites[i].GetComponent<Animator>().SetInteger("Go",1);
        }
    }


    //The sprite displayed when dragging
    void showSprite()
    {
        //Drag right
        if (rotateNum > 0)
        {
            for (int i = 0; i < spriteL.Length; i++)
            {
                //Hidden left sprite
                spriteL[i].SetActive(false);
                //Activate the right sprite
                spriteR[i].SetActive(true);
            }
        }
        //Drag left
        if (rotateNum < 0)
        {
            for (int i = 0; i < spriteL.Length; i++)
            {
                //Activate the left sprite
                spriteL[i].SetActive(true);
                //Hidden right sprite
                spriteR[i].SetActive(false);
            }
        }
    }


}
