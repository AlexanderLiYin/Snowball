using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int maxHealth;
    public int health;
    public int coins;
    public float moveSpeed;
    public float attackRate;

    public List<ShopItem> storage;

    public SaveData(SnowPrincess player)
    {
        maxHealth = player.maxHealth;
        health = player.health;
        moveSpeed = player.movespeed;
        attackRate = player.attackRate;
        coins = player.getCoins();
    }

    public SaveData(ShopItem[] shop)
    {
        foreach (ShopItem x in shop)
        {
            storage.Add(x);
        }
    }

    public SaveData(SnowPrincess player, ShopItem[] shop)
    {
        maxHealth = player.maxHealth;
        health = player.health;
        moveSpeed = player.movespeed;
        attackRate = player.attackRate;
        coins = player.getCoins();

        foreach (ShopItem x in shop)
        {
            storage.Add(x);
        }
    }
}