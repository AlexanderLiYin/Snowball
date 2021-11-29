using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public class Snowball : MonoBehaviour
{
    public DmgPopUp dmgPopUp;
    int dmg = 1;
    public SoundPack soundpack;
    AudioSource source;

    public void setDmg(int damage)
    {
        dmg = damage;
    }

    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = soundpack.audio[0];
    }

    void OnCollisionEnter2D(Collision2D col)
    {    
        source.Play();
        if (col.gameObject.tag == "Enemy")
        {
            EnemyHealth temp;
            temp = col.gameObject.GetComponent<EnemyHealth>();
            temp.decHealth(dmg);
            dmgPopUp.Create(transform.position,dmg,false);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Player")
        {
            PlayerHealth temp;
            temp = col.gameObject.GetComponent<PlayerHealth>();
            temp.decHealth(dmg);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Building")
        {
            Building temp;
            temp = col.gameObject.GetComponent<Building>();
            temp.decHealth(dmg);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
