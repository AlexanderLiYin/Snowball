using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{
    public GameObject image; //Background for the notification
    public TMP_Text notice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Notify(string message)
    {
        notice.text = message;
        image.SetActive(true);
    }
}
