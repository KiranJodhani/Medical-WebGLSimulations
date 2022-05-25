using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Spec_Cable : MonoBehaviour
{
    public LineRenderer MyLineRederer;
    public Transform Endoscope;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MyLineRederer.SetPosition(0, transform.position);
        MyLineRederer.SetPosition(1, Endoscope.position);
        

    }
}
