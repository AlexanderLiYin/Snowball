using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    bool inRange = false;
    SnowPrincess player;

    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            SaveSystem.SavePlayer(player);
            print("Game Saved");
        }
            
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inRange = false;
    }
}
