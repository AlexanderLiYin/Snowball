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
    public TMP_Text amount;
    public TMP_Text cost;
    public ShopItem[] items;
    int item;

    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
        coins.text = player.getCoins().ToString();
        if (items[0] != null)
        {
            descript.SetText(items[0].description);
            amount.SetText("Stock: " + items[0].amount.ToString());
            cost.SetText("Cost: " + items[0].cost.ToString());
            item = 0;
        }
        else
        {
            descript.SetText("All items have been bought");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            exit();
        }
    }
    
    public void buyItem()
    {
        if(player.subCoins(items[item].cost) && (items[item].amount > 0))
        {
            coins.text = player.getCoins().ToString();
            items[item].amount -= 1;
            amount.SetText("Stock: " + items[item].amount.ToString());
            return;
        }
        else if(items[item].amount == 0)
        {
            print("No more in stock");
            return;
        }
        else
        {
            print("Not enough money");
            return;
        }
    }

    public void changeDescrip(int option)
    {
        if (items[option] != null)
        {
            descript.SetText(items[option].description);
            amount.SetText("Stock: " + items[option].amount.ToString());
            cost.SetText("Cost: " + items[option].cost.ToString());
            item = option;
        }
    }

    public void exit()
    {
        gameObject.SetActive(false);
        player.canMove = true;
    }
}
