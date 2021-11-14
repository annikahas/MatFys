using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcTrajectory : MonoBehaviour
{
    public Transform firePoint;
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    public float forceTest;

    public Turns turns;
    public MathCalc mathCalc; 
    public float maxForce = 1;

    public Wind wind;

    public GameObject spot;
    public GameObject[] spots;
    public GameObject[] spots2;
    public Transform spotTest;
    public Transform[] spotsTest;
    public Transform[] spotsTest2;
    public GameObject spotTesters; 

    Vector3 velocity = new Vector3(0f, 0f, 0f);
    Vector3 acceleration = new Vector3(0f, -9.8f, 0f);
    Vector3 forces = new Vector3(0f, 0f, 0f);
    Vector3 directionTest;
    Vector3 position;

    public GameObject bulletPrefab;
    Rigidbody2D rb;
    public float speed = 5f;

    public GameObject missilePrefab;
    int nextPosIndex;
    Transform nextPos;

    //public Transform testingAgain;
    public Missile missileTest;
    public Shooting shooting;
    public Shooting shooting2;
    public GameObject player_1;
    public GameObject player_2;

    public Vector2 distance;
    float time;
    float prevTime;
    Vector3 curVelocity = new Vector3(0f, 0f, 0f);
    Vector3 curPosition = new Vector3(0f, 0f, 0f);
    Vector3 gravity = new Vector3(0f, -9.8f, 0f);

    public float testNum;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, firePoint.position, Quaternion.identity);
        }

        point.GetComponent<Renderer>();

        spots = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            spots[i] = Instantiate(spot, firePoint.position, Quaternion.identity);
        }

        spots2 = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            spots2[i] = Instantiate(spotTesters, firePoint.position, Quaternion.identity);
        }

        spotsTest = new Transform[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            spotsTest[i] = spots[i].transform;//Instantiate(spotsTest, firePoint.position, Quaternion.identity);
        }

        spotsTest2 = new Transform[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            spotsTest2[i] = spots2[i].transform;//Instantiate(spotsTest, firePoint.position, Quaternion.identity);
        }

        spot.GetComponent<Renderer>();

        nextPos = spotsTest[0];
        nextPos = spotsTest2[0];

        player_1 = GameObject.FindGameObjectWithTag("Player1");
        shooting = player_1.GetComponent<Shooting>();

        player_2 = GameObject.FindGameObjectWithTag("Player2");
        shooting2 = player_2.GetComponent<Shooting>();

    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) - firePoint.position;
        directionTest = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - firePoint.position;
        distance = direction.normalized;

        //Testing();

        //if (Turns.pl1Turn)
        //{
        if (this.CompareTag("Player1"))
            {
                //point.GetComponent<Renderer>().enabled = true;
                //point.SetActive(true);
                if(Turns.pl1Turn)
                {
                curPosition = firePoint.position;
                curVelocity = direction * maxForce;
                    for (int i = 0; i < points.Length; i++)
                    {
                        //points[i].SetActive(true);
                        points[i].GetComponent<Renderer>().enabled = true;
                    spots[i].GetComponent<Renderer>().enabled = true;
                    //points[i].GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                    }
                    for (int i = 0; i < points.Length; i++)
                    { 
                        
                        if(shooting.hasShot == true)
                        {
                        points[i].transform.position = points[i].transform.position;
                        }
                    else
                    {
                        points[i].transform.position = mathCalc.CalculateTrajectory(i * spaceBetweenPoints, firePoint.position, direction, maxForce, Wind.windNumber);  
                    }
                    }

                    for (int i = 0; i < spots.Length; i++)
                    {
                        if(shooting.hasShot == true)
                    {
                        spots[i].transform.position = spots[i].transform.position;
                        spotsTest[i] = spots[i].transform;
                    }
                    else
                    {
                        spots[i].transform.position = mathCalc.CalcTest(i * spaceBetweenPoints, firePoint.position, maxForce*direction+new Vector2(Wind.windNumber,0f), testNum);//+new Vector2(Wind.windNumber, 0f));
                        /*position = firePoint.position;
                        velocity = maxForce * direction;
                        time = i * spaceBetweenPoints;
                        curVelocity += velocity * time;
                        curPosition += position + curVelocity * time;
                        spots[i].transform.position = curPosition;*/
                        
                        //time = i * spaceBetweenPoints;
                        //curVelocity = maxForce * direction + 0.6f * Physics2D.gravity * time;
                        //velocity = curVelocity +  maxForce * directionTest + gravity * time; ;
                        //acceleration = Physics2D.gravity * time;
                        //curVelocity += acceleration;
                        //curPosition = firePoint.position + curVelocity * time;
                        //curPosition = firePoint.position + velocity * time;
                        //position = curVelocity * time;
                        //curPosition += position;
                        //spots[i].transform.position = curPosition;
                        spotsTest[i] = spots[i].transform;
                    }


                    /*if(i==0)
                    {
                        points[i].transform.position = firePoint.position;
                    }

                    else
                    {
                    velocity += (directionTest * maxForce + new Vector3(0, -9.8f, 0)) * i * spaceBetweenPoints;
                    position += velocity * i * spaceBetweenPoints;
                    points[i].transform.position = position + points[i-1].transform.position;
                    }*/



                    /*if(Input.GetKeyDown(KeyCode.S))
                    {
                        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                        rb = bullet.GetComponent<Rigidbody2D>();
                        rb.MovePosition(spots[i].transform.position + directionTest * maxForce * Time.deltaTime);
                    }*/
                    //for (int i = 0; i < points.Length; i++)
                    //{
                    /*if (i == 0)
                    {
                        spots[i].transform.position = mathCalc.CalcTest(i * spaceBetweenPoints, firePoint.position, maxForce * direction);
                    }
                    else
                    {
                        Vector3 temp = spots[i - 1].transform.position;
                        spots[i].transform.position = mathCalc.CalcTest(i * spaceBetweenPoints, firePoint.position, maxForce * direction);
                    }*/

                    //}
                    /*forces = acceleration + directionTest * maxForce;
                    velocity += forces * i * spaceBetweenPoints;
                    spots[i].transform.position += velocity * i * spaceBetweenPoints;*/
                }
            }
                else
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        //points[i].SetActive(false);
                        points[i].GetComponent<Renderer>().enabled = false;
                    spots[i].GetComponent<Renderer>().enabled = false;
                    //points[i].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                }
                }
            Testing();

        }
            if (this.CompareTag("Player2"))
            {
                if (Turns.pl1Turn)
                {
                     //point.GetComponent<Renderer>().enabled = false;
                     //point.SetActive(false);
                     for (int i = 0; i < points.Length; i++)
                     {
                        //points[i].SetActive(false);
                        points[i].GetComponent<Renderer>().enabled = false;
                    spots[i].GetComponent<Renderer>().enabled = false;
                    //points[i].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                }
                }
                else
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        //points[i].SetActive(true);
                        points[i].GetComponent<Renderer>().enabled = true;
                    spots[i].GetComponent<Renderer>().enabled = true;
                    //points[i].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                }
                    for (int i = 0; i < points.Length; i++)
                    {
                        if(shooting2.hasShot == true)
                    {
                        points[i].transform.position = points[i].transform.position;
                    }
                    else
                    {
                        points[i].transform.position = mathCalc.CalculateTrajectory(i * spaceBetweenPoints, firePoint.position, direction, maxForce, Wind.windNumber);
                    }
                        
                    }
                for (int i = 0; i < spots.Length; i++)
                {
                    
                    if(shooting2.hasShot == true)
                    {
                        spots[i].transform.position = spots[i].transform.position;
                    }
                    else
                    {
                        spots[i].transform.position = mathCalc.CalcTest(i * spaceBetweenPoints, firePoint.position, maxForce * direction + new Vector2(Wind.windNumber, 0f), testNum);
                    }
                    //spotsTest2[i] = spots[i].transform;
                    //Debug.Log(spotsTest2[3].position);
                }

                for (int i = 0; i < spots2.Length; i++)
                {
                    if(shooting2.hasShot == true)
                    {
                        spots2[i].transform.position = spots2[i].transform.position;
                        spotsTest2[i] = spots2[i].transform;
                    }
                    else
                    {
                        spots2[i].transform.position = mathCalc.CalcTest(i * spaceBetweenPoints, firePoint.position, maxForce * direction, testNum);
                        spotsTest2[i] = spots2[i].transform;
                    }

                    //Debug.Log(spotsTest2[3].position);
                }
            }
            }
            
        //}

        /*if (Turns.pl2Turn)
        {
            if (this.tag == "Player2")
            {
                //point.SetActive(true);
                //point.GetComponent<Renderer>().enabled = true;
                for (int i = 0; i < points.Length; i++)
                {
                    //points[i].SetActive(true);
                    points[i].GetComponent<Renderer>().enabled = true;
                    points[i].GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                }
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].transform.position = mathCalc.CalculateTrajectory(i * spaceBetweenPoints, firePoint.position, direction, maxForce);
                }
            }

            if (this.tag == "Player1")
            {
                //point.SetActive(false);
                //point.GetComponent<Renderer>().enabled = false;
                for (int i = 0; i < points.Length; i++)
                {
                    //points[i].SetActive(false);
                    points[i].GetComponent<Renderer>().enabled = false;
                    points[i].GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                }
            }
        }*/

        void Testing()
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log(spotsTest[2].position);
                Debug.Log(nextPos.position);
                GameObject missile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
                missileTest.TestingAgain();
                //missile.transform.position = Vector2.MoveTowards(missile.transform.position, testingAgain.position, speed * Time.deltaTime);

                /*if (missile.transform.position == nextPos.position)
                {
                    Debug.Log("In position");
                    nextPosIndex++;
                    if (nextPosIndex >= spotsTest.Length)
                    {
                        nextPosIndex = 0;
                    }
                    nextPos = spotsTest[nextPosIndex];
                    //missile.transform.position = Vector2.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
                }
                else
                {
                    Debug.Log("Not in position");
                    missile.transform.position = Vector2.MoveTowards(missile.transform.position, nextPos.position, speed * Time.deltaTime);
                }*/
            }

                

        }
    }

    void MoveGameObject()
    {
        
    }
}
