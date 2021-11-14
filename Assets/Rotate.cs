using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 5f;
    public float number = 10f;

    Quaternion angleRight = Quaternion.Euler(0, 0, 0);
    Quaternion angleLeft= Quaternion.Euler(0, 0, 180);

    public float minRot = 0f;
    public float maxRot = 180f;

    private float zRotation;

    public Vector3 rotEulerAngles;

    public float angle;

    /*public GameObject player_1;
    public Shooting shooting;
    public GameObject player_2;
    public Shooting shooting2;*/

    public void Update()
    {
        //player_1 = GameObject.FindGameObjectWithTag("Player1");
        //shooting = player_1.GetComponent<Shooting>();
        //if (shooting.hasShot == false)
        {
            zRotation = transform.eulerAngles.z;
            Aim();
            LimitRot();
        }
        
        //if (zRotation >= 0f && zRotation <= 180f)
        //if(zRotation >= minRot || zRotation <= maxRot)
        //if((zRotation >= 0) && (zRotation <= 180))
        //{
            //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
            

            /*if(zRotation == 0)
            {
                Debug.Log("Right");
            }*/
        //} 

       /*else if (zRotation < 0f && zRotation > -90f)
            {
                //zRotation = 10f;
            Debug.Log("A");
                //Aim();
            }
       else if (zRotation > -180f && zRotation < -90f)
            {
                //zRotation = 170f;
            Debug.Log("B");
                //Aim();
            }*/

        /*else if (zRotation < minRot || zRotation > maxRot)
        {
            zRotation += number;
            Aim();
        }*/


        //LimitRot();

        /*if (transform.rotation == angleRight)
        {
            Debug.Log("Right");
            transform.rotation = Quaternion.Euler(0, 0, 10);
        }
        if (transform.rotation == angleLeft)
        {
            Debug.Log("Left");
            transform.rotation = Quaternion.Euler(0, 0, 170);
        }*/

        /*if (transform.eulerAngles.z >= 0f && transform.eulerAngles.z <= 180f)
        {
            Debug.Log("Can shoot");
        }*/
    }

    public void Aim()
    {
        //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        transform.eulerAngles = Vector3.forward * angle;
    }

    private void LimitRot()
    {
        rotEulerAngles = transform.rotation.eulerAngles;

        if(rotEulerAngles.z > 180 && rotEulerAngles.z < 270)
        {
            rotEulerAngles.z = maxRot; //-= 1;
            //rotEulerAngles.z -= 360;
        }
        else if (rotEulerAngles.z > 270 && rotEulerAngles.z < 359)
        {
            rotEulerAngles.z = minRot;//-= 360;
        }
        //rotEulerAngles.z = (rotEulerAngles.z > 180) ? rotEulerAngles.z - 360 : rotEulerAngles.z;
        //rotEulerAngles.z = Mathf.Clamp(rotEulerAngles.z, minRot, maxRot);

        transform.rotation = Quaternion.Euler(rotEulerAngles);
    }

}
