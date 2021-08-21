using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int scene;
    public ShopItem[] shop;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SaveSystem.SavePlayer(col.gameObject.GetComponent<SnowPrincess>());
            SceneManager.LoadScene(scene);
        }
    }
}
