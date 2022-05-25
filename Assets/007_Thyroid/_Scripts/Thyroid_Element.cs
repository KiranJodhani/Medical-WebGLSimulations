using UnityEngine;
using DG.Tweening;

public class Thyroid_Element : MonoBehaviour
{
    public GameObject MyHand;
    
    public Transform MyHand_Target;
    public Vector3 InitialAngle;
    public Vector3 InitialPosition;
    public Vector3 HandInitialPosition;

    public GameObject MyHand2;
    public Transform MyHand_Target2;
    void Start()
    {
        InitialAngle = transform.localEulerAngles;
        InitialPosition = transform.localPosition;
        if(MyHand)
        {
            HandInitialPosition = MyHand.transform.localPosition;
        }
    }

   
    private void OnMouseUpAsButton()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        if(MyHand)
        {
            MyHand.SetActive(true);
        }
       Thyroid_Manager.Instance.OnClickFNA_Item(gameObject);
    }

    public void RemoveHand()
    {
        Sequence s2 = DOTween.Sequence();
        s2.Append(MyHand.transform.DOLocalMove(MyHand_Target.localPosition, 1f)).SetEase(Ease.Linear).OnComplete(OnHandRemoved);
    }

    public void RemoveHand2()
    {
        Sequence s2 = DOTween.Sequence();
        s2.Append(MyHand2.transform.DOLocalMove(MyHand_Target2.localPosition, 1f)).SetEase(Ease.Linear).OnComplete(OnHandRemoved2);
    }


    public void OnHandRemoved()
    {
        MyHand.SetActive(false);
    }

    public void OnHandRemoved2()
    {
        MyHand2.SetActive(false);
    }

}
