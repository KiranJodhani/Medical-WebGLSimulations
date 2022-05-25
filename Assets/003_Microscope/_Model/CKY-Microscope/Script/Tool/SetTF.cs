using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTF : MonoBehaviour
{
    public GameObject[] gam;


    public void SetTFs()
    {
        for (int i = 0; i < gam.Length; i++)
        {
            try
            {
                gam[i].SetActive(!gam[i].activeSelf);
            }
            catch
            {

            }
        }
    }
}
