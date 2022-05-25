using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TypingAnimation : MonoBehaviour
{
	public Transform TypingHand;
	public Transform TypingHand_Initial;
	public Transform TypingHand_Target;
	public PathType pathType = PathType.CatmullRom;
	public Transform[] waypointsObj;
	public Vector3[] waypoints;
	Tween t;


	void Start()
	{
		EnterTypingHand();
	}

	void PlayTypingAnimation()
	{
		for (int i = 0; i < waypointsObj.Length; i++)
		{
			waypoints[i] = waypointsObj[i].localPosition;

		}
		t = TypingHand.DOLocalPath(waypoints, 4, pathType).SetOptions(false);
		t.SetEase(Ease.Linear).SetLoops(-1);
	}

	public void StopTypingAnimation()
	{
		t.Kill();
	}

	public void EnterTypingHand()
    {
		Sequence s1 = DOTween.Sequence();
		s1.Append(TypingHand.transform.DOLocalMove(TypingHand_Target.localPosition, 1f)).SetEase(Ease.Linear).OnComplete(OnHandEntered);
	}

	void OnHandEntered()
    {
		PlayTypingAnimation();
		Invoke("StopTypingAnimation", 4);
		Invoke("ExitTypingHand", 4.5f);
	}

	public void ExitTypingHand()
	{
		Sequence s1 = DOTween.Sequence();
		s1.Append(TypingHand.transform.DOLocalMove(TypingHand_Initial.localPosition, 1f)).SetEase(Ease.Linear).OnComplete(OnExitTypingHand);
	}

	public void OnExitTypingHand()
    {
		C_SpecManager.Instance.StartStep7();
	}

}
