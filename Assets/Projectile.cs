using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    public Healthbar healthBar;

    public GameObject healthBar1;

    public GameObject turns;

    Rigidbody2D rb;

    public Missile missile;

    public Shooting shooting1;
    public Shooting shooting2;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player1").transform;
        healthBar1 = GameObject.FindWithTag("HealthBar");
        turns = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody2D>();
        shooting1 = GameObject.Find("Player1").GetComponent<Shooting>();
        shooting2 = GameObject.Find("Player2").GetComponent<Shooting>();

        //target = new Vector2(player.position.x, player.position.y);
    }

    
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        /*if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }*/

        //float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        turns.GetComponent<Turns>().ChangeTurns();
        Missile.spotNum = 0;
        shooting1.hasShot = false;
        shooting2.hasShot = false;
    }

}
