using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fllow : MonoBehaviour
{
    //Make two objects in the same position


    //Following objec
    public Transform FllowGam;

    void Update()
    {
        //Two objects have the same position
        transform.position = FllowGam.position;
    }
}
