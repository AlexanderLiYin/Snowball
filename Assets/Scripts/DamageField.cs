using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    public int damage;
    public float duration = 2;
    public float delay = 1;
    public Abilities ability;
    bool active = false;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            active = true;
        }
        /*
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
            //Destroy(gameObject);
        }
        */
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(active == true)
        {
            Damage(col);
        }
        //if (delay > duration)
        //{
        
            //Destroy(gameObject);
        //}
    }

    void Damage(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyHealth temp;
            temp = col.gameObject.GetComponent<EnemyHealth>();
            temp.decHealth(damage);
            ability.Disable();
        }
        else if (col.gameObject.tag == "Player")
        {
            SnowPrincess temp;
            temp = col.gameObject.GetComponent<SnowPrincess>();
            temp.decHealth(damage);
            ability.Disable();
        }
    }
}
