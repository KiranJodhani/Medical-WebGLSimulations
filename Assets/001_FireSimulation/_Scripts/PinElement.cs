using UnityEngine;

public class PinElement : MonoBehaviour
{
    private Vector3 mOffset;
    public Vector3 Pos;
    private float mZCoord;
    public float OldZPos;

    private void Start()
    {

    }

    void OnMouseDown()
    {
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
        if (transform.localPosition.x > -0.033f)
        {
            Pos = GetMouseAsWorldPoint() + mOffset;
            if (OldZPos > Pos.z)
            {
                Pos.y = 0.982f;
                Pos.x = 0.847f;
                transform.position = Pos;
            }
            OldZPos = Pos.z;
        }

    }

    private void Update()
    {
        if (transform.localPosition.x < -0.033f)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            FireManager.Instance.OnPinPulled();
            enabled = false;
        }
    }

}
