using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{
    public GameObject image; //Background for the notification
    public TMP_Text notice;
    bool active = false;
    float timer = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(active)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                active = false;
                image.SetActive(false);
                timer = 5;
            }
        }
    }

    public void Notify(string message)
    {
        notice.text = message;
        image.SetActive(true);
        active = true;
    }
}
