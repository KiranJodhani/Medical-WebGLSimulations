using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PassthroughAnimation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

	public Transform target;
	public PathType pathType = PathType.CatmullRom;
	public Transform[] waypointsObj;
	public Vector3[] waypoints;

	void Start()
	{
		PlayPassthroughAnimation();
	}

	void PlayPassthroughAnimation()
    {
		for (int i = 0; i < waypointsObj.Length; i++)
		{
			waypoints[i] = waypointsObj[i].localPosition;

		}
		Tween t = target.DOLocalPath(waypoints, 4, pathType).SetOptions(true).SetLookAt(0.001f);
		t.SetEase(Ease.Linear).SetLoops(-1);
	}
}
