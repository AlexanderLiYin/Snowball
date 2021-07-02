using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int initHealth;
    public HUDScript HUD;
    public float evadeChance;
    bool onTrench = false;
    int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
        HUD.HP(health);
    }

    public void TrenchStatus(bool status)
    {
        onTrench = status;
    }

    public void decHealth(int dmg)
    {
        if(onTrench)
        {
            if (evadeChance > Random.Range(0,99))
            {
                print("Miss");
                return;
            }
                
        }
        health -= dmg;
        HUD.HP(health);
        if (health <= 0)
        {
            print("Health is 0");
            FindObjectOfType<GameManager>().Lose();
        }
    }
}
