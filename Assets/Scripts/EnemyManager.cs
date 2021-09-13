using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyHealth[] hp;
    public event Action<int> OnDmgTaken;

    // Start is called before the first frame update
    void Start()
    {
        foreach(EnemyHealth enemy in hp)
        {
            enemy.OnDmgTaken += Alert; //Add the function to the event else it won't be called
        }
    }

    void Alert(int group)
    {
        OnDmgTaken.Invoke(group);
    }
}
