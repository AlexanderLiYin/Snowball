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
    SpriteRenderer sprite;
    public Sprite openChest;

    //Will later need to save the state of chests
    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<CurrencyOwner>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    //Add gold function
    public void AddGold(int amount)
    {
        if(!opened)
        {
            player.AddCurrency("Gold", amount);
            gameObject.GetComponent<AudioSource>().Play();
            ChangeSprite();
            opened = true;
        }     
    }

    void ChangeSprite()
    {
        sprite.sprite = openChest;
    }
}
