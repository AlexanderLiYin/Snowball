using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int initHealth;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
    }

    public void decHealth(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
