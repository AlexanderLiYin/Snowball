using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int initHealth;
    int health;
    public HUDScript HUD;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
        HUD.HP(health);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            health -= 1;
            HUD.HP(health);
        }
    }
}
