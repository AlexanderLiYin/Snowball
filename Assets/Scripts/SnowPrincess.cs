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
    public int coins;
    public bool inBattle;
    bool mobile;

    //Energy
    public int initEnergy = 50;
    public int maxEnergy = 120;
    public float energyPerSec = 1;
    float energy;

    //Sound
    public SoundPack footsteps;
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

        // Display Energy
        energy = initEnergy;
        HUD.DisplayEnergy(energy, maxEnergy);

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

    // Used for moving the player
    void FixedUpdate()
    {
        //Energy Generation
        if (inBattle)
        {
            if (energy < maxEnergy)
            {
                energy += Time.deltaTime * energyPerSec;
            }
            else
            {
                energy = maxEnergy;
            }
            HUD.DisplayEnergy(energy, maxEnergy);
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

    public void addCoins(int amount)
    {
        coins += amount;
        print("Coin count is now " + coins);
    }

    public bool subCoins(int amount)
    {
        print(coins);
        if (amount <= coins)
        {
            print(amount);
            coins -= amount;
            return true;
        }
        else
            return false;
    }

    public void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadPlayer();
        maxHealth = data.maxHealth;
        attackRate = data.attackRate;
        coins = data.coins;
        attack = data.attack;
    }

    public void incMaxHealth(int hp)
    {
        HUD.IncMaxHealth(hp);
        HUD.DisplayHP(health, maxHealth);
        maxHealth += hp;
    }

    public bool decMaxHealth(int hp)
    {
        if ((maxHealth - hp) > 0)
        {
            HUD.DisplayHP(health, maxHealth);
            maxHealth -= hp;
            return true;
        }
        else return false;
    }

    public bool decEnergy(int cost)
    {
        if (cost > energy)
            return false;
        else
        {
            energy = energy - cost;
            return true;
        }
    }

    public void incMaxEnergy(int energy)
    {
        maxEnergy += energy;
        HUD.DisplayEnergy(energy, maxEnergy);
    }

    public bool decMaxEnergy(int energy)
    {
        if ((maxEnergy - energy) > 0)
        {
            maxEnergy -= energy;
            return true;
        }
        else return false;
    }

    public void incEnergyRecharge(float rate)
    {
        energyPerSec += rate;
    }

    public bool decEnergyRecharge(float rate)
    {
        if ((energyPerSec - rate) > 0)
        {
            energyPerSec -= rate;
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