using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    HUDScript HUD;
    public int scene;
    public bool canAttack = true;
    public AudioClip victoryMusic;
    public AudioClip defeatMusic;
    SnowPrincess player;

    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
        HUD = GameObject.Find("HUD").GetComponent<HUDScript>();
        scene = SceneManager.GetActiveScene().buildIndex;
        player.canAttack = canAttack;
        if (scene == 2)
            player.inBattle = true; //Controls Snow Princess energy recharge
        else player.inBattle = false;
    }
    public void Win()
    {
        //player.addCoins(100);
        SaveSystem.SavePlayer(player);
        gameObject.GetComponent<AudioSource>().clip = victoryMusic;
        gameObject.GetComponent<AudioSource>().Play();
        HUD.Win();
    }

    public void Lose()
    {
        gameObject.GetComponent<AudioSource>().clip = defeatMusic;
        gameObject.GetComponent<AudioSource>().Play();
        HUD.Lose();
    }
}
