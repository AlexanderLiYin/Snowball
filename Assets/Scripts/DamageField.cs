using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyHealth temp;
            temp = col.gameObject.GetComponent<EnemyHealth>();
            temp.decHealth(damage);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Player")
        {
            PlayerHealth temp;
            temp = col.gameObject.GetComponent<PlayerHealth>();
            temp.decHealth(damage);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Building")
        {
            Building temp;
            temp = col.gameObject.GetComponent<Building>();
            temp.decHealth(damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
