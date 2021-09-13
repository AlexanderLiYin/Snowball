using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPCStateMachine : MonoBehaviour
{
    public Transform firePoint;
    public GameObject snowballPrefab;
    public float bulletForce = 20f;
    public float fireRate = 1;
    public Rigidbody2D rb;
    public CircleCollider2D cc;
    //public GameObject waypoint; Obsolete
    public float moveSpeed = 4f;
    public float followRange = 3;
    
    float attackRange;
    public enum State {idle, attack, move}
    public State state;
    float shootTime = 0;
    List<GameObject> target = new List<GameObject>();

    public AILerp ai;
    EnemyHealth hp;

    void Start()
    {
        attackRange = cc.radius;
        //waypoint = GameObject.FindGameObjectWithTag("Player");
        ai.canMove = false;
        ai.canSearch = false;

        hp = GetComponent<EnemyHealth>();
        hp.OnDmgTaken += Alert;
    }

    void Alert(object sender,EventArgs e)
    {
        print("Alert");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale != 0 && state != State.attack && gameObject.tag == "Helper")
        {
            state = State.move;
        }
        if (Input.GetKeyDown(KeyCode.R) && Time.timeScale != 0 && state != State.attack && gameObject.tag == "Helper")
        {
            state = State.idle;
        }
        switch (state)
        {
            case State.idle:
                break;

            case State.attack:
                Attack();
                break;

            case State.move:
                Move();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            if (gameObject.tag == "Helper")
            {
                if (col.gameObject.tag == "Enemy")
                {
                    target.Add(col.gameObject);
                    state = State.attack;
                }
            }
            else if (gameObject.tag == "Enemy")
            {
                if (col.gameObject.tag == "Player" || col.gameObject.tag == "Helper")
                {
                    target.Add(col.gameObject);
                    state = State.attack;
                }
            }
        }
    }

    // Remove player from Check to see if the enemy list is empty, if it is then return to idle. If not, switch target to another enemy.
    void OnTriggerExit2D(Collider2D col)
    {
        if (target.Contains(col.gameObject))
        {
            target.Remove(col.gameObject);
            if(target.Count == 0)
                state = State.move;
        }
    }

    void Attack()
    {
        Rigidbody2D pRB = target[0].GetComponent<Rigidbody2D>(); // Get player rigidbody
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

    void Move()
    {
        ai.canSearch = true;
        ai.canMove = true;
    }
}
