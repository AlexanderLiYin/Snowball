using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int maxHealth;
    public int health;
    //public float moveSpeed;
    public float attackRate;
    public int attack;

    public SaveData(SnowPrincess player)
    {
        maxHealth = player.maxHealth;
        health = player.health;
        //moveSpeed = player.movespeed;
        attackRate = player.attackRate;
        attack = player.attack;
    }
}