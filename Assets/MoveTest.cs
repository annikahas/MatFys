using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    public GameObject testSpot;
    //public CalcTrajectory calcTrajectory;

    int nextPosIndex;
    Transform nextPos;
    void Start()
    {
        //testSpot = GameObject.Find("testSpot");
        //moveSpots = calcTrajectory.spots.position;

        //moveSpots = calcTrajectory.spotsTest;
        nextPos = moveSpots[0];
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, moveSpots[].position, speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, testSpot.transform.position, speed * Time.deltaTime);
        //moveSpots = calcTrajectory.spotsTest;
        MoveGameObject();
        //Test();
    }

    void MoveGameObject()
    {
        if (transform.position == nextPos.position)
        {
            nextPosIndex++;
            if (nextPosIndex >= moveSpots.Length)
            { 
                nextPosIndex = 0;
            }
            nextPos = moveSpots[nextPosIndex];
            //transform.position = Vector2.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("adss");
            Debug.Log(nextPos.position);
        }
    }
}
