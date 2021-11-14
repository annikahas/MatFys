using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;

    public int maxHealth = 10;
    public int currentHealth;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth);
    }

    public void AddHealth(int health)
    {
        if (currentHealth + health < maxHealth)
        {
            currentHealth += health;
            SetHealth(currentHealth);
        }

        else
        {
            currentHealth = maxHealth;
            SetHealth(currentHealth);
        }

    }
}
