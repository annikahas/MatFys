using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItest : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public AmmoCounter ammoCounter;

    public Healthbar healthBar;

    public Turns turns;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    private void Update()
    {
        //if(PauseMenu.isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //TakeDamage(2);
                //healthBar.TakeDamage(2);
                turns.ChangeTurns();
            }

            if (Input.GetMouseButtonDown(1))
            {
                //ammoCounter.ReduceAmmo(2);
            }

            if (Input.GetMouseButtonDown(0))
            {
                //ammoCounter.MaxAmmo();
                //healthBar.AddHealth(5);
            }
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
