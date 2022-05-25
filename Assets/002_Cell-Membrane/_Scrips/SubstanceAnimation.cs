using UnityEngine;
using DG.Tweening;

public class SubstanceAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Substance;
    public Transform Substance_Target;
    public bool DoRotate;
    void Start()
    {
        StartSubstanceAnimation();
    }

    void StartSubstanceAnimation()
    {
        DoRotate = true;
        Sequence s = DOTween.Sequence();
        s.Append(Substance.DOLocalMove(Substance_Target.localPosition, 5f).SetEase(Ease.Linear)).OnComplete(OnSubstanceReached);
    }

    private void Update()
    {
        if(DoRotate)
        {
            Substance.Rotate(Vector3.up * Time.deltaTime*100);
        }
    }

    public void OnSubstanceReached()
    {
        DoRotate = false;
    }
}
