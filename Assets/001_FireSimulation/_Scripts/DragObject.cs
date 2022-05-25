using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    private Vector3 mOffset;
    public Vector3 Pos;
    private float mZCoord;
    public float OldPos;

    private void Start()
    {
        
    }

    void OnMouseDown()
    {

        FireManager.Instance.OnFireExtinguisherGrabbed();
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Pos= GetMouseAsWorldPoint() + mOffset;
        transform.position = Pos;
        OldPos = Pos.z;
    }

    private void OnMouseUp()
    {
        if (FireManager.Instance.IsAtCorrectPos)
        {
            FireManager.Instance.OnFireExtinguisherDropped();
        }
    }

}