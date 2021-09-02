using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public DmgPopUp dmgPopUp;
    int dmg = 1;

    public void setDmg(int damage)
    {
        dmg = damage;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<SnowPrincess>().decHealth(1);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Building")
        {
            Building temp;
            temp = col.gameObject.GetComponent<Building>();
            temp.decHealth(1);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Helper")
        {
            EnemyHealth temp;
            temp = col.gameObject.GetComponent<EnemyHealth>();
            temp.decHealth(1);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
