using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeeze_Element : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnMouseUp()
    {
        FireManager.Instance.Squeeze_UnSqueeze();
        GetComponent<Collider>().enabled = false;
        Invoke("ResetCollider", 1);
    }

    void ResetCollider()
    {
        GetComponent<Collider>().enabled = true;
    }
}
