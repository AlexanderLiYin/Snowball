using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    SnowPrincess player;
    public TMP_Text coins;
    public TMP_Text descript;
    public ShopItem[] items;
    int item;

    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
        if(items[0] != null)
        {
            descript.SetText(items[0].description);
            item = 0;
        }
        else
        {
            descript.SetText("All items have been bought");
        }
    }

    void OnEnable()
    {
        if(player)
        coins.text = player.getCoins().ToString();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            exit();
        }
    }
    
    public void buyItem(int cost)
    {
        if (player.subCoins(cost))
        {
            coins.text = player.getCoins().ToString();
            return;
        }
        else
        {
            print("Not enought money");
            return;
        }
    }

    public void changeDescrip(int option)
    {
        if (items[option] != null)
        {
            descript.SetText(items[option].description);
            item = option;
        }
    }

    public void exit()
    {
        gameObject.SetActive(false);
        player.canMove = true;
    }
}
