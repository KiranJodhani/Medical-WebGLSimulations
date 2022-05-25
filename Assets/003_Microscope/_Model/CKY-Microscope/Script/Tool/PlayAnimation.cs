using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    //Play an animation of a group of objects or an object

    //Animated objects
    public GameObject animGam;
    //Animation Object Array
    public GameObject[] animGams;

    //First animation name
    public string animGamName1;
    //Second animation name
    public string animGamName2;

    //Record animation sequence
    public int N = 0;
    //Whether to play the animation when clicked
    public bool onMouseDownPlay = false;

    private void OnMouseDown()//On mouse click
    {
        //If you can click to play the animation
        if (onMouseDownPlay)
        {
            //Play animation
            PlayAnim();
        }
    }

    public void PlayAnim()
    {
        if(N==0)//Play the first animation
        {
            //If the animation array is empty
            if (animGams.Length==0)
            {
                //Activate animated objects
                animGam.SetActive(true);
                //Activate the animator component
                animGam.GetComponent<Animator>().enabled = true;
                //Play animation
                animGam.GetComponent<Animator>().Play(animGamName1, -1);
            }

            else//If the animation array is not empty
            {
                for(int i =0;i<animGams.Length;i++)
                {
                    //Activate all animation components
                    animGams[i].SetActive(true);
                    //Play animations
                    animGams[i].GetComponent<Animator>().Play(animGamName1, -1);
                }
            }

            N = 1;
        }
        else//Play the second animation
        {
            //If the animation array is empty
            if(animGams.Length==0)
            {
                //Play animation
                animGam.GetComponent<Animator>().Play(animGamName2, -1);
            }

            else// If the animation array is not empty
            {
                for (int i = 0; i < animGams.Length; i++)
                {
                    //Play animations
                    animGams[i].GetComponent<Animator>().Play(animGamName2, -1);
                }
            }

            N = 0;
        }
    }
}
