using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateInventorySystem.Exchange;

public class Chest : MonoBehaviour
{
    [Tooltip("Negative 1 if not in any group")]
    public int group = -1; //Negative 1 if not in any group
    bool opened = false;
    CurrencyOwner player;

    //Will later need to save the state of chests
    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<CurrencyOwner>();
    }

    //Add gold function
    public void AddGold(int amount)
    {
        if(!opened)
        {
            player.AddCurrency("Gold", amount);
            opened = true;
        }     
    }
}
