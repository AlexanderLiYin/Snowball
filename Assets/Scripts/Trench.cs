using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trench : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (col.gameObject.tag == "Enemy")
        {
            EnemyHealth temp;
            temp = col.gameObject.GetComponent<EnemyHealth>();
            temp.decHealth(1);
        }
        */
        if (col.gameObject.tag == "Player")
        {
            PlayerHealth temp;
            temp = col.gameObject.GetComponent<PlayerHealth>();
            temp.TrenchStatus(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHealth temp;
            temp = col.gameObject.GetComponent<PlayerHealth>();
            temp.TrenchStatus(false);
        }
    }
}
