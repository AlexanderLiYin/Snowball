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

    bool onTrench = false;
    public float evadeChance = 10;
    public event Action<int> OnDmgTaken;
    public event Action<EnemyHealth> OnDefeat;
    public int group;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
    }

    public void decHealth(int dmg)
    {
        OnDmgTaken.Invoke(group); //Tell the game manager that an enemy has taken damage
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
            OnDefeat.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void TrenchStatus(bool status)
    {
        onTrench = status;
    }
}
