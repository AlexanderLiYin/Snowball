using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Opsive.UltimateInventorySystem.SaveSystem;

public class Portal : MonoBehaviour
{
    public int scene;

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
            SaveSystemManager.Save(0);
            SaveSystem.SavePlayer(col.gameObject.GetComponent<SnowPrincess>());
            SceneManager.LoadScene(scene);
        }
    }
}
