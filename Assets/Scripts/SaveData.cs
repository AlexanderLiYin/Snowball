using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public int maxHealth;

    public SaveData(PlayerHealth player)
    {
        maxHealth = player.maxHealth;
    }
}