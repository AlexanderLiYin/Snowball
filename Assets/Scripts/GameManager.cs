using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUDScript HUD;
    public int scene;

    public void Win()
    {
        print("You Win");
        GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>().addCoins(100);
        HUD.Win();
    }

    public void Lose()
    {
        print("You Lost");
        HUD.Lose();
    }
}
