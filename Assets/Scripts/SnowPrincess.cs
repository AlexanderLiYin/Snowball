using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowPrincess : MonoBehaviour
{
    //Player Movement
    public float movespeed = 5f;
    Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    public bool canMove = true;
    Joystick joystick;

    //Player health
    HUDScript HUD;
    public int maxHealth = 10;
    public int health = 10;
    bool onTrench = false;
    public float evadeChance = 10;

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
    
    void Start()
    {
        //Get Rigidbody2D
        rb = gameObject.GetComponent<Rigidbody2D>();

        //Initialize health
        LoadPlayer();
        HUD = GameObject.Find("HUD").GetComponent<HUDScript>();
        HUD.HP(health);
        HUD.DisplayHP(health, maxHealth);

        // Display Energy
        energy = initEnergy;
        HUD.DisplayEnergy(energy, maxEnergy);

        // Get platform
        if ((Application.platform == RuntimePlatform.IPhonePlayer) || (Application.platform == RuntimePlatform.Android))
            mobile = true;
        else mobile = false;

        if (mobile)
            joystick = HUD.joystick.GetComponent<FixedJoystick>();
    }

    void Update()
    {
        if (!mobile)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                mousePos = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }

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

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    // Used for moving the player
    void FixedUpdate()
    {
        // Movement
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }

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

    public void TrenchStatus(bool status)
    {
        onTrench = status;
        if (onTrench == true)
        {
            movespeed = 7;
        }
        else if (onTrench == false)
        {
            movespeed = 5;
        }
    }

    public void decHealth(int dmg)
    {
        if (onTrench)
        {
            if (evadeChance > Random.Range(0, 99))
            {
                print("Miss");
                return;
            }

        }
        health -= dmg;
        HUD.HP(health);
        HUD.DisplayHP(health, maxHealth);
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
        movespeed = data.moveSpeed;
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

    public void incMoveSpd(float speed)
    {
        movespeed += speed;
    }

    public bool decMoveSpd(float speed)
    {
        if ((movespeed - speed) > 0)
        {
            movespeed -= speed;
            return true;
        }
        else return false;
    }
}