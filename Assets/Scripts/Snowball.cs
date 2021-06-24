using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("Enemy is triggered");
        if (col.gameObject.tag == "Enemy")
        {
            EnemyHealth temp;
            temp = col.gameObject.GetComponent<EnemyHealth>();
            temp.decHealth(1);
            Destroy(gameObject);
        }
    }
}
