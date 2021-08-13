using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    SnowPrincess player;
    public TMP_Text coins;

    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
    }

    void OnEnable()
    {
        if(player)
        coins.text = player.coins.ToString();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            exit();
        }
    }
    
    public void exit()
    {
        gameObject.SetActive(false);
        player.canMove = true;
    }
}
