using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject buildMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && Time.timeScale != 0)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        buildMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        buildMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

}
