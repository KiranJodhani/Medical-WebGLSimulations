using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        MicroscopeManager.Instance.OnClickMicorscopePart(gameObject.name);
    }
}
