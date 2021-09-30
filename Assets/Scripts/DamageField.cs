using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    public int damage;
    public float duration = 2;
    public float delay = 1;

    void FixedUpdate()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            duration = 0;
        }

        if (duration == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //if (delay > duration)
        //{
            if (col.gameObject.tag == "Enemy")
            {
                EnemyHealth temp;
                temp = col.gameObject.GetComponent<EnemyHealth>();
                temp.decHealth(damage);
                Destroy(gameObject);
            }
            else if (col.gameObject.tag == "Player")
            {
                SnowPrincess temp;
                temp = col.gameObject.GetComponent<SnowPrincess>();
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
        //}
    }
}
