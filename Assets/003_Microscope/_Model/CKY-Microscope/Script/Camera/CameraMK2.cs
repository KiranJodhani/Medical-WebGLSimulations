using UnityEngine;
 
public class CameraMK2 : MonoBehaviour
{
    //Camera rotates automatically
    public bool runRotate = false;

    //Camera Movement Center
    public Transform target;

    //The longest distance of the camera
    public float maxDistance = 20;

    //Camera closest distance
    public float minDistance = 0.6f;

    //Camera X axis moving speed
    public float xSpeed = 200.0f;

    //Camera Y axis moving speed
    public float ySpeed = 200.0f;

    //Camera Y-axis Max
    public int yMinLimit = -80;

    //Camera Y-axis minimum
    public int yMaxLimit = 80;

    //Mouse wheel speed
    public int zoomRate = 40;

    //Camera movement damping
    public float zoomDampening = 5.0f;

    //Live camera X axis angle
    public float xDeg = 0.0f;
    //Live camera Y axis angle
    public float yDeg = 0.0f;

    //Camera current distance
    public float currentDistance;
    //Camera desired distance
    public float desiredDistance;


    //Camera current rotation
    private Quaternion currentRotation;
    //Camera desired rotation
    private Quaternion desiredRotation;

    public Quaternion rotation;
    private Vector3 position;

    //Whether the mouse clicks on the object
    bool MouseOnGam = false;

    int NN = 0;
    
    void Start()
    {
        NN = 0;
        //Set initial distance
        desiredDistance = 32;
        //Set the initial X-axis angle
        yDeg = 8;
        //Set the initial Y-axis angle
        xDeg = 0;
    }

    public void Rotate()
    {
        //Whether the camera rotates automatically
        runRotate = !runRotate;
    }
 
    private void Update()
    {
        //If the camera rotates automatically
        if (runRotate)
        {
            //X axis slowly increases
            xDeg += 0.1f;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            NN++;
            ScreenCapture.CaptureScreenshot(NN.ToString()+".png", 0);
        }

        //Determine if the mouse is clicked on the microscope
        if (Input.GetMouseButtonDown(0))
        {
            //Camera emits rays
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //If you click on an object
            if (Physics.Raycast(ray, out hit))
            {
                MouseOnGam = true;
            }
            //If the point is not hit on the object
            else
            {
                MouseOnGam = false;
            }
        }
        //No mouse click on object when mouse is raised
        if (Input.GetMouseButtonUp(0))
        {
            MouseOnGam = false;
        }

    }
    void LateUpdate()
    {
        //The mouse did not click on the object
        if (MouseOnGam == false)
        {
            //Mouse is down
            if (Input.GetMouseButton(0))
            {
                //Get mouse move distance along screen X
                xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;

                //Get mouse move distance along screen Y
                yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }

            //Constraint Y value between "yMaxLimit" and "yMinLimit"
            yDeg = Mathf.Clamp(yDeg, yMinLimit, yMaxLimit);

            //Assign xDeg and yDeg to desiredRotation
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);

            //Mouse wheel to adjust camera distance
            desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);

            //Camera distance between "minDistance" and "maxDistance"
            desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);

            //Smooth movement."currentDistance" is equal to linear interpolation between "currentDistance" and "desiredDistance"
            currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);

            //Smooth movement."rotation" is equal to linear interpolation between "transform.rotation" and "desiredRotation"
            rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * zoomDampening);

            //rotation update
            transform.rotation = rotation;

            //Get the position after moving
            position = target.position - (rotation * Vector3.forward * currentDistance );

            //position update
            transform.position = position;

        }
        
    }



}