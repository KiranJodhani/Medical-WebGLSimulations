using UnityEngine;
using System.Collections;

public class Trun_CameraLens : MonoBehaviour {
    //** For three Objective lenses **
    //--Mouse-drag rotation objective  

    //Rotating object
    public GameObject dragGam;
    //Camera showing cells,High resolution
    public GameObject cellsCamera;
    //Camera showing cells,Low resolution
    public GameObject cellsCameraLow;
    //Black shadow blocking the objective
    public GameObject UIMask;

    //Mouse down
    public bool mouseDown = false;

    //--Rotate the objective lens When you release the mouse, the objective lens will automatically rotate to the appropriate angle
    //Define an angle value
    public float _rotation;
    //Define the angle value of the alignment objective,_rotation1
    public float _rotation1;
    //Define the angle value of the alignment objective,_rotation2
    public float _rotation2;
    //Define the angle value of the alignment objective,_rotation3
    public float _rotation3;
    //Define the angle value of the alignment objective,_rotation4
    public float _rotation4;

    //Microscope objective multiple
    public int lensMultiples = 0;
    //Display objective multiples
    public GameObject magnificationText;
    //Follow the mouse, the sprite that rotates together
    public GameObject dragGamSprite;

    //Mouse drag
    void OnMouseDrag ()     
	{
        //mouseDown is true
        mouseDown = true;
        //TextMesh displays objective multiples
        magnificationText.GetComponent<TextMesh>().text ="X"+ lensMultiples.ToString();
        //Drag object and rotate this object
        GetComponent<dragRotate>().dragTo(dragGam.transform);
        //Sprite following rotation
        dragGamSprite.transform.localEulerAngles =new Vector3 (0,0, -dragGam.transform.localEulerAngles.z) ;
    }

	void Update ()
	{
        //When the animal lens is rotated, in order to simulate a real scene, the objective lens will have a black shadow passing by.
        //Shadow rotation
        UIMask.transform.eulerAngles = new Vector3(UIMask.transform.eulerAngles.x, UIMask.transform.eulerAngles.y, dragGam.transform.eulerAngles.z+60);
        //Left mouse button up
        if (Input.GetMouseButtonUp(0))
        {
            //mouseDown is false
            mouseDown = false;
        }
	}

    void LateUpdate()
    {

        //---Automatically aim at the nearest eyepiece after dragging
        //Select one closer to the object from "_rotation1" and "_rotation2" and assign it to "_Rot1"
        float _Rot1 = Mathf.Abs(dragGam.transform.eulerAngles.z - _rotation1) < Mathf.Abs(dragGam.transform.eulerAngles.z - _rotation2) ? _rotation1 : _rotation2;
        //Select one closer to the object from "_Rot1" and "_rotation3" and assign it to "_Rot2"
        float _Rot2 = Mathf.Abs(dragGam.transform.eulerAngles.z - _Rot1) < Mathf.Abs(dragGam.transform.eulerAngles.z - _rotation3) ? _Rot1 : _rotation3;
        //Select one closer to the object from "_Rot2" and "_rotation4" and assign it to "_Rot3"
        float _Rot3 = Mathf.Abs(dragGam.transform.eulerAngles.z - _Rot2) < Mathf.Abs(dragGam.transform.eulerAngles.z - _rotation4) ? _Rot2 : _rotation4;

        //
        if (_Rot3 == _rotation1)
        {
            //Change microscope lens magnification
            lensMultiples = 40;
            //Adjust camera field of view
            cellsCamera.GetComponent<Camera>().fieldOfView = 12f;
        }
        if (_Rot3 == _rotation2)
        {
            //Change microscope lens magnification
            lensMultiples = 10;
            //Adjust camera field of view
            cellsCamera.GetComponent<Camera>().fieldOfView = 32f;

        }
        if (_Rot3 == _rotation3 || _Rot3 == _rotation4)
        {
            //Change microscope lens magnification
            lensMultiples = 4;
            //Adjust camera field of view
            cellsCamera.GetComponent<Camera>().fieldOfView = 58f;

        }

        //Make both cameras have the same field of view
        cellsCameraLow.GetComponent<Camera>().fieldOfView = cellsCamera.GetComponent<Camera>().fieldOfView;

        //If the mouse is raised
        if (mouseDown == false)
        {
            //Objective lens angle is gradually approaching "_Rot3"
            _rotation = Mathf.Lerp(dragGam.transform.eulerAngles.z, _Rot3, Time.deltaTime * 10f);
            //Automatically aligns to the nearest eyepiece
            dragGam.transform.eulerAngles = new Vector3(dragGam.transform.eulerAngles.x, dragGam.transform.eulerAngles.y, _rotation);
        }
    }

}
	
		
		
		
		
		
		
		
