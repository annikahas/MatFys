using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathCalc : MonoBehaviour
{
    Vector2 gravity = new Vector2(0f, -9.8f);
   
    public float CalculateForce(float holdTime, float maxForce)
    {
        float maxTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxTime);
        float force = holdTimeNormalized * maxForce;
        return force;
    }

    public void CalculateAngle()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        //return angle;
    }

    public Vector2 CalculateTrajectory(float t, Vector2 curPosition, Vector2 dir, float force, float windNumber)
    {
        //position = startingpos + startingvelocity * t + 0.5 * acceleration * t^2
        //Vector2 currentPosition = curPosition + (dir * force * t) + 0.5f * gravity * (t * t);
        //Vector2 currentPosition = curPosition + (dir * force * t) + 0.5f * gravity * (t * t);
        Vector2 currentPosition = curPosition + (dir * (force - CalculateWindResistance(force)) * t) + 0.5f * (Physics2D.gravity + new Vector2(windNumber,0)) * (t * t);
        return currentPosition;
    }

    public Vector2 CalcTest(float t, Vector2 currentPosition, Vector2 currentVelocity, float mass)
    {
        //float mass = 10f;
        /*Vector2 curVelocity = currentVelocity / mass;
        //currentVelocity += gravity * t;
        curVelocity += gravity * t;
        //currentPosition += currentVelocity * t;
        currentPosition += curVelocity * t;
        return currentPosition;*/
        /*Vector2 curPosition;
        float x, y;
        curPosition.x = (currentPosition.x + currentVelocity.x * t);
        curPosition.y = (currentPosition.y + currentVelocity.y * t) - (gravity.y * t * t) / 2f;

        return curPosition;*/

        currentVelocity += gravity * t;
        Vector2 curVelocity = currentVelocity / mass;
        currentPosition += curVelocity * t;
        return currentPosition;
    }

    public Vector2 CalculateEuler(float t, Vector2 currentPosition, Vector2 currentVelocity, float mass)
    {
        /*Vector2 curVelocity = currentVelocity / mass;
        //currentVelocity += gravity * t;
        curVelocity += gravity * t;
        currentPosition += currentVelocity * t;
        return curVelocity;
        //return currentVelocity;*/

        //currentVelocity += gravity * t;
        //return currentVelocity;

        currentVelocity += gravity * t;
        Vector2 curVelocity = currentVelocity / mass;
        currentPosition += currentVelocity * t;
        return curVelocity;
    }

    public Vector2 TestCalculateEuler(float t, Vector2 curPosition, Vector2 direction, Vector2 force, float forceNumber, float mass)
    {
        //Vector2 velocity = forceNumber * Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Vector2 forces = force;

        Vector2 startVelocity = forceNumber * direction * t;
        Vector2 acceleration = startVelocity + force / mass;
        //Vector2 velocity += acceleration * t;
        //Vector2 position += velocity;
        //Vector2 currentVelocity = direction * forceNumber * t + acceleration * t;
        Vector2 currentVelocity = startVelocity + acceleration * t;
        Vector2 currentPosition = curPosition + currentVelocity * t;
        acceleration.Set(0, 0);
        //force.Set(0, 0);
        /*for (int i = 0; i < 30; i++)
        {
            acceleration = force / mass;
            currentVelocity += acceleration;
            currentPosition += currentVelocity;
            acceleration.Set(0, 0);
            //direction.Set(0, 0);
        }*/

        return currentPosition;
    }

    public float CalculateWindResistance(float forceNumber)
    {
        float windResistance = 0.5f * 1.2754f * forceNumber * forceNumber * 3.14159f * 0.25f * 0.34f;
        return windResistance;
    }

    /* Fv = ½ s v^2 A Cv
     * Fv = vastusvoima
     * s = ilman tihesy 1,2754
     * v = kappaleen nopeus forceNumber
     * A = poikkipinta-ala liikettä vastaa kohtisuorassa asennpssa pii * halkaisija
     * Vc = muotokerroin 0,34 tai 0,44
     */

    /*Test
     * Trajectory
      //position = startingpos + startingvelocity * t + 0.5 * acceleration * t^2
        //Vector2 position = (Vector2)firePoint.position + (direction.normalized * forceNumber * t) + 0.5f * Physics2D.gravity * (t * t);
        Vector2 currentPosition = curPosition + (dir * force * t) + 0.5f * gravity * (t * t);
        //Vector2 currentPosition = curPosition + (dir * force * t) + 0.5f * (Physics2D.gravity + new Vector2(windNumber,0)) * (t * t);
        return currentPosition;

        eulertest //dir, float force, float mass, float velocity)
    Vector2 currentPosition = new Vector2(0f,0f);
            Vector2 currentVelocity = new Vector2(0f,0f);

            float acceleration = force / mass;
            Vector2 startVelocity = dir * force * t;
            float curVelocity = force + acceleration * t;
    currentVelocity += gravity* t;
    currentPosition += currentVelocity* t;
        //Vector2 curVelocity = currentVelocity + Physics2D.gravity * t;
        //Vector2 curPosition = currentPosition + curVelocity * t;
        return currentPosition;
*/
}
