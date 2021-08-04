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
    public float time = 600;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public bool battle;

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
    
    public void HP(int health)
    {
        slider.value = health;
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

    public void Retry()
    {
        loseScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        loseScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
