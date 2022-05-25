using DG.Tweening;
using UnityEngine;

public class C_SpecArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Arrow;
    public Transform Arrow_Target;
    public float AnimationSpeed = 2;
    void Start()
    {
        StartArrowAnimation();
    }

    void StartArrowAnimation()
    {
        Sequence s = DOTween.Sequence();
        s.Append(Arrow.DOLocalMove(Arrow_Target.localPosition, AnimationSpeed).SetEase(Ease.Linear));//.OnComplete(StartSunAnimation));
        s.SetLoops(-1);
    }
}
