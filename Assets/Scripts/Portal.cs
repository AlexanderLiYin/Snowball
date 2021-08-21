using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int scene;
    public Shop shop;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            /*
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                SaveSystem.SavePlayer(shop);
            }
            */
            SaveSystem.SavePlayer(col.gameObject.GetComponent<SnowPrincess>());
            SceneManager.LoadScene(scene);
        }
    }
}
