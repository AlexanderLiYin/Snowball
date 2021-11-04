using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DugoutAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject snowballPrefab;
    public float bulletForce = 20f;
    public Rigidbody2D rb;
    public float fireRate = 1;
    public float targetRange = 5f;
    float shootTime = 0;
    Vector2 startPos;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Attack();
    }

    public void Attack()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < targetRange)
        {
            Rigidbody2D pRB = player.GetComponent<Rigidbody2D>(); // Get player rigidbody
            Vector2 lookDir = pRB.position - rb.position; // get direction from enemy to player
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; // Get the angle
            rb.rotation = angle; //Rotate the enemy to face the player

            if (Time.time > shootTime) //Attack cooldown
            {
                GameObject snowball = Instantiate(snowballPrefab, firePoint.position, firePoint.rotation); //Instatiate snowball
                Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>(); // Get snowball rigid body
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // Give it force
                shootTime = Time.time + fireRate; //Reset attack cooldown
            }
        }
    }
}
