using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HUDScript HUD;
    public int maxHealth;
    public int initHealth;
    int health;
    public float evadeChance = 10;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
        HUD.HP(health);
    }

    public void decHealth(int dmg)
    {
        health -= dmg;
        HUD.HP(health);
        if (health <= 0)
        {
            print("Health is 0");
            FindObjectOfType<GameManager>().Lose();
        }
    }
}
