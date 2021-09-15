using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int coins;
    bool opened = false;
    bool inRange = false;
    Notification hud;

    //Will later need to save the state of chests
    void Start()
    {
        hud = GameObject.Find("HUD").GetComponent<Notification>();
    }

    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!opened)
            {
                FindObjectOfType<SnowPrincess>().addCoins(coins);
                opened = true;
            }
            else
                print("Chest has already been openned");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        hud.Notify("E to Interact");
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inRange = false;
    }
}
