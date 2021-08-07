using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public DmgPopUp dmgPopUp;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyHealth temp;
            temp = col.gameObject.GetComponent<EnemyHealth>();
            temp.decHealth(1);
            dmgPopUp.Create(transform.position,1,false);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Player")
        {
            PlayerHealth temp;
            temp = col.gameObject.GetComponent<PlayerHealth>();
            temp.decHealth(1);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Building")
        {
            Building temp;
            temp = col.gameObject.GetComponent<Building>();
            temp.decHealth(1);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
