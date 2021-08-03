using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPrincess : MonoBehaviour
{
    //Player Movement
    public float movespeed = 5f;
    Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    //Player health
    public HUDScript HUD;
    public int maxHealth;
    public int initHealth;
    int health;
    bool onTrench = false;
    public float evadeChance = 10;

    // Player attack
    public Transform firePoint;
    public GameObject snowballPrefab;
    public float bulletForce = 20f;
    float attackTime = 0;
    public float attackRate = 2; // attacks per a second

    //Initialize health
    void Start()
    {
        //Get Rigidbody2D
        rb = gameObject.GetComponent<Rigidbody2D>();
        health = initHealth;
        HUD.HP(health);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Used for attack
        if (Time.time >= attackTime)
        {
            if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
            {
                Attack();
                attackTime = Time.time + 1f / attackRate;
            }
        }
    }

    // Used for moving the player
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
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
        if (health <= 0)
        {
            print("Health is 0");
            FindObjectOfType<GameManager>().Lose();
        }
    }

    void Attack()
    {
        GameObject snowball = Instantiate(snowballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
