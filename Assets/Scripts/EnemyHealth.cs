using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int initHealth;
    int health;
    public HealthBar hpBar;
    public bool isBoss;

    bool onTrench = false;
    public float evadeChance = 10;
    public event Action<int> OnDmgTaken;
    public event Action<EnemyHealth> OnDefeat;
    public int group;

    public SoundPack damageSound;
    AudioSource source;

    void Start()
    {
        health = initHealth;
        source = gameObject.GetComponent<AudioSource>();
    }

    public void decHealth(int dmg)
    {
        source.clip = damageSound.audio[0];
        source.Play();
        OnDmgTaken.Invoke(group); //Tell the game manager that an enemy has taken damage
        health -= dmg;
        hpBar.HP(health);
        if(health <= 0)
        {
            if(isBoss)
            {
                FindObjectOfType<GameManager>().Win();
            }
            OnDefeat.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void TrenchStatus(bool status)
    {
        onTrench = status;
    }
}
