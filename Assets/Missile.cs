using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    public Transform[] moveSpots2;
    public GameObject testSpot;
    public CalcTrajectory calcTrajectory;
    public CalcTrajectory calcTrajectory2;

    int nextPosIndex;
    Transform nextPos;
    Transform temp;

    public Transform testingAgain;
    public GameObject player_1;
    public GameObject player_2;

    bool targetReached = false;
    public static int spotNum = 0;

    public Turns turns;

    private float testNum;
    
    void Start()
    {
        //testSpot = GameObject.Find("testSpot");
        //moveSpots = calcTrajectory.spots.position;

        //moveSpots = calcTrajectory.spotsTest;
        //nextPos = moveSpots[0];
        //calcTrajectory = GameObject.Find("Player1").GetComponent<CalcTrajectory>();
        //moveSpots = calcTrajectory.spotsTest;

        //testingAgain = calcTrajectory.testingAgain;

        player_1 = GameObject.FindGameObjectWithTag("Player1");
        calcTrajectory = player_1.GetComponent<CalcTrajectory>();
        player_2 = GameObject.FindGameObjectWithTag("Player1");
        calcTrajectory2 = player_2.GetComponent<CalcTrajectory>();

        nextPos = moveSpots[0];
    }

    private void Awake()
    {
        //calcTrajectory = GameObject.Find("Player1").GetComponent<CalcTrajectory>();
        //moveSpots = calcTrajectory.spotsTest;
        nextPos = moveSpots[0];
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, moveSpots[].position, speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, testSpot.transform.position, speed * Time.deltaTime);
        //moveSpots = calcTrajectory.spotsTest;
        //MoveGameObject();
        //Test();
        //transform.position = Vector2.MoveTowards(transform.position, moveSpots[1].position, speed * Time.deltaTime);
        nextPos = moveSpots[0];
        TestingAgain();
        Test();
    }

    void MoveGameObject()
    {

        //nextPos = moveSpots[10];
        //int i = 0;
        //if (transform.position == nextPos.position)
        /*if(targetReached == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
        }

        if ((Vector2.Distance(transform.position, nextPos.position) < 0.2f))
        {
            //temp.position = nextPos.position;
            i++;
            Debug.Log(i);
            targetReached = true;
            //nextPosIndex++;

            //nextPos = moveSpots[nextPosIndex];
            nextPos = moveSpots[i];
            //Debug.Log(nextPos);
            //Debug.Log(nextPosIndex);

            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
           

        }*/
        if(Turns.pl1Turn)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[spotNum].position, speed * Time.deltaTime);

            if ((Vector2.Distance(transform.position, moveSpots[spotNum].position) < 0.2f))
            {
                //Debug.Log(spotNum);
                spotNum++;
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[spotNum].position, speed * Time.deltaTime);
            }
        }
        else if(Turns.pl2Turn)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots2[spotNum].position, speed * Time.deltaTime);

            if ((Vector2.Distance(transform.position, moveSpots2[spotNum].position) < 0.2f))
            {
                //Debug.Log(spotNum);
                spotNum++;
                transform.position = Vector2.MoveTowards(transform.position, moveSpots2[spotNum].position, speed * Time.deltaTime);
            }
        }
        
        /*else if ((Vector2.Distance(transform.position, nextPos.position) > 0.5f))
                    {
                        //Debug.Log("Oh");
                        targetReached = false;
                    }

        /*else
        {
            transform.position = Vector2.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }
        
        /*for(int i = 0; i < moveSpots.Length; i++)
        {
            targetReached = false;
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.2f)
            {
                targetReached = true;    
                //transform.position = Vector2.MoveTowards(transform.position, moveSpots[i++].position, speed * Time.deltaTime);
            }
            /*else
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
            }
        }*/
        

        /*targetReached = true;
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[10].position, speed * Time.deltaTime);
            nextPosIndex++;
            
            Debug.Log(nextPosIndex);
            /*if(nextPosIndex >= moveSpots.Length)
            {
                nextPosIndex = 0;
            }
        //nextPos = moveSpots[nextPosIndex];
        nextPos = moveSpots[10];
        //transform.position = Vector2.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);*/
    }

    void Test()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("adss");
            Debug.Log(nextPos.position);
            Debug.Log(moveSpots[5].position + " " + moveSpots[10].position);
            Debug.Log(moveSpots2[5].position + " " + moveSpots2[10].position);
        }
    }

    public void TestingAgain()
    {
        //if(Input.GetKeyDown(KeyCode.F))
        //{
        //nextPos = moveSpots[0];
        calcTrajectory = GameObject.Find("Player1").GetComponent<CalcTrajectory>();
            moveSpots = calcTrajectory.spotsTest;
        calcTrajectory2 = GameObject.Find("Player2").GetComponent<CalcTrajectory>();
        moveSpots2 = calcTrajectory2.spotsTest2;
        turns = GameObject.Find("GameManager").GetComponent<Turns>();
        testNum = GameObject.Find("Player1").GetComponent<Shooting>().forceNumber;
        //speed = testNum * 2;
        MoveGameObject();
        //Debug.Log(speed);
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(moveSpots[5].position + " " + moveSpots[10].position);
            Debug.Log(moveSpots2[5].position + " " + moveSpots2[10].position);
        }


        //}

    }
}
