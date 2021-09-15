using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    bool inRange = false;
    SnowPrincess player;
    Notification hud;

    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
        hud = GameObject.Find("HUD").GetComponent<Notification>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            SaveSystem.SavePlayer(player);
            hud.Notify("Game Saved");
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
