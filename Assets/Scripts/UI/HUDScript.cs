using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public Slider slider;
    public GameObject loseScreen;
    public GameObject winScreen;
    public TMP_Text timer;
    public TMP_Text display; //Snow Energy Display
    public TMP_Text hpText; //HP bar display
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject joystick;
    GameManager manager;

    public bool battle;
    
    int scene;
    bool mobile;
    public float time = 600;

    void Start()
    {
        try
        {
            manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        catch
        {
            print("Game Manager not found");
        }
        scene = manager.scene; //Get the scene number

        //Check to see if platform is mobile
        if ((Application.platform == RuntimePlatform.IPhonePlayer) || (Application.platform == RuntimePlatform.Android))
            mobile = true;
        else mobile = false;

        if (mobile)
        {
            joystick.SetActive(true);
        }
        else joystick.SetActive(false);
    }

    void FixedUpdate()
    {
        if (battle)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 0;
            }

            DisplayTime(time);

            if (time == 0)
            {
                Lose();
            }
        }
    }

    void DisplayTime(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);
        float millisec = time % 1 * 1000;

        timer.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void DisplayEnergy(float energy, int maxEnergy)
    {
        display.SetText(((int)energy).ToString() + "/" + maxEnergy.ToString());
    }

    public void DisplayHP(float hp, int maxHP)
    {
        hpText.SetText(((int)hp).ToString() + "/" + maxHP.ToString());
    }

    public void HP(int health)
    {
        slider.value = health;
    }

    public void IncMaxHealth(int hp)
    {
        slider.maxValue += hp;
    }

    public void Win()
    {
        winScreen.SetActive(true);
        if(time > 60)
            star1.SetActive(true);
        if(time > 120)
            star2.SetActive(true);
        if(time > 180)
            star3.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    //All menus that change scene unpause the game
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OverWorld()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
