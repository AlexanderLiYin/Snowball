using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateMachine : MonoBehaviour
{
    public Transform firePoint;
    public GameObject snowballPrefab;
    public float bulletForce = 20f;
    public float fireRate = 1;
    public Rigidbody2D rb;
    public CircleCollider2D cc;
    float range;
    enum State {idle, attack}
    State state;
    float shootTime = 0;
    GameObject player;
    // public List<Transform> enemies;

    // Start is called before the first frame update
    void Start()
    {
        state = State.idle;
        range = cc.radius;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.idle:
                break;

            case State.attack:
                Attack();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Get a referance to the player and switch states
            player = col.gameObject;
            state = State.attack;
        }
    }

    // Remove player from Check to see if the enemy list is empty, if it is then return to idle. If not, switch target to another enemy.
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            state = State.idle;
            //enemies.Remove(col.gameObject);
        }
    }

    public void Attack()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < range)
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
