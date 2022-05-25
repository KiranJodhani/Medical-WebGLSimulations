using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SwabUpDownAnimation : MonoBehaviour
{
    public Transform Swab_Up;
    public Transform Swab_Down;
    public float AnimationSpeed = 2;


    void Start()
    {
        
    }

    public void GoSwabUp()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOLocalMove(Swab_Up.localPosition, AnimationSpeed).SetEase(Ease.Linear)).OnComplete(GoSwabDown);
        
    }

    void GoSwabDown()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOLocalMove(Swab_Down.localPosition, AnimationSpeed).SetEase(Ease.Linear)).OnComplete(GoSwabUp);
    }
}
