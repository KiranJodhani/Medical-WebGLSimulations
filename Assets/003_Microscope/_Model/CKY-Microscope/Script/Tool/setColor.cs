using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour
{
    //Change the color of the material. Black or white

    public GameObject[] mGam;

    //Black
    public Color colorBlack;

    //White
    public Color colorWhite;


    //Black microscope
    public void color_Black()
    {
        for(int i=0;i< mGam.Length;i++)
        {
            //Change the material color of these objects to black
            mGam[i].GetComponent<Renderer>().material.color= colorBlack;
        }
    }


    //White microscope
    public void color_White()
    {
        for (int i = 0; i < mGam.Length; i++)
        {
            //Change the material color of these objects to white
            mGam[i].GetComponent<Renderer>().material.color = colorWhite;
        }
    }
}
