using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    int maxHealth;
    int coins;
    float moveSpeed;
    float attackRate;

    public SaveData(SnowPrincess player)
    {
        maxHealth = player.maxHealth;
        moveSpeed = player.movespeed;
        attackRate = player.attackRate;
        coins = player.coins;
    }
}