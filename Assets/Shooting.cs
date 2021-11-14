using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;

    public float bulletForce = 20f;
     
    public static int Ammo = 1;

    [SerializeField] bool mouseDown = false;

    public TMP_Text force;
    private float mouseStartTime;
    public float maxForce = 2f;

    public MathCalc mathCalc;
    public float forceNumber;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    public float forceTest;

    public Turns turns;
    public Test test;

    Vector2 testVector;

    public GameObject spot;
    GameObject[] spots;

    Vector2 acceleration = new Vector2(0f, 0f);
    Vector2 sumForce = new Vector2(0f, 0f);
    Vector2 ePosition = new Vector2(0f, 0f);
    Vector2 velocity = new Vector2(0f, 0f);

    float mass = 10f;
    public float speed = 1f;

    public GameObject gameOverMenu;
    public GameOver gameOverMenu2;
    public GameObject startMenu;

    public bool hasShot;
    public float testMass;
    private void Start()
    {
        /*points = new GameObject[numberOfPoints];
        for(int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, firePoint.position, Quaternion.identity);
        }

        point.GetComponent<Renderer>();*/

        /*spots = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            spots[i] = Instantiate(spot, firePoint.position, Quaternion.identity);
        }

        spot.GetComponent<Renderer>();

        missilePrefab.GetComponent<Rigidbody2D>();*/
        gameOverMenu = GameObject.Find("GameOverMenu");
        gameOverMenu2 = GameObject.Find("GameOver").GetComponent<GameOver>();
        //startMenu = GameObject.Find("StartMenu");
        hasShot = false;
    }

    void Update()
    {

        direction = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)) - firePoint.position;

        /*for (int i = 0; i < spots.Length; i++)
        {
            //spots[i].transform.position = mathCalc.CalculateEuler(i * spaceBetweenPoints, firePoint.position, direction, direction * maxForce + Physics2D.gravity + new Vector2(Wind.windNumber, 0), maxForce, 10f);
            spots[i].transform.position = mathCalc.CalcTest(i * spaceBetweenPoints, firePoint.position, maxForce * direction);
        }*/

        if (Ammo > 0 && GameOver.isActive == false)// && !startMenu.activeInHierarchy)
        {
            
            if (Input.GetMouseButtonDown(0))  // GetButtonDown("Fire1"))
            {
                mouseDown = true;
                mouseStartTime = Time.time;
                /*if(Ammo > 0)
                {
                     Shoot();
                }*/
            } 
            if(Input.GetMouseButton(0))
            {
                float holdDownTime = Time.time - mouseStartTime;
                //CalculateForce(holdDownTime);
                force.text = mathCalc.CalculateForce(holdDownTime, maxForce).ToString();
                /*for (int i = 0; i < points.Length; i++)
                {
                    points[i].transform.position = mathCalc.PointPosition(i * spaceBetweenPoints, firePoint.position, direction, maxForce);
                }*/
            }

            if(Input.GetMouseButtonUp(0))
            {
                float holdDownTime = Time.time - mouseStartTime;
                forceNumber = mathCalc.CalculateForce(holdDownTime, maxForce);
                mouseDown = false;
            
                //if (Ammo > 0)
                //{
                    Shoot();
                //}
                force.text = 0.ToString();
                hasShot = true;
            }

            if (Input.GetMouseButtonDown(1))  // GetButtonDown("Fire1"))
            {
                mouseDown = true;
                mouseStartTime = Time.time;
                /*if(Ammo > 0)
                {
                     Shoot();
                }*/
            }
            if (Input.GetMouseButton(1))
            {
                float holdDownTime = Time.time - mouseStartTime;
                //CalculateForce(holdDownTime);
                force.text = mathCalc.CalculateForce(holdDownTime, maxForce).ToString();


            }

            if (Input.GetMouseButtonUp(1))
            {
                float holdDownTime = Time.time - mouseStartTime;
                forceNumber = mathCalc.CalculateForce(holdDownTime, maxForce);
                mouseDown = false;

                //if (Ammo > 0)
                //{
                TestShoot();
                //}
                force.text = 0.ToString();
                hasShot = true;
            }
        }

        
        
        /*else
        {
            mouseDown = false;
            force.text = 0.ToString();
        }*/
        /*if (Input.GetButtonDown("Fire2"))
        {
            Ammo += 1;
        }*/
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - firePoint.position;
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<Rigidbody2D>().velocity = (direction + new Vector2(Wind.windNumber, 0)) * (forceNumber - mathCalc.CalculateWindResistance(forceNumber));
        mathCalc.CalculateWindResistance(forceNumber);
        testVector = direction * (forceNumber - mathCalc.CalculateWindResistance(forceNumber));
        //Debug.Log(mathCalc.CalculateWindResistance(forceNumber));
        //bullet.GetComponent<Rigidbody2D>().velocity = direction * forceNumber;
        //test.Testing((direction * forceNumber), new Vector2(Wind.windNumber*0.1f, 0));
        //Debug.Log(direction.x + " " + direction.y);
        //Debug.Log(testVector.x + " " + testVector.y);
        //test.Testing(testVector, new Vector2(Wind.windNumber, 0));
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Ammo -= 1;
    }

    void TestShoot()
    {
        GameObject missile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        //Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - firePoint.position;
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //missile.GetComponent<Rigidbody2D>().velocity = direction * forceNumber;
        //missile.transform.position = mathCalc.CalculateTrajectory(1, firePoint.position, direction, maxForce, Wind.windNumber);
        //testVector = direction * (forceNumber - mathCalc.CalculateWindResistance(forceNumber));
        //missile.GetComponent<Rigidbody2D>().velocity = mathCalc.CalculateEuler(spaceBetweenPoints, firePoint.position, direction, direction * maxForce + Physics2D.gravity + new Vector2(Wind.windNumber, 0), maxForce, 10f);
        //missile.GetComponent<Rigidbody2D>().AddForce(TestCalc());
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        //Vector3 temp = mathCalc.CalcTest(1, firePoint.position, maxForce * direction);
        Vector2 wind = new Vector2(Wind.windNumber, 0f) * (forceNumber - mathCalc.CalculateWindResistance(forceNumber));
        Vector3 temp = mathCalc.CalculateEuler(spaceBetweenPoints, firePoint.position, forceNumber * direction + wind, testMass);
        //missile.GetComponent<Rigidbody2D>().velocity = temp * (forceNumber - mathCalc.CalculateWindResistance(forceNumber));
        //missile.GetComponent<Rigidbody2D>().MovePosition(transform.position + temp);
        missile.GetComponent<Rigidbody2D>().velocity=temp;

        //TestCalc();
        Ammo -= 1;
    }

    void TestCalc()
    {
        GameObject missile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        for (int i = 0; i < 30; i++)
        {
            //Debug.Log("Vx x=" + velocity.x + ", y=" + velocity.y);
            Debug.Log("Ep x=" + ePosition.x + ", y=" + ePosition.y);
            this.AddForcesTest(direction * maxForce+Physics2D.gravity);
            //this.AddForce(wind);
            //this.AddForce(impulse);
            velocity += acceleration;
            ePosition += velocity;
            missile.GetComponent<Rigidbody2D>().AddForce(ePosition);
            //impulse.Set(0f, 0f);
            acceleration.Set(0, 0);
            
        }
    }

    void AddForcesTest(Vector2 force)
    {
        sumForce += force;
        acceleration = sumForce / mass;
    }
}
