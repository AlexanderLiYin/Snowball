using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int maxHealth = 20;
    public int initHealth = 20;
    int health;

    void Start()
    {
        health = initHealth;
    }

    public void decHealth(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
