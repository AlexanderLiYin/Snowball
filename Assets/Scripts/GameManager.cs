using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUDScript HUD;
    public int scene;
    SnowPrincess player;
    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
    }
    public void Win()
    {
        print("You Win");
        player.addCoins(100);
        SaveSystem.SavePlayer(player);
        HUD.Win();
    }

    public void Lose()
    {
        print("You Lost");
        HUD.Lose();
    }
}
