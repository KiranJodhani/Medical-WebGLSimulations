using DG.Tweening;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Arrow;
    public Transform Arrow_Target;

    void Start()
    {
        StartArrowAnimation();
    }

    void StartArrowAnimation()
    {
        Sequence s = DOTween.Sequence();
        s.Append(Arrow.DOLocalMove(Arrow_Target.localPosition, 2f).SetEase(Ease.Linear));//.OnComplete(StartSunAnimation));
        s.SetLoops(-1);
    }

}
