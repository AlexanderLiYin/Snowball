using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Audio;
using Movement;

public class SnowPrincess : MonoBehaviour
{
    //Player health
    HUDScript HUD;
    public int maxHealth = 10;
    public int health = 10;

    // Player attack
    public int attack = 1;
    public Transform firePoint;
    public GameObject snowballPrefab;
    public float bulletForce = 20f;
    float attackTime = 0;
    public float attackRate = 2; // attacks per a second
    public bool canAttack = true;

    //Player Stats
    public bool inBattle;
    bool mobile;

    //Sound
    public SoundPack damage;
    public SoundPack attackSound;
    AudioSource audioSource;

    void Start()
    {
        //Get Audio Source
        audioSource = gameObject.GetComponent<AudioSource>();
        //Initialize health
        //LoadPlayer();
        try
        {
            HUD = GameObject.Find("HUD").GetComponent<HUDScript>();
        }
        catch
        {
            print("Error, HUD not found");
        }
        HUD.HP(health);
        HUD.DisplayHP(health, maxHealth);

        // Get platform
        /*
        if ((Application.platform == RuntimePlatform.IPhonePlayer) || (Application.platform == RuntimePlatform.Android))
            mobile = true;
        else mobile = false;

        if (mobile)
            joystick = HUD.joystick.GetComponent<FixedJoystick>();
        */
    }

    void Update()
    {
        //Used for attack
        if ((Time.time >= attackTime) && canAttack)
        {
            if ((Input.GetButtonDown("Fire1") || Input.touchCount > 0) && Time.timeScale != 0)
            {
                Attack();
                attackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void decHealth(int dmg)
    {
        health -= dmg;
        HUD.HP(health);
        HUD.DisplayHP(health, maxHealth);
        audioSource.clip = damage.audio[0];
        audioSource.Play();
        if (health <= 0)
        {
            print("Health is 0");
            FindObjectOfType<GameManager>().Lose();
        }
    }

    public void incHealth(int hp)
    {
        if ((health + hp) > maxHealth)
            health = maxHealth;
        else
            health += hp;
        HUD.HP(health);
        HUD.DisplayHP(health, maxHealth);
    }

    void Attack()
    {
        GameObject snowball = Instantiate(snowballPrefab, firePoint.position, firePoint.rotation);
        snowball.GetComponent<Snowball>().setDmg(attack);
        Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        audioSource.clip = attackSound.audio[0];
        audioSource.Play();
    }

    public void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadPlayer();
        maxHealth = data.maxHealth;
        attackRate = data.attackRate;
        attack = data.attack;
    }

    public void incMaxHealth(int hp)
    {
        maxHealth += hp;
        HUD.IncMaxHealth(hp);
        HUD.DisplayHP(health, maxHealth);
    }

    public bool decMaxHealth(int hp)
    {
        if ((maxHealth - hp) > 0)
        {
            maxHealth -= hp;
            HUD.DisplayHP(health, maxHealth);
            return true;
        }
        else return false;
    }

    public void incAttack(int dmg)
    {
        attack += dmg;
    }

    public bool decAttack(int dmg)
    {
        if ((attack - dmg) > 1)
        {
            attack -= dmg;
            return true;
        }
        else return false;
    }

    public void incAtkSpd(float speed)
    {
        attackRate += speed;
    }

    public bool decAtkSpd(float speed)
    {
        if ((attackRate - speed) > 0)
        {
            attackRate -= speed;
            return true;
        }
        else return false;
    }
}