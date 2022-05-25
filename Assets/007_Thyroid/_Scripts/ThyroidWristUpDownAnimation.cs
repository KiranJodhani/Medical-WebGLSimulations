using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ThyroidWristUpDownAnimation : MonoBehaviour
{
	
	public Vector3 InitialAngle;
	public Vector3 TargetAngle;
	public int Counter;
	public Transform Target;


	public Transform Big_Needle_Obj;
	public Transform Big_Needle_Obj_Target;
	public Transform Big_Needle;
	public Transform Big_Needle_Inital;
	public Transform Big_Needle_Target;


	void Start()
	{
		InitialAngle = Target.transform.localEulerAngles;

		TargetAngle = InitialAngle;
		TargetAngle.x = -35;
		PlayDownAnimation();
		Big_Needle.transform.localPosition = Big_Needle_Inital.localPosition;

		Sequence s1 = DOTween.Sequence();
		s1.Append(Big_Needle_Obj.transform.DOLocalMove(Big_Needle_Obj_Target.localPosition, 7f)).SetEase(Ease.Linear);

	}

	public void PlayDownAnimation()
	{
		Sequence s1 = DOTween.Sequence();
		s1.Append(Target.transform.DOLocalRotate(TargetAngle, 0.5f)).SetEase(Ease.Linear).OnComplete(PlayUpAnimation);

		Sequence s2 = DOTween.Sequence();
		s2.Append(Big_Needle.transform.DOLocalMove(Big_Needle_Target.localPosition, 0.5f)).SetEase(Ease.Linear);

	}

	public void PlayUpAnimation()
    {
		Counter = Counter + 1;
		if(Counter<13)
        {
			Sequence s1 = DOTween.Sequence();
			s1.Append(Target.transform.DOLocalRotate(InitialAngle, 0.5f)).SetEase(Ease.Linear).OnComplete(PlayDownAnimation);

			Sequence s2 = DOTween.Sequence();
			s2.Append(Big_Needle.transform.DOLocalMove(Big_Needle_Inital.localPosition, 0.5f)).SetEase(Ease.Linear);

		}
		else
        {
			Thyroid_Manager.Instance.OnStep9Finished();
        }
	}


}
