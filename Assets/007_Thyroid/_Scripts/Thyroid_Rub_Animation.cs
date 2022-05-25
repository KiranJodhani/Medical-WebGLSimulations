using UnityEngine;
using DG.Tweening;

public class Thyroid_Rub_Animation : MonoBehaviour
{
   

	public Transform target;
	public PathType pathType = PathType.CatmullRom;
	public Transform[] waypointsObj;
	public Vector3[] waypoints;
	Tween t;
	void Start()
	{
		PlayRubAnimation();
	}

	void PlayRubAnimation()
	{
		for (int i = 0; i < waypointsObj.Length; i++)
		{
			waypoints[i] = waypointsObj[i].localPosition;

		}
		t = target.DOLocalPath(waypoints, 4, pathType).SetOptions(false);
		t.SetEase(Ease.Linear).SetLoops(-1);
	}

	public void StopRubAnimation()
    {
		t.Kill();
    }
	
}
