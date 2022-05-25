using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FllowUI : MonoBehaviour
{
    public GameObject HitGam;
    //public string Name;
    //public GameObject Texts;

    void Update()
    {
        if(HitGam!=null)
        {
            this.transform.position = new Vector3(Camera.main.WorldToScreenPoint(HitGam.transform.position).x, Camera.main.GetComponent<Camera>().WorldToScreenPoint(HitGam.transform.position).y, 0);
            //Texts.GetComponent<Text>().text = Name;
        }
        else
        {
            //this.gameObject.SetActive(false);
        }
    }
}
