using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public Healthbar healthBar;
    public int number;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            healthBar.TakeDamage(number);
        }
        if (collision.gameObject.tag == "Missile")
        {
            healthBar.TakeDamage(number*2);
        }
    }
}
