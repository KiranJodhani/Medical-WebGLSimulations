using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Input_Test : MonoBehaviour
{

    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    public float VerticalSpeedDelta;
    public float HorizontalSpeedDelta;

    public GameObject OnlyVertical;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            HorizontalSpeedDelta = horizontalSpeed * Input.GetAxis("Mouse X");
            VerticalSpeedDelta = verticalSpeed * Input.GetAxis("Mouse Y");

            if (HorizontalSpeedDelta > 0.2f)
            {
                transform.Rotate(Vector3.down * Time.deltaTime * 100);
            }
            else if(HorizontalSpeedDelta < -0.2f)
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 100);
            }

            //if (VerticalSpeedDelta > 0.2f)
            //{
            //    OnlyVertical.transform.Rotate(Vector3.right * Time.deltaTime * 100);
            //}
            //else if (VerticalSpeedDelta < -0.2f)
            //{
            //    OnlyVertical.transform.Rotate(Vector3.left * Time.deltaTime * 100);
            //}
        }
    }
}
