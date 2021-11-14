using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 ePosition = new Vector2(0f, 0f);
    Vector2 velocity = new Vector2(0f, 0f);
    Vector2 acceleration = new Vector2(0f, 0f);

    float mass = 10f;
    Vector2 impulse = new Vector2(0f, 5f);
    Vector2 gravity = new Vector2(0f, -10f);
    Vector2 wind = new Vector2(1f, 0f);
    Vector2 sumForce = new Vector2(0f, 0f);

    public float timeTest;
    Vector2 dir;
    public Transform transformTest;

    public void Testing(Vector2 direction, Vector2 windVec)
    {
        velocity.Set(0f, 0f);
        ePosition.Set(0f, 0f);

        rb = GetComponent<Rigidbody2D>();

        for(int i=0; i<30 && ePosition.y > -0.1f;i++)
        {
                Debug.Log("Vx x=" + velocity.x + ", y=" + velocity.y);
                Debug.Log("Ep x=" + ePosition.x + ", y=" + ePosition.y);
            //sumForce = gravity + wind + impulse;
            AddForces(direction + windVec + gravity);
            //rb.AddForce(gravity + wind + impulse);
                //sumForce = direction + wind;
                //cceleration = sumForce/ mass;
                velocity += acceleration;
                ePosition += velocity;
            //transform.position = (ePosition * velocity * Time.deltaTime);
            //this.transform.position = ePosition;
            //rb.AddForce(transform.ePosition * velocity);
            //rb.velocity = ePosition * velocity; //(direction - ePosition) * velocity;
                                                //direction.Set(0f, 0f);
            impulse.Set(0f, 0f);
            acceleration.Set(0f, 0f);
            
                
            //rb.velocity = AddForce(direction + windVec + gravity);

            //rb.AddForce(gravity + wind + impulse);
        }
 
        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < 30; i++)
        {
            //Debug.Log("Vx x=" + velocity.x + ", y=" + velocity.y);
            //Debug.Log("Ep x=" + ePosition.x + ", y=" + ePosition.y);
            this.AddForces(gravity+wind+impulse);
            //this.AddForce(wind);
            //this.AddForce(impulse);
            velocity += acceleration;
            ePosition += velocity;

            impulse.Set(0f, 0f);
            acceleration.Set(0, 0);

        }
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown("space"))
        {
            //rb.AddForce(gravity + wind + impulse);
            Vector2 test = (gravity + wind + impulse);
            Debug.Log(test.x + " " + test.y);
            Testing(impulse, wind);
        }

        //rb.velocity = gravity + wind + impulse;
        //this.transform.position = ePosition;
    }

    void AddForces(Vector2 force)
    {
        sumForce += force;
        acceleration = sumForce / mass;
    }

    void Calc()
    {

    }

}
