using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    SnowPrincess player;

    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
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
