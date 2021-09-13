using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int initHealth;
    int health;
    public HealthBar hpBar;
    public bool isBoss;

    public event EventHandler OnDmgTaken;
    bool onTrench = false;
    public float evadeChance = 10;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
        OnDmgTaken += Alert;
    }

    void Alert(object sender, EventArgs e)
    {
        print("Alert!");
    }

    public void decHealth(int dmg)
    {
        OnDmgTaken(this,EventArgs.Empty);
        if (onTrench)
        {
            if (evadeChance > UnityEngine.Random.Range(0, 99))
            {
                print("Miss");
                return;
            }

        }
        health -= dmg;
        hpBar.HP(health);
        if(health <= 0)
        {
            if(isBoss)
            {
                FindObjectOfType<GameManager>().Win();
            }
            Destroy(gameObject);
        }
    }

    public void TrenchStatus(bool status)
    {
        onTrench = status;
    }
}
