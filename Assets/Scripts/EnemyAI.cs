using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform firePoint;
    public GameObject snowballPrefab;
    public float bulletForce = 20f;
    public Rigidbody2D rb;
    public float fireRate = 1;

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
        float targetRange = 5f;
        if(Vector2.Distance(transform.position, player.transform.position) < targetRange)
        {
            Rigidbody2D pRB = player.GetComponent<Rigidbody2D>();
            Vector2 lookDir = pRB.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            if (Time.time > shootTime)
            {
                GameObject snowball = Instantiate(snowballPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                shootTime = Time.time + fireRate;
            }
        }
    }
}
