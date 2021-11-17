using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int scene = 5;
    public void Play()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
