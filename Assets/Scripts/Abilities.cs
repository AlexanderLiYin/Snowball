using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public GameObject targetCircle;
    public GameObject rangeCircle;
    public Transform player;

    Vector2 Position;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!active && Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetCircle.SetActive(true);
            rangeCircle.SetActive(true);
            active = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButton("Fire1"))
        {
            targetCircle.SetActive(false);
            rangeCircle.SetActive(false);
            active = false;
        }
    }
}
