using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScale : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    public float VerticalSpeedDelta;
    public float HorizontalSpeedDelta;

    public GameObject OnlyVertical;

    public float MaxZoomValue;
    public float MinZoomValue;
    public float ZoomFactor;

    public CellMembrane CellMembraneInstance;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //HorizontalSpeedDelta = horizontalSpeed * Input.GetAxis("Mouse X");
        //VerticalSpeedDelta = verticalSpeed * Input.GetAxis("Mouse Y");


        //if (Input.GetMouseButton(0))
        //{
        //    if ((Input.GetKey(KeyCode.R)))
        //    {
        //        if (HorizontalSpeedDelta > 0.2f)
        //        {
        //            transform.Rotate(Vector3.down * Time.deltaTime * 100);
        //        }
        //        else if (HorizontalSpeedDelta < -0.2f)
        //        {
        //            transform.Rotate(Vector3.up * Time.deltaTime * 100);
        //        }

        //        if (VerticalSpeedDelta > 0.2f)
        //        {
        //            OnlyVertical.transform.Rotate(Vector3.right * Time.deltaTime * 100);
        //        }
        //        else if (VerticalSpeedDelta < -0.2f)
        //        {
        //            OnlyVertical.transform.Rotate(Vector3.left * Time.deltaTime * 100);
        //        }
        //    }
        //    else if ((Input.GetKey(KeyCode.R)))
        //    {

        //    }
        //}

        if ((Input.GetKey(KeyCode.A)))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100);
        }
        else if ((Input.GetKey(KeyCode.D)))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 100);
        }
        else if ((Input.GetKey(KeyCode.W)))
        {
            OnlyVertical.transform.Rotate(Vector3.right * Time.deltaTime * 100);            
        }
        else if ((Input.GetKey(KeyCode.S)))
        {
            OnlyVertical.transform.Rotate(Vector3.left * Time.deltaTime * 100); 

        }

        if ((Input.GetKey(KeyCode.Q)))
        {
            if (transform.localScale.x < MaxZoomValue)
            {
                transform.localScale = transform.localScale + new Vector3(ZoomFactor, ZoomFactor, ZoomFactor);
            }
        }
        else if ((Input.GetKey(KeyCode.E)))
        {
            if (transform.localScale.x > MinZoomValue)
            {
                transform.localScale = transform.localScale - new Vector3(ZoomFactor, ZoomFactor, ZoomFactor);
            }
        }

        if ((Input.GetKeyUp(KeyCode.R)))
        {
            CellMembraneInstance.Reset_CM_Model();
        }
    }
}