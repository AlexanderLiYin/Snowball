using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int initHealth;
    public HUDScript HUD;
    public PlayerMovement movement;
    public float evadeChance = 10;
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
        if(onTrench == true)
        {
            movement.movespeed = 7;
        }
        else if (onTrench == false)
        {
            movement.movespeed = 5;
        }
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
