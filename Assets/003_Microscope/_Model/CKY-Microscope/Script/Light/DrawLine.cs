using UnityEngine;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    //Starting point of the line
    public Transform transStart;

    //End point of the line
    public Transform transEnd;

    //Key points of the line through which the lines are refracted
    public List<Transform> gameOjbet_tran = new List<Transform>();

    //Render all points of the line
    private List<Vector3> point = new List<Vector3>();

    //Store all calculated points
    Vector3[] Positions;

    void Init()
    {
        //initialization
        point = new List<Vector3>();

        //Add starting point to List
        point.Add(transStart.transform.position);

        //Add the calculated points to the List
        for (int i = 0; i < 200; i++)
        {

            //Select a few points between the first and second points
            Vector3 pos1 = Vector3.Lerp(gameOjbet_tran[0].position, gameOjbet_tran[1].position, i / 100f);
            //Select a few points between the second and third points
            Vector3 pos2 = Vector3.Lerp(gameOjbet_tran[1].position, gameOjbet_tran[2].position, i / 100f);
            //Select a few points between the third and fourth points
            Vector3 pos3 = Vector3.Lerp(gameOjbet_tran[2].position, gameOjbet_tran[3].position, i / 100f);
            //Select a few points between the fourth and fifth points
            Vector3 pos4 = Vector3.Lerp(gameOjbet_tran[3].position, gameOjbet_tran[4].position, i / 100f);

            //Select a few points between pos1 and pos2
            var pos1_0 = Vector3.Lerp(pos1, pos2, i / 100f);
            //Select a few points between pos2 and pos3
            var pos1_1 = Vector3.Lerp(pos2, pos3, i / 100f);
            //Select a few points between pos3 and pos4
            var pos1_2 = Vector3.Lerp(pos3, pos4, i / 100f);

            //Select a few points between pos1_0 and pos1_1
            var pos2_0 = Vector3.Lerp(pos1_0, pos1_1, i / 100f);
            //Select a few points between pos1_1 and pos1_2
            var pos2_1 = Vector3.Lerp(pos1_1, pos1_2, i / 100f);

            //Select a few points between pos1_1 and pos1_2
            Vector3 find = Vector3.Lerp(pos2_0, pos2_1, i / 100f);

            //Add 200 subdivisions between points in gameOjbet_tran. Add to list.
            point.Add(find);
        }

        //Add end point to List
        point.Add(transEnd.transform.position);

    }
   

    public void getLine()
    {
        //Get point list
        Init();

        //Initialize the array to store the list
        Positions = new Vector3[point.Count];

        //Place the points in the list into "Positions"
        for (int i = 0; i < point.Count ; i++)
        {
            Positions[i] = point[i];
        }
        //Define positionCount in LineRenderer
        GetComponent<LineRenderer>().positionCount = point.Count;
        //Add the points obtained above to the LineRenderer
        GetComponent<LineRenderer>().SetPositions(Positions);
    }

    private void Start()
    {
        //Generate a line
        getLine();
    }

}