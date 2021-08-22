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
        changeDescrip(0);
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
            Upgrade();
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
        else
        {
            descript.SetText("All items have been bought");
        }
    }

    public void exit()
    {
        gameObject.SetActive(false);
        player.canMove = true;
    }

    void Upgrade()
    {
        switch(item)
        {
            case 0:
                player.incMaxHealth(1);
                break;

            case 1:
                break;

            case 2:
                break;

            default:
                print("Item not found");
                break;
        }
    }
}
