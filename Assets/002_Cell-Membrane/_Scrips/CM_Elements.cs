using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_Elements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        if(!CellMembrane.Instance.Notification.activeSelf)
        {
            CellMembrane.Instance.OnClickSubObject(gameObject.tag);
        }
    }
}
