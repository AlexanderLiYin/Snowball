using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour
{
    public Slider slider;
    public GameObject loseScreen;
    public GameObject winScreen;

    public void HP(int health)
    {
        slider.value = health;
    }

    public void Win()
    {
        winScreen.SetActive(true);
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
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        loseScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
