using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public int currentHealth;
    public int startHealth;
    public int maxHealth;

    public void Initalize()
    {
        startHealth = 150;
        currentHealth = startHealth;
        maxHealth = 200;
    }

    public int AddHealth(int heal)
    {
        currentHealth += Math.Abs(heal);
        return currentHealth;
    }

    public int RemoveHealth(int damage)
    {
        currentHealth -= Math.Abs(damage);
        return currentHealth;
    }

    public void IncreaseHealthPool(int moreHealth)
    {
        maxHealth += Math.Abs(moreHealth);
    }

    public void DecreaseHealthPool(int lessHealth)
    {
        maxHealth -= Math.Abs(lessHealth);
    }
}
