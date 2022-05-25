using UnityEngine;
using DG.Tweening;

public class LabObjectElement : MonoBehaviour
{
    
    public GameObject MyHand;
    public Outline[] Outline_Instances;
    public int MyIndex;
    public string RotationDirection;
    public bool DoRoate;
    public Vector3 InitialAngle;
    public float RotationSpeed = 10;

    [Header("#### FLIP #####")]
    public bool DoFlip;
    public Vector3 FlippedAngle;

    [Header("#### UP AND GO #####")]
    public bool DoUpAndGo;
    public Vector3 InitialPosition;
    public Vector3 UpPosition;
    public float Y_Offset;

    void Start()
    {
        InitialAngle = transform.localEulerAngles;
        for (int i = 0; i < Outline_Instances.Length;i++)
        {
            Outline_Instances[i].enabled = true;
        }

        
        InitialPosition = transform.localPosition;
        UpPosition = InitialPosition;
        UpPosition.y = Y_Offset;

    }


    private void Update()
    {
        if(DoRoate)
        {
            if(RotationDirection=="f")
            {
                transform.Rotate(Vector3.forward * Time.deltaTime* RotationSpeed);
            }
            else if (RotationDirection == "b")
            {
                transform.Rotate(Vector3.back * Time.deltaTime * RotationSpeed);
            }
            if (RotationDirection == "u")
            {
                transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
            }
            else if (RotationDirection == "d")
            {
                transform.Rotate(Vector3.down * Time.deltaTime * RotationSpeed);
            }
            if (RotationDirection == "l")
            {
                transform.Rotate(Vector3.left * Time.deltaTime * RotationSpeed);
            }
            else if (RotationDirection == "r")
            {
                transform.Rotate(Vector3.right * Time.deltaTime * RotationSpeed);
            }
        }
    }

    public void DisableRotation()
    {
        DoRoate = false;
        if(DoFlip)
        {
            transform.localEulerAngles = FlippedAngle;
            Sequence s = DOTween.Sequence();
            s.Append(transform.DOLocalRotate(InitialAngle, 1.5f).SetEase(Ease.Linear));
        }
        else
        {
            transform.localEulerAngles = InitialAngle;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (!LabAssetManager.Instance.IsItemSelected)
        {
            LabAssetManager.Instance.ScreenIndex = MyIndex;
            LabAssetManager.Instance.OnClickLabObject(gameObject);
            if(DoFlip)
            {
                Sequence s = DOTween.Sequence();
                s.Append(transform.DOLocalRotate(FlippedAngle, 1.5f).SetEase(Ease.Linear));

            }
            if (MyHand)
            {
                //MyHand.SetActive(true);
            }
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void HideMyOutline()
    {
        for (int i = 0; i < Outline_Instances.Length; i++)
        {
            Outline_Instances[i].enabled = false;
        }
    }

    public void ShowMyOutline()
    {
        if(GetComponent<BoxCollider>().enabled)
        {
            for (int i = 0; i < Outline_Instances.Length; i++)
            {
                Outline_Instances[i].enabled = true;
            }
        }
    }

    public void DisableVisitedItem()
    {
        if (MyHand)
        {
            //MyHand.SetActive(false);
        }
    }
}
