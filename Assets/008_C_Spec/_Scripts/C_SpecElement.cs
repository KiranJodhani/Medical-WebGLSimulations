using UnityEngine;
using DG.Tweening;


public class C_SpecElement : MonoBehaviour
{
    public GameObject MyHand;

    public Transform MyHand_Target;
    public Transform MyHand_Initial;


    void Start()
    {

    }


    private void OnMouseUpAsButton()
    {
        if (MyHand)
        {
            MyHand.SetActive(true);
            if (C_SpecManager.Instance.ScreenIndex==3)
            {
                ShowHandsApproaching();
            }
        }
        C_SpecManager.Instance.OnClick_CSpec_Element(gameObject);
        C_SpecManager.Instance.DisableAllCollider();
    }

    public void ShowHandsApproaching()
    {
        Sequence s2 = DOTween.Sequence();
        s2.Append(MyHand.transform.DOLocalMove(MyHand_Target.localPosition, 1f)).SetEase(Ease.Linear).OnComplete(OnHandApproached);
    }

    public void OnHandApproached()
    {
        if(gameObject.name== "01_SmartPhone")
        {
            C_SpecManager.Instance.FocusSmartphone();

        }
        else if (gameObject.name == "02_SmartPhoneHolder")
        {
            C_SpecManager.Instance.FocusSmartphoneHolder();
        }       
    }

    public void RemoveHand()
    {
        Sequence s2 = DOTween.Sequence();
        s2.Append(MyHand.transform.DOLocalMove(MyHand_Initial.localPosition, 1f)).SetEase(Ease.Linear).OnComplete(OnHandRemoved);
    }


    public void OnHandRemoved()
    {
        MyHand.SetActive(false);
    }

}
