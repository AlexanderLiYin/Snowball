using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HUDScript HUD;
    public int scene;
    public bool canAttack = true;

    SnowPrincess player;
    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
        scene = SceneManager.GetActiveScene().buildIndex;
        player.canAttack = canAttack;
        if (scene != 3)
            player.inBattle = true;
        else player.inBattle = false;
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
