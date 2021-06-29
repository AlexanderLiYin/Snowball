using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int initHealth;
    int health;
    public HealthBar hpBar;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
    }

    public void decHealth(int dmg)
    {
        health -= dmg;
        hpBar.HP(health);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
